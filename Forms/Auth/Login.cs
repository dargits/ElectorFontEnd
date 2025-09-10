using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;

namespace Elector.Forms.Auth
{
    public partial class Login : Form
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public Login()
        {
            InitializeComponent();
        }

        public void rmShowMess()
        {
            backgrPanel.Visible = false;
            showmessage.Visible = false;
            backgrPanel.BackColor = Color.DarkRed;
            showmessage.Text = "";
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string _userName = txtUsername.Text;
            string _password = txtPassword.Text;

            if (String.IsNullOrEmpty(_userName) || String.IsNullOrEmpty(_password))
            {
                backgrPanel.Visible = true;
                showmessage.Visible = true;
                showmessage.Text = "Vui lòng nhập đầy đủ thông tin.";
                await Task.Delay(3000);
                rmShowMess();
                return;
            }

            try
            {
                // Tạo request
                var loginRequest = new { username = _userName, password = _password };
                string jsonContent = JsonConvert.SerializeObject(loginRequest);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                // Gọi API
                HttpResponseMessage response = await httpClient.PostAsync($"{Domain.name}/api/users/login", content);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    var user = JsonConvert.DeserializeObject<User>(responseContent);

                    UserSession.Login(user);
                    backgrPanel.Visible = true;
                    showmessage.Visible = true;
                    backgrPanel.BackColor = Color.Green;
                    showmessage.Text = "Đăng nhập thành công.!";
                    rmShowMess();
                    if(user.IsAdmin ==  false)
                    {
                        Form home = new Forms.Home();
                        this.Hide();
                        home.Show();
                    }
                    else
                    {
                        Form admin = new Forms.AdminPanel(); 
                        this.Hide();
                        admin.Show();
                    }
                        return;
                }
                else
                {
                    backgrPanel.Visible = true;
                    showmessage.Visible = true;
                    showmessage.Text = "Đăng nhập thất bại!";
                    await Task.Delay(3000);
                    rmShowMess();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }

        private void Hiee_CheckedChanged(object sender, EventArgs e)
        {
            if (viewPass.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
        }
        public void closeApp(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form register = new Auth.Register();
            this.Hide();
            register.Show();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }

    public class User
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("isAdmin")]
        public bool IsAdmin { get; set; }
    }
}