using BLL;
using System;
using System.Windows.Forms;

namespace quanlykhachsan
{
    public partial class frmnhanvien : Form
    {
        public frmnhanvien()
        {
            InitializeComponent();
        }
        int temp;

        private void hienthiNV()
        {
            nhanvienBLL pbll = new nhanvienBLL();
            dataGridViewNV.DataSource = null;
            dataGridViewNV.DataSource = pbll.hienthinhanvien();
        }
        private void trangthai(bool t)
        {
            
            txttennv.Enabled = t;
            txtscm.Enabled = t;
            txtsdt.Enabled = t;
            txtdiachi.Enabled = t;
            dtngaysinh.Enabled = t;
            dtngayvaolam.Enabled = t;
            cbgioitinh.Enabled = t;

        }

        private void frm_load(object sender, EventArgs e)
        {
            hienthiNV();

            trangthai(false);
            btnluu.Enabled = false;
            btnhuy.Enabled = false;
        }

      
        private void btnthem_Click(object sender, EventArgs e)
        {
            trangthai(true);
            temp = 1;
            txtmanv.Clear();
            txttennv.Clear();
            txtsdt.Clear();
            txtscm.Clear();
            txtdiachi.Clear();
            cbgioitinh.ResetText();
            dtngaysinh.ResetText();
            dtngayvaolam.ResetText();
            btnluu.Enabled = true;
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
            btnhuy.Enabled = true;
        }
        private void btnsua_Click(object sender, EventArgs e)
        {
            trangthai(true);
            temp = 2;
            btnluu.Enabled = true;
            btnthem.Enabled = false;
            btnxoa.Enabled = false;
            btnhuy.Enabled = true;
        }
        private bool travegioitinh()
        {
            if (cbgioitinh.Text == "Nam")
                return true;
            else
                return false;
        }
        private void btnluu_Click(object sender, EventArgs e)
        {
            trangthai(false);
            if (temp == 1)
            {
                nhanvienBLL nvBLL = new nhanvienBLL();
                nvBLL.them_nhanvien(txttennv.Text, travegioitinh(), dtngaysinh.Value, txtscm.Text, txtdiachi.Text, txtsdt.Text, dtngayvaolam.Value);
                hienthiNV();
            }
            else
            {
                nhanvienBLL nvBLL = new nhanvienBLL();
                nvBLL.sua_nhanvien(txttennv.Text, travegioitinh(), dtngaysinh.Value, txtscm.Text, txtdiachi.Text, txtsdt.Text, dtngayvaolam.Value, int.Parse(txtmanv.Text));
                hienthiNV();
            }
            btnluu.Enabled = false;
            btnhuy.Enabled = false;
            btnsua.Enabled = true;
            btnthem.Enabled = true;
            btnxoa.Enabled = true;
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (dataGridViewNV.CurrentRow.Index < 0 || string.IsNullOrEmpty(txtmanv.Text)) return;
            nhanvienBLL nvBLL = new nhanvienBLL();
            DialogResult luu = MessageBox.Show("Bạn chắc chắn xóa??", "Thông báo xóa nhân viên", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (luu == DialogResult.Yes)
            {
                nvBLL.xoa_nhanvien(int.Parse(txtmanv.Text));
                hienthiNV();
            }
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            btnluu.Enabled = false;
            btnsua.Enabled = true;
            btnthem.Enabled = true;
            btnxoa.Enabled = true;
            trangthai(false);

        }

        private void dataGridViewNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dataGridViewNV.Rows[e.RowIndex];
            txtmanv.Text = row.Cells["maNhanVien"].Value.ToString();
            txttennv.Text = row.Cells["hoTen"].Value.ToString();
            txtscm.Text = row.Cells["soChungMinh"].Value.ToString();
            txtsdt.Text = row.Cells["soDienThoai"].Value.ToString();
            txtdiachi.Text = row.Cells["diaChi"].Value.ToString();
            cbgioitinh.Text = row.Cells["gioiTinh"].Value.ToString();
            dtngaysinh.Value = Convert.ToDateTime(row.Cells["ngaySinh"].Value.ToString());
            dtngayvaolam.Value = Convert.ToDateTime(row.Cells["ngayVaoLam"].Value.ToString());
        }
    }
}
