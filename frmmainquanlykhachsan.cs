using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;

namespace quanlykhachsan
{
    public partial class frmmainquanlykhachsan : Form
    {
        public static int ChucVu = -1;
        public static string hoVaTen = "";
        public frmmainquanlykhachsan(NguoiDungDTO nguoiDung)
        {
            InitializeComponent();
            _NguoiDung = nguoiDung;
            PhanQuyen();
        }

        private NguoiDungDTO _NguoiDung { get; set; }

        private void PhanQuyen()
        {
            if (_NguoiDung.PhanQuyen == "admin")
            {
                QuanLy();
            }
            else
            {
                LeTan();
            }
        }

        public void ChuaDangNhap()
        {

            btnDangNhap.Enabled = true;
            btnBaoCao.Enabled = false;
            btnDichVu.Enabled = false;
            btnKhachHang.Enabled = false;
            btnLienHe.Enabled = true;
            btnNhanVien.Enabled = false;
            btnQLPhong.Enabled = false;
            btnTaiKhoan.Enabled = false;
            btnThoat.Enabled = true;
            btnThuePhong.Enabled = false;
            btnTroGiup.Enabled = true;
            btnTTHeThong.Enabled = true;
            btnDangXuat.Enabled = false;
            btnHoaDon.Enabled = false;

            mnubaocaothongke.Enabled = false;
            mnudangnhap.Enabled = true;
            mnudangxuat.Enabled = false;
            mnulienhe.Enabled = true;
            mnuquanlydichvu.Enabled = false;
            mnuquanlykhachhang.Enabled = false;
            mnuquanlynhanvien.Enabled = false;
            mnuquanlyphong.Enabled = false;
            mnuquanlytaikhoan.Enabled = false;
            mnuquanlythuephong.Enabled = false;
            mnutg.Enabled = true;
            mnuthoat.Enabled = true;
            mnuthongtinhethong.Enabled = true;           
            mnuthongtinhethong.Enabled = true;
            mnuHoaDon.Enabled = false;
        }

        public void QuanLy()
        {
            btnDangNhap.Enabled = false;
            btnBaoCao.Enabled = true;
            btnDichVu.Enabled = true;
            btnKhachHang.Enabled = true;
            btnLienHe.Enabled = true;
            btnNhanVien.Enabled = true;
            btnQLPhong.Enabled = true;
            btnTaiKhoan.Enabled = true;
            btnThoat.Enabled = true;
            btnThuePhong.Enabled = true;
            btnTroGiup.Enabled = true;
            btnTTHeThong.Enabled = true;
            btnDangXuat.Enabled = true;
            btnHoaDon.Enabled = true;

            mnubaocaothongke.Enabled = true;
            mnudangnhap.Enabled = false;
            mnudangxuat.Enabled = true;
            mnulienhe.Enabled = true;
            mnuquanlydichvu.Enabled = true;
            mnuquanlykhachhang.Enabled = true;
            mnuquanlynhanvien.Enabled = true;
            mnuquanlyphong.Enabled = true;
            mnuquanlytaikhoan.Enabled = true;
            mnuquanlythuephong.Enabled = true;
            mnutg.Enabled = true;
            mnuthoat.Enabled = true;
            mnuthongtinhethong.Enabled = true;          
            mnuthongtinhethong.Enabled = true;
            mnuHoaDon.Enabled = true;

            lblhienchucvu.Text = "Quản Lý: " + hoVaTen;
        }


        public void LeTan()
        {
            btnDangNhap.Enabled = false;
            btnBaoCao.Enabled = false;
            btnDichVu.Enabled = true;
            btnKhachHang.Enabled = true;
            btnLienHe.Enabled = true;
            btnNhanVien.Enabled = false;
            btnQLPhong.Enabled = false;
            btnTaiKhoan.Enabled = false;
            btnThoat.Enabled = true;
            btnThuePhong.Enabled = true;
            btnTroGiup.Enabled = true;
            btnTTHeThong.Enabled = true;
            btnDangXuat.Enabled = true;
            btnHoaDon.Enabled = true;

            mnubaocaothongke.Enabled = false;
            mnudangnhap.Enabled = false;
            mnudangxuat.Enabled = true;
            mnulienhe.Enabled = true;
            mnuquanlydichvu.Enabled = true;
            mnuquanlykhachhang.Enabled = true;
            mnuquanlynhanvien.Enabled = false;
            mnuquanlyphong.Enabled = false;
            mnuquanlytaikhoan.Enabled = false;
            mnuquanlythuephong.Enabled = true;
            mnutg.Enabled = true;
            mnuthoat.Enabled = true;
            mnuthongtinhethong.Enabled = true;          
            mnuthongtinhethong.Enabled = true;
            mnuHoaDon.Enabled = true;

            lblhienchucvu.Text = "Lễ Tân: " + hoVaTen;
        }

