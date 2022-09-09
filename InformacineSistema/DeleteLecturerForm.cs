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
    public partial class DeleteLecturerForm : Form
    {
        private MySqlConnection conn;
        private string server;
        private string username;
        private string password;
        private string database;
        public DeleteLecturerForm()
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
            string query = "SELECT * FROM destytojas";
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
        public void deleteLecturer()
        {
            int id = Convert.ToInt32(IDBox.Text);
            int grupes_id = 0;
            string dalykas="";
            if (isConnected())
            {
                string query = "SELECT id FROM grupes_destytojai WHERE destytojo_id = '" + id + "';";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    grupes_id = Convert.ToInt32(rd[0].ToString());
                    rd.Close();
                }
                query = "SELECT dalykas FROM destytojas WHERE id = '" + id + "';";
                cmd = new MySqlCommand(query, conn);
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    dalykas = rd[0].ToString();
                    rd.Close();
                }
                query = "DELETE FROM destytojas WHERE id = '" + id + "';";
                cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                query = "DELETE FROM dalykas WHERE dalykas = '" + dalykas + "';";
                cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Destytojas istrintas");
            }
        }

        private void istrintiDestytojabutton_Click(object sender, EventArgs e)
        {
            deleteLecturer();
        }
    }
}
