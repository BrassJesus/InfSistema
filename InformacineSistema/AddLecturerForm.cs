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
    public partial class AddLecturerForm : Form
    {
        private MySqlConnection conn;
        private string server;
        private string username;
        private string password;
        private string database;
        public AddLecturerForm()
        {
            server = "localhost";
            username = "root";
            password = "";
            database = "sistema";
            string ConnStr = "Server=" + server + ";" + "Database= " + database + ";" + "UID=" + username + ";" + "Password=" + password + ";";
            conn = new MySqlConnection(ConnStr);
            InitializeComponent();
            getAvailableGroup();
        }

        private void label3_Click(object sender, EventArgs e)
        {

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

        private void Ivedimobutton_Click(object sender, EventArgs e)
        {
            string name = vardoBox.Text;
            string surname = pavardesBox.Text;
            string dalykas = dalykoBox.Text;
            string grupe = grupesBox.Text;
            int lygis = 20;
            int group_id = 0;
            int destytojo_id = 0;
            if (isConnected())
            {
                string query = "SELECT id FROM grupe WHERE grupes_pavadinimas = '" + grupe + "';";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    group_id = Convert.ToInt32(rd[0].ToString());
                    rd.Close();
                }
                query = "INSERT INTO destytojas(vardas,pavarde,dalykas,lygis) VALUES (@param1,@param2,@param3,@param4)";
                cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("param1", name);
                cmd.Parameters.AddWithValue("param2", surname);
                cmd.Parameters.AddWithValue("param3", dalykas);
                cmd.Parameters.AddWithValue("param4", lygis);
                cmd.ExecuteNonQuery();
                query = "SELECT id FROM destytojas WHERE (vardas = '" + name + "' AND pavarde ='" + surname + "');";
                cmd = new MySqlCommand(query, conn);
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    destytojo_id = Convert.ToInt32(rd[0].ToString());
                    rd.Close();
                }
                query = "INSERT INTO grupes_destytojai(grupes_id,destytojo_id) VALUES (@param1, @param2)";
                cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@param1", group_id);
                cmd.Parameters.AddWithValue("@param2", destytojo_id);
                cmd.ExecuteNonQuery();
                query = "INSERT INTO dalykas(dalykas,pazymys) VALUES (@param1,@param2)";
                cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@param1", dalykas);
                cmd.Parameters.AddWithValue("@param2", 1);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Destytojas Ivestas");
            }
        }
    }
}
