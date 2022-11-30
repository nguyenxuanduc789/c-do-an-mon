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

namespace WEATHER
{
    public partial class Teacher : Form
    {
        private const String URI = "http://localhost:3000/student/";
        public Teacher()
        {
            InitializeComponent();
        }
        // form load
        private void Teacher_Load(object sender, EventArgs e)
        {
            GetAll();
        }
        // đẩy dự liệu lên datview
        private void GetAll()
        {
            WebClient Clien = new WebClient();
            String json = Clien.DownloadString(URI);
            List<Student> St = JsonConvert.DeserializeObject<List<Student>>(json);       
            dataGridView1.DataSource = St;
            dataGridView2.DataSource = St;

            clear();
        }
        // clear  text box
        private void clear()
        {
            txtid.Clear();
            txtname.Clear();
            txtdiem.Clear();
        }
        // Button  thêm mới  sinh viên
        private void btnadd_Click(object sender, EventArgs e)
        {
            if (txtid.Text!="" || txtdiem.Text == ""|| txtname.Text == "" || cbmkhoa.Text == "")
            {
                MessageBox.Show("Thông tin thay đổi không được để trống");
            }
            else
            {
                try
                {
                    /*
                     * lưu dữ liệu vào text box trước khi add vào api 
                     * dùng UploadString đẩy dự liệu lên 
                     * chuyển đổi đối tưởng string sang json
                     */
                    Student newBook = new Student()
                    {
                        name = txtname.Text.Trim(),
                        id = 0,
                        score = int.Parse(txtdiem.Text.Trim()),
                        faculty = cbmkhoa.Text.Trim(),
                        // gán định dạng password  khi đăng ki name là password dành cho sinh viên login
                        password = txtname.Text.Trim(),
                    };
                    String data = JsonConvert.SerializeObject(newBook);
                    WebClient Clien = new WebClient();
                    Clien.Headers[HttpRequestHeader.ContentType] = "application/json";
                    String response = Clien.UploadString(URI, "POST", data);
                    if (response == null)
                    {
                        MessageBox.Show("Dữ liệu không có");

                    }
                    else GetAll();
                }
                catch
                {
                    MessageBox.Show("Thông tin sinh vien tìm kiếm phải để trống!");
                }
            }           
        }
        //button update
        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (txtdiem.Text == "" || txtid.Text == "" || txtname.Text == "" || cbmkhoa.Text == "")
            {
                MessageBox.Show("Thông tin thay đổi không được để trống");
            }
            else
            {
                try
                {
                    /* lưu  dư liệu vào text box trước khi đưa lên api
                    dùng UploadString đẩy dự liệu lên
                     *chuyển đổi đối tưởng string sang json dự vào ID để sửa 
                     */
                    Student newSt = new Student()
                    {
                        name = txtname.Text.Trim(),
                        id = int.Parse(txtid.Text.Trim()),
                        faculty = cbmkhoa.Text.Trim(),
                        score = int.Parse(txtdiem.Text.Trim()),
                        // ấn chức năng thông tin sinh viên không cho giáo viên sửa
                        date = txtDate.Text.Trim(),
                        gender = cbmgt.Text.Trim(),
                        address = txtdt.Text.Trim(),
                        email = txtmail.Text.Trim(),
                        password = txtpw.Text.Trim(),
                    };
                    String data = JsonConvert.SerializeObject(newSt);
                    WebClient Clien = new WebClient();
                    Clien.Headers[HttpRequestHeader.ContentType] = "application/json";
                    String response = Clien.UploadString(URI + newSt.id, "PUT", data);
                    if (response == null)
                    {
                        MessageBox.Show("Dữ liệu không có");

                    }
                    else GetAll();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
          
        }
        // Button delete 
        private void btndl_Click(object sender, EventArgs e)
        {
            /*
             * truyền id vào text box dự vào id mà xóa đối tưởng 
             */
            if (txtid.Text == "")
            {
                MessageBox.Show("Thông tin mã sinh vien xóa không được để trống");
            }
            else
            {
                try
                {
                    int code = int.Parse(txtid.Text.Trim());
                    WebClient Clien = new WebClient();
                    Clien.Headers[HttpRequestHeader.ContentType] = "application/json";
                    String response = Clien.UploadString(URI + code, "DELETE", "");

                    if (response == null)
                    {
                        MessageBox.Show("Dữ liệu không có");

                    }
                    else GetAll();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }
        //button search 
        private void btnsearch_Click(object sender, EventArgs e)
        {
            /*
             truyền id vào text box trước khi đây lên api 
            dùng DownloadString để HTTP get  gọi đối tượng dựa vào id 
            Parse sang định dạng string trước khi đưa lên dataview
             */
            if (txtid.Text == "")
            {
                MessageBox.Show("Thông tin mã sinh vien tìm kiếm không được để trống");
            }
            else
            {
                try
                {
                    int code = int.Parse(txtid.Text.Trim());
                    WebClient Clien = new WebClient();
                    String json = Clien.DownloadString(URI + code);
                    Student Students = JsonConvert.DeserializeObject<Student>(json);
                    if (Students != null)
                    {
                        dataGridView2.Rows[0].Cells["id"].Value = Students.id.ToString();
                        dataGridView2.Rows[0].Cells["name"].Value = Students.name;
                        dataGridView2.Rows[0].Cells["faculty"].Value = Students.faculty;
                        dataGridView2.Rows[0].Cells["date"].Value = Students.date;
                        dataGridView2.Rows[0].Cells["gender"].Value = Students.gender;
                        dataGridView2.Rows[0].Cells["address"].Value = Students.address;
                        dataGridView2.Rows[0].Cells["score"].Value = Students.score.ToString();
                        dataGridView2.Rows[0].Cells["email"].Value = Students.email;
                        dataGridView2.Rows[0].Cells["password"].Value = Students.password;
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }

        }
        // dùng dataview SelectedRows cho người dùng click chuột vào đối tưởng để bắn lên text box
        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                /*
                 * kiểm tra dữ liệu  có không 
                 * chọn côt đầy tiên dự vào id để HTPP GET rối truyền dự liệu từ dataview lên text box
                 */
                if (dataGridView2.SelectedRows.Count > 0)
                {
                    int code = int.Parse(dataGridView2.SelectedRows[0].Cells["id"].Value.ToString());
                    WebClient Clien = new WebClient();
                    String json = Clien.DownloadString(URI + code);
                    Student books = JsonConvert.DeserializeObject<Student>(json);
                    if (books != null)
                    {
                        txtid.Text = books.id.ToString();
                        txtname.Text = books.name;
                        cbmkhoa.Text = books.faculty;
                        txtDate.Text = books.date;
                        cbmgt.Text = books.gender;
                        txtdt.Text = books.address;
                        txtmail.Text = books.email;
                        txtpw.Text = books.password;
                        txtdiem.Text = books.score.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // Các chức năng icon trong Menu strip 
        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRegister frm = new frmRegister();
            frm.ShowDialog();
            this.Close();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forget frm = new Forget();
            frm.ShowDialog();
            this.Close();
        }

        private void existToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn có muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
