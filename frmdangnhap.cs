using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using System.Data.SqlClient;
using DTO;
using BLL;
using DTO.Common;

namespace quanlykhachsan
{
    public partial class frmdangnhap : Form
    {
        public frmdangnhap()
        {
            InitializeComponent();
        }

        private void btndangnhap_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(@"Data Source=WINDOWS-11;Initial Catalog=QLKHACHSAN;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter($"Select * from [dbo].[nguoidung] where taiKhoan = '{txttaikhoan.Text}' and matKhau = '{ txtmatkhau.Text}'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                var nguoiDung = new NguoiDungDTO()
                {
                    TaiKhoan = $"{dt.Rows[0]["taiKhoan"]}",
                    MatKhau = $"{dt.Rows[0]["matKhau"]}",
                    PhanQuyen = $"{dt.Rows[0]["phanQuyen"]}",
                    maNhanVien = int.Parse($"{dt.Rows[0]["maNhanVien"]}")
                };
                var nhanVien = new nhanvienBLL();
                CommonInfo.ThongTinNhanVien = nhanVien.TimNhanVien(nguoiDung.maNhanVien);
                MessageBox.Show("Chúc mừng bạn đã đăng nhập thành công. Phiền bạn xác nhận OK để vào hệ thống!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Hide(); // Form Đăng Nhập sẽ ẩn đi => Form chính sẽ load lên
                frmmainquanlykhachsan frm = new frmmainquanlykhachsan(nguoiDung);             
                frm.Show();
            }
            else
            if (cbkhach.Checked == true)
            {
                trangthai(false);   
                this.Hide(); // Form Đăng Nhập sẽ ẩn đi => Form chính sẽ load lên
                frmthongtinpphongkh frm = new frmthongtinpphongkh(); //Chỉ xem được thông tin phòng             
                frm.Show();
                MessageBox.Show("Chào mừng khách hàng đã đăng nhập vào hệ thống. Chúc quý khách ngày mới vui vẻ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {                  
                    MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác. Bạn vui lòng nhập lại tài khoản và mật khẩu!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
           
        }
        private void trangthai( bool t)
        {
            txttaikhoan.Enabled = t;
            txtmatkhau.Enabled = t;
        }

        private void frm_load(object sender, EventArgs e)
        {
          
        }

        private void cbkhach_CheckedChanged(object sender, EventArgs e)
        {
            if (cbkhach.Checked == true)
            {
                trangthai(false);
                txtmatkhau.Clear();
                txttaikhoan.Clear();
            }
            else
            {
                trangthai(true);
            }
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            Application.Exit(); ;
        }

        private void txtmatkhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btndangnhap_Click(sender, e);
            }

        }
    }
}
