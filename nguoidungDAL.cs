using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NguoidungDAL
    {
        public DataTable hienthinguoidung()
        {
            SqlConnection cnn = ketnoi.MoKetNoi();
            // Khai báo và khởi tạo đối tượng Command, truyền vào tên thủ tục tương ứng
            DataTable dt = ketnoi.TruyVanLayDuLieu("select * from nguoidung", cnn);
            // Khai báo kiểu thực thi là Thực thi thủ tục
            ketnoi.DongKetNoi(cnn);   
            cnn.Close();
            return dt;
        }
        public bool them_nguoidung(string taiKhoan,  string matKhau, string phanQuyen, int maNhanVien)
        {
            SqlConnection cnn = ketnoi.MoKetNoi();
            SqlCommand cmd = new SqlCommand("them_nguoidung", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("taiKhoan", taiKhoan);
            cmd.Parameters.AddWithValue("matKhau", matKhau);
            cmd.Parameters.AddWithValue("phanQuyen", phanQuyen);
            cmd.Parameters.AddWithValue("maNhanVien", maNhanVien);

            int i = cmd.ExecuteNonQuery();
            cnn.Close();
            if (i != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void xoa_nguoidung(string taiKhoan)
        {

            SqlConnection cnn = ketnoi.MoKetNoi();
            SqlCommand cmd = new SqlCommand("xoa_nguoidung", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("taiKhoan", taiKhoan);
            cmd.ExecuteNonQuery();
            cnn.Close();

        }

        public void sua_nguoidung(string taiKhoan, string matKhau, string phanQuyen, int maNhanVien)
        {
            SqlConnection cnn = ketnoi.MoKetNoi();
            SqlCommand cmd = new SqlCommand("sua_nguoidung", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("taiKhoan", taiKhoan);
            cmd.Parameters.AddWithValue("matKhau", matKhau);
            cmd.Parameters.AddWithValue("phanQuyen", phanQuyen);
            cmd.Parameters.AddWithValue("maNhanVien", maNhanVien);
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
    }
}
