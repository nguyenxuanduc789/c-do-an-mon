using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace WEATHER
{
  
    public partial class Forget : Form
    {
        private const String URI = "http://localhost:3000/Teacher/";
        public Forget()
        {
            InitializeComponent();
        }
        // form load
        private void Forget_Load(object sender, EventArgs e)
        {
           GetAll();

        }
        // đẩy dự liệu lên text box khi người dùng forget
        private void GetAll()
        {
            try
            {
                int code = int.Parse(txtID.Text.Trim());
                WebClient Clien = new WebClient();
                String json = Clien.DownloadString(URI + code);
                Teachers Teacher = JsonConvert.DeserializeObject<Teachers>(json);
                if (Teacher != null)
                {
                    txtID.Text = Teacher.id.ToString();
                    txtName.Text = Teacher.name;
                    cbmPosition.Text = Teacher.position;
                    txtPass.Text = Teacher.password;
                    txtEmail.Text = Teacher.email;
                }
            }
            catch 
            {

                MessageBox.Show("Mời bạn nhập MSGV để hiện mật khẩu");
            }
        }
        // thêm mới tài khoản
        private void btnChange_Click(object sender, EventArgs e)
        {
            /*
             * check người dụng nhập id
             * dùng PUT để đẩy dự liệu mới lên khi người dùng nhấn update lại mật khẩu (UploadString)
             * parse đẩy dự liệu từ text box sang json
             */
            if (txtPass.Text == "")
            {
                MessageBox.Show("Thông tin mật khẩu không được để trống");
                txtPass.Focus();
            }
            else 
            {
                try
                {
                    Teachers newSt = new Teachers()
                    {
                        name = txtName.Text.Trim(),
                        id = int.Parse(txtID.Text.Trim()),
                        position = cbmPosition.Text.Trim(),
                        password = txtPass.Text.Trim(),
                        email = txtEmail.Text.Trim(),
                    };
                    String data = JsonConvert.SerializeObject(newSt);
                    WebClient Clien = new WebClient();
                    Clien.Headers[HttpRequestHeader.ContentType] = "application/json";
                    String response = Clien.UploadString(URI + newSt.id, "PUT", data);
                    if (response != null)
                    {
                        GetAll();
                        MessageBox.Show("Bạn đã đổi mật khẩu thành công !");

                    }
                    else MessageBox.Show("Dữ liệu không có !");
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }
        // btn check gmail để đã đăng kí chưa
        private void btnForget_Click(object sender, EventArgs e)
        {
            /*
             * kiểm tra người dùng đã nhập id chưa
             dùng HTPP GET (DownloadString) hiện lại password cũ trên text box
             */
            if (txtID.Text == "")
            {
                MessageBox.Show("Thông tin mã giáo viên để tìm kiếm không được để trống!");
                txtID.Focus();
            }
            else
            {
                try
                {
                    int code = int.Parse(txtID.Text.Trim());
                    WebClient Clien = new WebClient();
                    String json = Clien.DownloadString(URI + code);
                    Teachers Teacher = JsonConvert.DeserializeObject<Teachers>(json);
                    if (Teacher != null)
                    {
                        txtID.Text = Teacher.id.ToString();
                        txtName.Text = Teacher.name;
                        cbmPosition.Text = Teacher.position;
                        txtPass.Text = Teacher.password;
                        txtEmail.Text = Teacher.email;
                    }
                }
                catch 
                {

                    MessageBox.Show("Không tìm thấy thông tin mã giáo viên !!");
                }
            }
            
        }
        // btn thoát
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn có muốn đóng cửa sổ này không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
