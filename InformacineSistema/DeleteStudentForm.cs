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
    public partial class IstrintiStudentaForm : Form
    {
        private MySqlConnection conn;
        private string server;
        private string username;
        private string password;
        private string database;
        public IstrintiStudentaForm()
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

        private void IstrintiStudentaForm_Load(object sender, EventArgs e)
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
        public void getAvailableID()
        {
            string query = "SELECT * FROM studentas";
            if (isConnected())
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    IDbox.Items.Add(rd[0].ToString());
                }
                rd.Close();
            }
        }

        public void deleteStudent()
        {
            int id = Convert.ToInt32(IDbox.Text);
            int dalyko_id=0;
            if (isConnected())
            {
                string query = "SELECT id FROM studentu_dalykai WHERE studento_id = '" + id + "';";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    dalyko_id = Convert.ToInt32(rd[0].ToString());
                    rd.Close();
                }
                query = "DELETE FROM studentas WHERE id = '" + id + "';";
                cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                query = "DELETE FROM studentu_dalykai WHERE id = '" + dalyko_id + "';";
                cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Studentas istrintas");
            }
        }

        private void DeleteStudentbutton_Click(object sender, EventArgs e)
        {
            deleteStudent();
        }
    }
}
