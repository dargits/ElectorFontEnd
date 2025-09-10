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
    public partial class Register : Form
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public Register()
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

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            string _userName = txtUsername.Text;
            string _password = txtPassword.Text;
            string _fullName = txtFullName.Text;
            btnRegister.BackColor = Color.Green;


            // Kiểm tra thông tin đầu vào
            if (String.IsNullOrEmpty(_userName) || String.IsNullOrEmpty(_password) || String.IsNullOrEmpty(_fullName))
            {
                backgrPanel.Visible = true;
                showmessage.Visible = true;
                showmessage.Text = "Vui lòng nhập đầy đủ thông tin.";
                await Task.Delay(3000);
                rmShowMess();
                btnRegister.BackColor = Color.Blue;
                return;
            }
            _userName = _userName.Trim();
            _password = _password.Trim();

            try
            {
                // Tạo request
                var registerRequest = new
                {
                    username = _userName,
                    password = _password,
                    fullName = _fullName
                };
                string jsonContent = JsonConvert.SerializeObject(registerRequest);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                // Gọi API
                HttpResponseMessage response = await httpClient.PostAsync($"{Domain.name}/api/users/register", content);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    var user = JsonConvert.DeserializeObject<User>(responseContent);

                    backgrPanel.Visible = true;
                    showmessage.Visible = true;
                    backgrPanel.BackColor = Color.Green;
                    showmessage.Text = "Đăng ký thành công!";
                    await Task.Delay(3000);
                    rmShowMess();
                    btnRegister.BackColor = Color.Blue;
                    return;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
                {
                    backgrPanel.Visible = true;
                    showmessage.Visible = true;
                    showmessage.Text = "Tài khoản đã tồn tại!";
                    await Task.Delay(3000);
                    rmShowMess();
                    btnRegister.BackColor = Color.Blue;
                    return;
                }
                else
                {
                    backgrPanel.Visible = true;
                    showmessage.Visible = true;
                    showmessage.Text = "Đăng ký thất bại!";
                    await Task.Delay(3000);
                    rmShowMess();
                    btnRegister.BackColor = Color.Blue;
                    return;
                }
            }
            catch (Exception ex)
            {
                backgrPanel.Visible = true;
                showmessage.Visible = true;
                showmessage.Text = $"Lỗi: {ex.Message}";
                await Task.Delay(3000);
                rmShowMess();
                btnRegister.BackColor = Color.Blue;
                return;
            }
            finally
            {
                await Task.Delay(2000);
                btnRegister.BackColor = Color.Blue;
            }
        }

        private void viewPass_CheckedChanged(object sender, EventArgs e)
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

        public void closeApp(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Form login = new Auth.Login();
            this.Hide();
            login.Show();
        }

        private void Register_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }


}