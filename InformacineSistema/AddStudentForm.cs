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
    public partial class AddStudentForm : Form
    {
        private MySqlConnection conn;
        private string server;
        private string username;
        private string password;
        private string database;
        public IUser User;
        public AddStudentForm()
        {
            server = "localhost";
            username = "root";
            password = "";
            database = "sistema";
            string ConnStr = "Server=" + server + ";" + "Database= " + database + ";" + "UID=" + username + ";" + "Password=" + password + ";";
            conn = new MySqlConnection(ConnStr);
            InitializeComponent();
            getAvailableGroup();
            getAvailableLectures();
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
        public void getAvailableGroup()
        {
            string query = "SELECT * FROM grupe";
            if (isConnected())
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    grupesBox.Items.Add(rd[1].ToString());
                }
                rd.Close();
            }
        }
        public void getAvailableLectures()
        {
            string query = "SELECT * FROM destytojas";
            if (isConnected())
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                   dalykoBox.Items.Add(rd[3].ToString());
                }
                rd.Close();
            }
        }

        private void Ivedimobutton_Click(object sender, EventArgs e)
        {
            string name = vardoTextBox.Text;
            string surname = pavardesTextBox.Text;
            string groupname = grupesBox.Text;
            string lecturename = dalykoBox.Text;
            int lygis = 10;
            int groupid=0;
            int lectureid=0;
            int studentid = 0;
            if (isConnected())
            {
                string query = "SELECT id FROM grupe WHERE grupes_pavadinimas = '" + groupname + "';";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    groupid = Convert.ToInt32(rd[0].ToString());
                    rd.Close();
                }
                query = "INSERT INTO studentas(vardas,pavarde,grupes_id,lygis) VALUES (@param1,@param2,@param3,@param4)";
                cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("param1", name);
                cmd.Parameters.AddWithValue("param2", surname);
                cmd.Parameters.AddWithValue("param3", groupid);
                cmd.Parameters.AddWithValue("param4", lygis);
                cmd.ExecuteNonQuery();
                query = "SELECT id FROM studentas WHERE (vardas = '" + name + "' AND pavarde ='" + surname + "');";
                cmd = new MySqlCommand(query, conn);
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    studentid = Convert.ToInt32(rd[0].ToString());
                    rd.Close();
                }
                query = "SELECT id FROM dalykas WHERE dalykas ='" + lecturename + "';";
                cmd = new MySqlCommand(query, conn);
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    lectureid = Convert.ToInt32(rd[0].ToString());
                    rd.Close();
                }
                query = "INSERT INTO studentu_dalykai(studento_id,dalyko_id) VALUES (@param1, @param2)";
                cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@param1", studentid);
                cmd.Parameters.AddWithValue("@param2", lectureid);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Studentas Ivestas");
            }
        }

        private void AddStudentForm_Load(object sender, EventArgs e)
        {

        }
    }
}
