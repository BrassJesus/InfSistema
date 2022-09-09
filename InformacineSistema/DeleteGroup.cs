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
    public partial class DeleteGroup : Form
    {

        private MySqlConnection conn;
        private string server;
        private string username;
        private string password;
        private string database;
        public DeleteGroup()
        {
            server = "localhost";
            username = "root";
            password = "";
            database = "sistema";
            string ConnStr = "Server=" + server + ";" + "Database= " + database + ";" + "UID=" + username + ";" + "Password=" + password + ";";
            conn = new MySqlConnection(ConnStr);
            InitializeComponent();
            getAvailableID();
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
        public void getAvailableID()
        {
            string query = "SELECT * FROM grupe";
            if (isConnected())
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    IDBox.Items.Add(rd[0].ToString());
                }
                rd.Close();
            }
        }
        public void deleteGroup()
        {
            int id = Convert.ToInt32(IDBox.Text);
            int grupes_id = 0;
            if (isConnected())
            {
                string query = "SELECT id FROM grupes_destytojai WHERE grupes_id = '" + id + "';";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    grupes_id = Convert.ToInt32(rd[0].ToString());
                    rd.Close();
                }
                query = "DELETE FROM grupe WHERE id = '" + id + "';";
                cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                query = "DELETE FROM grupes_destytojai WHERE id = '" + grupes_id + "';";
                cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Grupe istrinta");

            }
        }

        private void trintiGrupebutton_Click(object sender, EventArgs e)
        {
            deleteGroup();
        }
    }
}
