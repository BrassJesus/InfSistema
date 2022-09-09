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
    public partial class LoginForm : Form
    {
        private MySqlConnection conn;
        private string server;
        private string username;
        private string password;
        private string database;


        public LoginForm()
        {
            server = "localhost";
            username = "root";
            password = "";
            database = "sistema";
            string ConnStr = "Server=" + server + ";" + "Database= " + database + ";" + "UID=" + username + ";" + "Password=" + password + ";";
            conn = new MySqlConnection(ConnStr);
            InitializeComponent();


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

        public int isStudent(string username, string password)
        {
            int lygis;
            lygis = 10;
            string query = "SELECT * FROM studentas WHERE vardas = '" + username + "'";
            try
            {
                if (isConnected())
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        if (rd[2].ToString() == password && rd[4].ToString() == lygis.ToString())
                        {
                            rd.Close();
                            return 10;
                        }
                        else
                        {
                            rd.Close();
                            return 1000;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                return 1000;
            }
            return 1000;
        }
        public int isLecturer(string username, string password)
        {
            int lygis;
            lygis = 20;
            string query = "SELECT * FROM destytojas WHERE vardas = '" + username + "'";
            try
            {

                if (isConnected())
                {
                    //MessageBox.Show("DARAU CIA DALYKUS");
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        if (rd[2].ToString() == password && rd[4].ToString() == lygis.ToString())
                        {
                            //MessageBox.Show(rd[2].ToString());
                           // MessageBox.Show(rd[4].ToString());
                            rd.Close();
                            return 20;
                        }
                        else
                        {
                            rd.Close();
                            return 1000;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                return 1000;
            }
            return 1000;
        }
/*
        public int CheckUser(string username, string password)
        {
            int lygis;
            string query = "SELECT * FROM studentas WHERE vardas = '" + username + "'";
            string query2 = "SELECT * FROM destytojas WHERE vardas = '" + username + "'";
            //string query3 = "INSERT INTO studentas(vardas, pavarde, grupes_id,lygis) VALUES('bruh','bruh','1','10');";
            try
            {
                if (isConnected())
                {

                    //MessageBox.Show("visksgerai");
                   //conn.Open();
                   // MySqlCommand cmd3 = new MySqlCommand(query3, conn);
                    //int value = cmd3.ExecuteNonQuery();
                    //MessageBox.Show(value.ToString());
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        if (rd[2].ToString() == password && rd[4].ToString() == lygis.ToString())
                        {
                            rd.Close();
                            return 10;
                        }
                    }
                    MySqlCommand cmd2 = new MySqlCommand(query2, conn);
                    MySqlDataReader rd2 = cmd2.ExecuteReader();
                    lygis = 20;
                    while (rd2.Read())
                    {
                        if (rd2[2].ToString() == password && rd2[4].ToString() == lygis.ToString())
                        {
                            rd2.Close();
                            return 20;
                        }
                        else
                        {
                            rd2.Close();
                            return 30;
                        }
                        
                    }
                }    
            }
            catch(Exception ex)
            {
                return 1000;
            }
            return 1000;

        }
*/
        public string whatgroup(int group_id)
        {
            string grupe;
            string query = "SELECT * FROM grupe WHERE id = '" + group_id + "'";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader rd3 = cmd.ExecuteReader();
            if (rd3.Read())
            {
                grupe = rd3[1].ToString();
                rd3.Close();
                return grupe;
            }
            rd3.Close();
            return "ERROR";
        }
        private void LoginForm_Load(object sender, EventArgs e)
        {
        }

        public void button1_Click(object sender, EventArgs e)          //EXIT BUTTON
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)       //LOGIN BUTTON
        {
            int lygis1=1000;
            int lygis2=1000;
            int lygis3=1000;
            int group_id;
            IUser user = null;
            string username = usernamebox.Text;
            string password = passwordbox.Text;
            string query2 = $"SELECT * FROM destytojas WHERE vardas='{username}' AND pavarde='{password}';";
            string query = $"SELECT * FROM studentas WHERE vardas='{username}' AND pavarde='{password}';";
            lygis1 = isStudent(username, password);
            lygis2 = isLecturer(username, password);
            if (username == "admin" && password == "admin")
            {
                lygis3 = 30;
            }
            //MessageBox.Show(Convert.ToString(lygis1));
            //MessageBox.Show(Convert.ToString(lygis2));
            //MessageBox.Show(Convert.ToString(lygis3));
            //MessageBox.Show(username);
            //MessageBox.Show(password);
            if (lygis1 == 10 && isConnected())
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                   
                   // MessageBox.Show("STUDENTAS");
                    user = new Student();
                    user.ID = Convert.ToInt32(rd[0].ToString());
                    user.Name = rd[1].ToString();
                    user.Surname = rd[2].ToString();
                    group_id = Convert.ToInt32(rd[3].ToString());
                    rd.Close();
                    user.Group= whatgroup(group_id);
                    //MessageBox.Show(user.Group);
                    if (user.Group == "ERROR")
                    {
                        MessageBox.Show("ERROR READING STUDENT GROUP");

                    }
                    //StudentForm f2 = new StudentForm(user);
                    //f2.ShowDialog();

                    this.Hide();
                    new StudentForm(user).Show();
                    //this.Hide();
                }
            }
            if (lygis2 == 20 && isConnected())
            {
                MySqlCommand cmd2 = new MySqlCommand(query2, conn);
                MySqlDataReader rd2 = cmd2.ExecuteReader();
                if (rd2.Read())
                {
                    user = new Lecturer();
                    user.ID = Convert.ToInt32(rd2[0].ToString());
                    user.Name = rd2[1].ToString();
                    user.Surname = rd2[2].ToString();
                    user.Group = rd2[3].ToString();
                    rd2.Close();
                    this.Hide();
                    new LecturerForm(user).Show();
                    //MessageBox.Show("DESTYTOJAS");
                }
            }
            if (lygis3 == 30 && isConnected())
            {
                //MessageBox.Show("ADMIN");
                this.Hide();
                new AdminForm().Show();

                
            }
            if (lygis1 == 1000 && lygis2 == 1000 && lygis3 == 1000)
            {
                MessageBox.Show("SUM TING WONG");

            }
            conn.Close();
        }

    }
}