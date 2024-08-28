using LoginManager.Context;
using MetroFramework.Forms;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMSV2._0
{
    public partial class Login : MetroForm
    {
        public Login()
        {
            InitializeComponent();
            CenterToScreen();
        }
        LoginManagerContext loginContext = new LoginManagerContext();
        private void signinButton_Click(object sender, EventArgs e)
        {
            //try
            //{
                if (verifier("frontend".Trim(), usernameTextBox.Text.Trim(), passwordTextBox.Text.Trim()))
                {
                    this.Hide();
                    Frontend hotel_management = new Frontend();
                    hotel_management.Show();
                }
                else if (verifier("kitchen".Trim(), usernameTextBox.Text.Trim(), passwordTextBox.Text.Trim()))
                {

                    this.Hide();
                    Kitchen kitchen_management = new Kitchen();
                    kitchen_management.Show();
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "Username or Password is wrong, try again", "Login Failed", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }
            //}
            //catch (Exception ex)
            //{
            //MetroFramework.MetroMessageBox.Show(this, ex.ToString(), "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            //}
        }

        private void usernameTextBox_Click(object sender, EventArgs e)
        {

            if (usernameTextBox.Text == string.Empty)
            {
                usernameLabel.Visible = true;
            }
            if (usernameTextBox.Text != "Username" && usernameTextBox.Text != string.Empty)
            {
                usernameLabel.Visible = false;
            }
        }
        private void passwordTextBox_Click(object sender, EventArgs e)
        {

            if (passwordTextBox.Text == string.Empty)
            {
                passwordLabel.Visible = true;
            }
            if (passwordTextBox.Text != "Password" && passwordTextBox.Text != string.Empty)
            {
                passwordLabel.Visible = false;
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (!usernameLabel.Bounds.Contains(e.Location) && usernameTextBox.Text == string.Empty)
            {
                usernameLabel.Visible = false;
            }
            if (!passwordLabel.Bounds.Contains(e.Location) && passwordTextBox.Text == string.Empty)
            {
                passwordLabel.Visible = false;
            }

        }

        public bool verifier(string tableName, string username, string password)
        {
            bool success = false;
            //SqlConnection connection = new SqlConnection("Data Source=DESKTOP-G3N1PK3\\SQLEXPRESS;Initial Catalog=HMSLoginManager;Integrated Security=True;Encrypt=False;");
            //string sql = "SELECT* FROM " + tableName + " WHERE username=@userName AND password=@password";
            try
            {
                //SqlCommand sqlCommand = new SqlCommand(sql, connection);
                //sqlCommand.CommandText = sql;
                //SqlParameter UsernameParametar = new SqlParameter("@username", SqlDbType.VarChar);
                //SqlParameter PassParametar = new SqlParameter("@password", SqlDbType.VarChar);
                //sqlCommand.Parameters.Add(UsernameParametar);
                //sqlCommand.Parameters.Add(PassParametar);
                //UsernameParametar.Value = username;
                //PassParametar.Value = password;
                //connection.Open();
                //SqlDataReader sqlReader = sqlCommand.ExecuteReader();
                //if (sqlReader.HasRows)
                switch (tableName)
                {
                    case "frontend":
                        loginContext.Frontend.Load();
                        var frontendLogin = loginContext.Frontend.Where(U => U.Username == username && U.Password == password).FirstOrDefault();
                        Debug.WriteLine(frontendLogin is not null ? $"Frontend Username: {frontendLogin.Username} || Password: {frontendLogin.Password}" : "Null Frontend");
                        success = frontendLogin != null;
                        break;
                    case "kitchen":
                        loginContext.Kitchen.Load();
                        //use var or Frontend ?
                        var kitchenLogin = loginContext.Kitchen.Where(U => U.Username == username && U.Password == password).FirstOrDefault();
                        Debug.WriteLine(kitchenLogin is not null ? $"Kitchen Username: {kitchenLogin.Username} || Password: {kitchenLogin.Password}" : "Null Frontend");
                        success = kitchenLogin != null;
                        break;
                }
                //connection.Close();
            }
            catch (Exception e)
            {
                MetroFramework.MetroMessageBox.Show(this, e.ToString(), "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            return success;
        }

        private void login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
            loginContext.Dispose();
        }

        private void LicenseCallButton_Click(object sender, EventArgs e)
        {
            License open_license = new License();
            open_license.ShowDialog();
        }
    }
}
