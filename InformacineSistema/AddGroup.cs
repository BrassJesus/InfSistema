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
    public partial class AddGroup : Form
    {
        private MySqlConnection conn;
        private string server;
        private string username;
        private string password;
        private string database;

        public AddGroup()
        {
            InitializeComponent();
            server = "localhost";
            username = "root";
            password = "";
            database = "sistema";
            string ConnStr = "Server=" + server + ";" + "Database= " + database + ";" + "UID=" + username + ";" + "Password=" + password + ";";
            conn = new MySqlConnection(ConnStr);
            getAvailableLecturers();
        }

        private void label1_Click(object sender, EventArgs e)
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

        public void getAvailableLecturers()
        {
            string name;
            string surname;
            string query = "SELECT * FROM destytojas";
            if (isConnected())
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    name = rd[1].ToString();
                    surname = rd[2].ToString();
                    destytojoBox.Items.Add(name + " " + surname);
                }
                rd.Close();
            }
        }
        public void addGroup()
        {
            string groupname = groupNameBox.Text;
            string fullname = destytojoBox.Text;
            string[] half = fullname.Split();
            string name = half[0];
            string surname = half[1];
            int group_id = 0;
            int lecturer_id = 0;
            if (isConnected())
            {
                string query = "INSERT INTO grupe(grupes_pavadinimas) VALUES(@param1) ";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("param1", groupname);
                cmd.ExecuteNonQuery();
                query = "SELECT id FROM grupe WHERE grupes_pavadinimas = '" + groupname + "';";
                cmd = new MySqlCommand(query, conn);
        
                MySqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    group_id = Convert.ToInt32(rd[0].ToString());
                    rd.Close();
                }
                query = "SELECT id FROM destytojas WHERE (vardas = '" + name + "' AND pavarde ='" + surname + "');";
                cmd = new MySqlCommand(query, conn);
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    lecturer_id = Convert.ToInt32(rd[0].ToString());
                    rd.Close();
                }
                query = "INSERT INTO grupes_destytojai(grupes_id,destytojo_id) VALUES(@param1,@param2)";
                cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("param1", group_id);
                cmd.Parameters.AddWithValue("param2", lecturer_id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Grupe ideta");
            }
            }

        private void irasytiGrupe_Click(object sender, EventArgs e)
        {
            addGroup();
        }
    }
}
