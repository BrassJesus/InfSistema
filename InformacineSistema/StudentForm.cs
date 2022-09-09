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
    public partial class StudentForm : Form
    {
        private MySqlConnection conn;
        private string server;
        private string username;
        private string password;
        private string database;
        public IUser User;

        public StudentForm(IUser user)
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

        public string getLecturerName(string dalykas)
        {
            string name;
            string query = "SELECT vardas FROM destytojas WHERE dalykas = '" + dalykas + "';";
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
        public string getLecturerSurname(string dalykas)
        {
            string name;
            string query = "SELECT pavarde FROM destytojas WHERE dalykas = '" + dalykas + "';";
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
        public int[] returnCourseNumbers(int id)
        {
            int[] courseNumbers = new int[8];
            string query = "SELECT dalyko_id FROM studentu_dalykai WHERE studento_id = ' " + id + "';";
            if (isConnected())
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader rd = cmd.ExecuteReader();
                int i = 0;
                    while(rd.Read())
                    {
                        courseNumbers[i] = Convert.ToInt32(rd[0].ToString());
                        MessageBox.Show(Convert.ToString(courseNumbers[i]));
                        i = i + 1;
                        //rd.Close();
   
                }
            }
            return courseNumbers;
        }
        public void fillTable(IUser user)
        {
            var dataTable = new DataTable();
            int id = user.ID;
            dataTable.Columns.Add(new DataColumn() { ColumnName = "Dalykas" });
            dataTable.Columns.Add(new DataColumn() { ColumnName = "Destytojas" });
            dataTable.Columns.Add(new DataColumn() { ColumnName = "Pazymys" });
            int []courseNumbers = returnCourseNumbers(id);
            int arrsize = 0;
            int i;
            for (i=0; i<8; i++)
            {
                if(courseNumbers[i] != 0)
                {
                    arrsize++;
                }
            }
            //MessageBox.Show(Convert.ToString(arrsize));
            for (i=0; i<arrsize; i++)
            {
                if (isConnected())
                {
                    string dalykoname;
                    string query = "SELECT * FROM dalykas WHERE id = '" + courseNumbers[i] + "';";
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
                        dataTable.Rows.Add(row);
                        rd.Close();
                    }
                }
            }

            // MySqlCommand cmd = new MySqlCommand(query, conn);
            dataGridView1.DataSource = dataTable;



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
