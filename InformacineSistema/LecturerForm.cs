using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace InformacineSistema
{
    public partial class LecturerForm : Form
    {
        private MySqlConnection conn;
        private string server;
        private string username;
        private string password;
        private string database;
        public IUser User;
        public LecturerForm()
        {
            InitializeComponent();
        }
        public LecturerForm(IUser user)
        {
            InitializeComponent();
            User = user;
            server = "localhost";
            username = "root";
            password = "";
            database = "sistema";
            string ConnStr = "Server=" + server + ";" + "Database= " + database + ";" + "UID=" + username + ";" + "Password=" + password + ";";
            conn = new MySqlConnection(ConnStr);
            label2.Text = User.Name + "  " + User.Surname;
            label3.Text = User.Group;
            fillTable(user);
        }
        public bool isConnected()
        {
            try
            {
                conn.Close();
                conn.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Connection to server failed!");
                        break;
                    case 1045:
                        MessageBox.Show("Server username or password is incorrect!");
                        break;
                }
                return false;
            }
        }
        public int getClassID()
        {
            string className = User.Group;
            int num;
            string query = "SELECT id FROM dalykas WHERE dalykas = '" + className + "';";
            if (isConnected())
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    num = Convert.ToInt32(rd[0].ToString());
                    rd.Close();
                    return num;
                }
            }
            return 0;
        }
        public string getStudentName(int id)
        {
            string name;
            string query = "SELECT vardas FROM studentas WHERE id = '" + id + "';";
            if (isConnected())
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    name = rd[0].ToString();
                    rd.Close();
                    return name;
                }

            }

            return "ERROR";
        }
        public string getStudentSurname(int id)
        {
            string name;
            string query = "SELECT pavarde FROM studentas WHERE id = '" + id + "';";
            if (isConnected())
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    name = rd[0].ToString();
                    rd.Close();
                    return name;
                }

            }

            return "ERROR";
        }
        public int getStudentGrade(int id, int course_id)
        {
            int grade;
            string query = "SELECT * FROM studentu_dalykai WHERE studento_id = '" + id + "';";
            string query2 = "SELECT pazymys FROM dalykas WHERE id = '" + course_id + "';";
            if (isConnected())
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    if (Convert.ToInt32(rd[2].ToString()) == course_id)
                    {
                        rd.Close();
                        MySqlCommand cmd2 = new MySqlCommand(query2, conn);
                        MySqlDataReader rd2 = cmd2.ExecuteReader();
                        if (rd2.Read()){ 
                        grade = Convert.ToInt32(rd2[0].ToString());
                        rd2.Close();
                        return grade;
                    }
                    }
                }
            }
            //rd2.Close();
            return 0;
        }
        public int[] returnStudentNumbers(int id)
        {
            int[] studentNumbers = new int[50];
            string query = "SELECT studento_id FROM studentu_dalykai WHERE dalyko_id = ' " + id + "';";
            if (isConnected())
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader rd = cmd.ExecuteReader();
                int i = 0;
                while (rd.Read())
                {
                    studentNumbers[i] = Convert.ToInt32(rd[0].ToString());
                    //MessageBox.Show(Convert.ToString(studentNumbers[i]));
                    i = i + 1;
                    //rd.Close();
                }
            }
            return studentNumbers;
        }
        public string getGroupName(int student_id)
        {
            int group_id = 0;
            string group_name;
            string query = "SELECT grupes_id FROM studentas WHERE id = '" + student_id + "';";
            if (isConnected())
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader rd = cmd.ExecuteReader();
                if(rd.Read())
                {
                    group_id = Convert.ToInt32(rd[0].ToString());
                    //MessageBox.Show(group_id.ToString());
                    rd.Close();
                }
            }
            if (isConnected())
            {
                string query2 = "SELECT grupes_pavadinimas FROM grupe WHERE id = '" + group_id + "';";
                MySqlCommand cmd2 = new MySqlCommand(query2, conn);
                MySqlDataReader rd2 = cmd2.ExecuteReader();
                if(rd2.Read())
                {
                    group_name = rd2[0].ToString();
                    rd2.Close();
                    return group_name;
                }
            }
            return "ERROR";
        }
        public void changeGrade()
        {
            int grade = Convert.ToInt32(comboBox2.Text);
            int student_id = Convert.ToInt32(comboBox1.Text);
            int course_id = getClassID();
            string query = "SELECT * FROM studentu_dalykai WHERE studento_id = '" + student_id + "';";
            string query2 = "UPDATE dalykas SET pazymys = '" + grade + "' WHERE id = '" + course_id + "';";
            if (isConnected())
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader rd = cmd.ExecuteReader();
                if(rd.Read())
                {
                    if (Convert.ToInt32(rd[2].ToString()) == course_id)
                    {
                        rd.Close();
                        MySqlCommand cmd2 = new MySqlCommand(query2, conn);
                        cmd2.ExecuteNonQuery();
                    }
                }
            }

        }
        public void fillTable(IUser user)
        {
            var dataTable = new DataTable();
            int class_id = getClassID();
            dataTable.Columns.Add(new DataColumn() { ColumnName = "ID" });
            dataTable.Columns.Add(new DataColumn() { ColumnName = "Vardas" });
            dataTable.Columns.Add(new DataColumn() { ColumnName = "Pavarde" });
            dataTable.Columns.Add(new DataColumn() { ColumnName = "Grupe" });
            dataTable.Columns.Add(new DataColumn() { ColumnName = "Pazymys" });
            int[] studentNumbers = returnStudentNumbers(class_id);
            int arrsize = 0;
            int i;
            for (i = 0; i < 50; i++)
            {
                if (studentNumbers[i] != 0)
                {
                    arrsize++;
                }
            }
            //MessageBox.Show(Convert.ToString(arrsize));
            for (i = 0; i < arrsize; i++)
            {
                if (arrsize != 0)
                {
                    int student_id = studentNumbers[i];
                    string name = getStudentName(studentNumbers[i]);
                    string surname = getStudentSurname(studentNumbers[i]);
                    string groupname = getGroupName(studentNumbers[i]);
                    int gradevalue = getStudentGrade(studentNumbers[i], class_id);
                    var row = dataTable.NewRow();
                    comboBox1.Items.Add(student_id);
                    row["ID"] = student_id;
                    row["Vardas"] = name;
                    row["Pavarde"] = surname;
                    row["Grupe"] = groupname;
                    row["Pazymys"] = gradevalue;
                    /*string query = "SELECT * FROM dalykas WHERE id = '" + courseNumbers[i] + "';";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader rd = cmd.ExecuteReader();
                    var row = dataTable.NewRow();
                    if (rd.Read())
                    {
                        dalykoname = rd[1].ToString();
                        row["Dalykas"] = dalykoname;
                        string name = getLecturerName(dalykoname);
                        string surname = getLecturerSurname(dalykoname);
                        row["Destytojas"] = name + " " + surname;
                        if (isConnected())
                        {
                            MySqlCommand cmd2 = new MySqlCommand(query, conn);
                            MySqlDataReader rd2 = cmd.ExecuteReader();
                            if (rd2.Read())
                            {
                                row["Pazymys"] = rd2[2].ToString();
                                rd2.Close();
                            }
                        }
                    */
                        dataTable.Rows.Add(row);
                   // }
                }
            }
            dataGridView1.DataSource = dataTable;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            changeGrade();
        }
    }
}
