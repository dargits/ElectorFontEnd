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

            // Sửa lỗi: dùng _userName và _password thay vì *userName và *password
            _userName = _userName.Trim();
            _password = _password.Trim();

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

                    // Lưu thông tin đăng nhập vào file
                    if(cbKeepLogin.Checked)
                    {
                        await SaveLoginInfoToFile(_userName, _password);
                    }
                    else
                    {
                        await SaveLoginInfoToFile("", "");
                    }
                        rmShowMess();

                    if (user.IsAdmin == false)
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

        // Thêm method SaveLoginInfoToFile
        private async Task SaveLoginInfoToFile(string username, string password)
        {
            try
            {
                // Đường dẫn đến file login.txt có sẵn (cùng cấp với Program.cs)
                string filePath = @"C:\winApi\Elector\login.txt";

                // Tạo nội dung để ghi
                string loginInfo = $"Username: {username}\nPassword: {password}";

                // Ghi vào file có sẵn
                await File.WriteAllTextAsync(filePath, loginInfo, Encoding.UTF8);

                Console.WriteLine("Đã lưu thông tin đăng nhập vào login.txt");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi ghi file: {ex.Message}");
            }
        }
        private void viewPass_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = viewPass.Checked ? '\0' : '*';
        }

        // Cách 2: Dùng synchronous method (không async)
        private void Login_Load(object sender, EventArgs e)
        {
            try
            {
                // Đường dẫn đến file login.txt có sẵn
                string filePath = @"C:\winApi\Elector\login.txt";

                // Kiểm tra file có tồn tại không
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("File login.txt không tồn tại");
                    return;
                }

                // Đọc nội dung file (synchronous)
                string content = File.ReadAllText(filePath, Encoding.UTF8);
                string[] lines = content.Split('\n');

                string username = string.Empty;
                string password = string.Empty;

                foreach (string line in lines)
                {
                    if (line.StartsWith("Username: "))
                        username = line.Substring("Username: ".Length).Trim();
                    else if (line.StartsWith("Password: "))
                        password = line.Substring("Password: ".Length).Trim();
                }

                txtUsername.Text = username;
                txtPassword.Text = password;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi đọc file: {ex.Message}");
            }
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
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