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
    public partial class AdminForm : Form
    {
        private MySqlConnection conn;
        //private MySqlConnection conn2;
        private string server;
        private string username;
        private string password;
        private string database;
        public IUser User;
        public AdminForm()
        {
            server = "localhost";
            username = "root";
            password = "";
            database = "sistema";
            string ConnStr = "Server=" + server + ";" + "Database= " + database + ";" + "UID=" + username + ";" + "Password=" + password + ";";
            conn = new MySqlConnection(ConnStr);
            //conn2 = new MySqlConnection(ConnStr);
            InitializeComponent();
            fillStudentTable();
            fillLecturerTable();
            fillGroupTable();
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
        public void fillStudentTable()
        {
            var sDT = new DataTable();
            int studentidentification;
            string groupname;
            //int class_id = getClassID();
            sDT.Columns.Add(new DataColumn() { ColumnName = "ID" });
            sDT.Columns.Add(new DataColumn() { ColumnName = "Vardas" });
            sDT.Columns.Add(new DataColumn() { ColumnName = "Pavarde" });
            sDT.Columns.Add(new DataColumn() { ColumnName = "Grupe" });
            sDT.Columns.Add(new DataColumn() { ColumnName = "Lygis" });
            int groupidentification;
            int size;
            conn.Open();
            string query = "SELECT COUNT(*) FROM studentas";
            string query2 = "SELECT * FROM studentas";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            size = Convert.ToInt32(cmd.ExecuteScalar());
            MessageBox.Show(size.ToString()) ;
            conn.Close();
            if (isConnected())
            {
                    MySqlCommand cmd2 = new MySqlCommand(query2, conn);
                    MySqlDataReader rd2 = cmd2.ExecuteReader();
                    //int i = 0;
                    while(rd2.Read())
                    {
                        var row = sDT.NewRow();
                        studentidentification = Convert.ToInt32(rd2[0].ToString());
                        row["ID"] = studentidentification;
                        row["Vardas"] = rd2[1].ToString();
                        row["Pavarde"] = rd2[2].ToString();
                        groupidentification = Convert.ToInt32(rd2[3].ToString());
                        row["Lygis"] = Convert.ToInt32(rd2[4].ToString());
                        //groupname = getGroupName(groupidentification);
                        //row["Grupe"] = groupname;
                        sDT.Rows.Add(row);
                        //rd2.Close();

                    }
                }
            

                //rd.Close();
            dataGridView1.DataSource = sDT;
        }
        public string getGroupName(int group_id)
        {
            //int group_id = 0;
            string group_name;
            string query3 = "SELECT grupes_pavadinimas FROM grupe WHERE id = '" + group_id + "';";
            //conn2.Open();
            if (isConnected()){
            MySqlCommand cmd = new MySqlCommand(query3, conn);
            MySqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                group_name = rd[0].ToString();
                    rd.Close();
                return group_name;
            }
        }

            //rd.Close();
            return "ERROR";
        }
        public void fillLecturerTable()
        {
            var lDT = new DataTable();
            int studentidentification;
            string dalykas;
            string query2 = "SELECT * FROM destytojas";
            //int class_id = getClassID();
            lDT.Columns.Add(new DataColumn() { ColumnName = "ID" });
            lDT.Columns.Add(new DataColumn() { ColumnName = "Vardas" });
            lDT.Columns.Add(new DataColumn() { ColumnName = "Pavarde" });
            lDT.Columns.Add(new DataColumn() { ColumnName = "Dalykas" });
            lDT.Columns.Add(new DataColumn() { ColumnName = "Lygis" });
            if (isConnected())
            {
                MySqlCommand cmd = new MySqlCommand(query2, conn);
                MySqlDataReader rd = cmd.ExecuteReader();
                //int i = 0;
                while (rd.Read())
                {
                    var row = lDT.NewRow();
                    studentidentification = Convert.ToInt32(rd[0].ToString());
                    row["ID"] = studentidentification;
                    row["Vardas"] = rd[1].ToString();
                    row["Pavarde"] = rd[2].ToString();
                    dalykas = rd[3].ToString();
                    row["Lygis"] = Convert.ToInt32(rd[4].ToString());
                    //groupname = getGroupName(groupidentification);
                    row["Dalykas"] = dalykas;
                    lDT.Rows.Add(row);
                    //rd2.Close();

                }
            }
            dataGridView2.DataSource = lDT;
        }
        void fillGroupTable()
        {
            var gDT = new DataTable();
            gDT.Columns.Add(new DataColumn() { ColumnName = "ID" });
            gDT.Columns.Add(new DataColumn() { ColumnName = "Grupe" });
            string query2 = "SELECT * FROM grupe";
            if (isConnected())
            {
                MySqlCommand cmd = new MySqlCommand(query2, conn);
                MySqlDataReader rd = cmd.ExecuteReader();
                //int i = 0;
                while (rd.Read())
                {
                    var row = gDT.NewRow();
                    row["ID"] = Convert.ToInt32(rd[0].ToString());
                    row["Grupe"] = rd[1].ToString();
                    gDT.Rows.Add(row);
                }
            }
            dataGridView3.DataSource = gDT;
        }
        private void IstrintiStudentabutton_Click(object sender, EventArgs e)
        {
            new IstrintiStudentaForm().Show();
        }

        private void IvestiStudentabutton_Click(object sender, EventArgs e)
        {
            new AddStudentForm().Show();
        }

        private void IvestiDestytojabutton_Click(object sender, EventArgs e)
        {
            new AddLecturerForm().Show();
        }

        private void IstrintiDestytojabutton_Click(object sender, EventArgs e)
        {
            new DeleteLecturerForm().Show();
        }

        private void IvestiGrupebutton_Click(object sender, EventArgs e)
        {
            new AddGroup().Show();
        }

        private void IstrintiGrupebutton_Click(object sender, EventArgs e)
        {
            new DeleteGroup().Show();
        }
    }
}