        private void frm_load(object sender, EventArgs e)
        {
            frmthuephong fTP = new frmthuephong();
            fTP.MdiParent = this;
            fTP.Show();
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            frmbaocao fBC = new frmbaocao();
            fBC.MdiParent = this;
            fBC.Show();
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            frmnhanvien fNV = new frmnhanvien();
            fNV.MdiParent = this;
            fNV.Show();
        }

        private void btnThuePhong_Click(object sender, EventArgs e)
        {
            frmthuephong fTP = new frmthuephong();
            fTP.MdiParent = this;
            fTP.Show();
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            frmkhachhang fKH = new frmkhachhang();
            fKH.MdiParent = this;
            fKH.Show();
        }

        private void btnQLPhong_Click(object sender, EventArgs e)
        {
            frmphong fP = new frmphong();
            fP.MdiParent = this;
            fP.Show();
        }


        private void btnDangXuat_Click_1(object sender, EventArgs e)
        {
            ChuaDangNhap();
            foreach (Form DX in MdiChildren)
            {
                DX.Close();
            }
            var login = new frmdangnhap();
            login.Show();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnudangxuat_Click(object sender, EventArgs e)
        {
            btnDangXuat_Click_1(sender, e);
        }


        private void mnuquanlykhachhang_Click(object sender, EventArgs e)
        {
            btnKhachHang_Click(sender, e);
        }

        private void mnuquanlythuephong_Click(object sender, EventArgs e)
        {
            btnThuePhong_Click(sender, e);
        }

        private void mnuquanlyphong_Click(object sender, EventArgs e)
        {
            btnQLPhong_Click(sender, e);
        }

        private void mnuquanlynhanvien_Click(object sender, EventArgs e)
        {
            btnNhanVien_Click(sender, e);
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            frmTaiKhoan fTK = new frmTaiKhoan();
            fTK.MdiParent = this;
            fTK.Show();
        }

        private void mnuquanlytaikhoan_Click(object sender, EventArgs e)
        {
            btnTaiKhoan_Click(sender, e);
        }

        private void btnDichVu_Click(object sender, EventArgs e)
        {
            frmDichVu fDV = new frmDichVu();
            fDV.MdiParent = this;
            fDV.Show();
        }

        private void mnuquanlydichvu_Click(object sender, EventArgs e)
        {
            btnDichVu_Click(sender, e);
        }

        private void mnuSaoLuu_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog saoluuFolder = new FolderBrowserDialog();
            saoluuFolder.Description = "";
            if (saoluuFolder.ShowDialog() == DialogResult.OK)
            {
                string sDuongDan = saoluuFolder.SelectedPath;
                if (CSDLBLL.SaoLuu(sDuongDan) == true)
                    MessageBox.Show("Đã sao lưu dữ liệu vào " + sDuongDan);
                else
                    MessageBox.Show("Thao tác không thành công");
            }

        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            frmHoaDon fBC = new frmHoaDon();
            fBC.MdiParent = this;
            fBC.Show();
        }

        private void mnuHoaDon_Click(object sender, EventArgs e)
        {
            btnHoaDon_Click(sender, e);
        }

        private void mnubaocaothongke_Click(object sender, EventArgs e)
        {
            btnBaoCao_Click(sender, e);
        }

        private void btnLienHe_Click(object sender, EventArgs e)
        {
            frmLienHe fLH = new frmLienHe();
            fLH.MdiParent = this;
            fLH.Show();
        }

        private void mnulienhe_Click(object sender, EventArgs e)
        {
            btnLienHe_Click(sender, e);
        }

        private void btnTroGiup_Click(object sender, EventArgs e)
        {
            frmTroGiup fTG = new frmTroGiup();
            fTG.MdiParent = this;
            fTG.Show();
        }

        private void mnutg_Click(object sender, EventArgs e)
        {
            btnTroGiup_Click(sender, e);
        }

        private void btnTTHeThong_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "file://D:\\tailieu\\Nam_4\\HKI\\DoAn2\\DoAnNhom_QLBĐT\\DoAn2\\DOAN2\\ThongTin.chm");
        }

       
        private void mnuthongtinhethong_Click(object sender, EventArgs e)
        {
            btnTTHeThong_Click(sender, e);
        }
    }
}
