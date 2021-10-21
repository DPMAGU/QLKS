using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DTO;

namespace DAL
{
   public class nhanvienDAL
    {
        public DataTable hienthinhanvien()
        {
            SqlConnection cnn = ketnoi.MoKetNoi();
            // Khai báo và khởi tạo đối tượng Command, truyền vào tên thủ tục tương ứng
            SqlCommand cmd = new SqlCommand("hienthitatcanhanvien", cnn);
            // Khai báo kiểu thực thi là Thực thi thủ tục
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cnn.Close();
            return dt;
        }
        public nhanvienDTO TimNhanVien(int maNhanVien)
        {
            SqlConnection cnn = ketnoi.MoKetNoi();
            // Khai báo và khởi tạo đối tượng Command, truyền vào tên thủ tục tương ứng
            string sTruyVan = string.Format($"select * from dbo.nhanvien nv where nv.maNhanVien = {maNhanVien}");

            DataTable dt = ketnoi.TruyVanLayDuLieu(sTruyVan, cnn);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            var nhanVien = new nhanvienDTO()
            {
                maNhanVien = int.Parse($"{dt.Rows[0]["maNhanVien"]}"),
                hoTen = $"{dt.Rows[0]["hoTen"]}",
                gioiTinh = bool.Parse($"{dt.Rows[0]["gioiTinh"]}") ? "Nam" : "Nữ",
                ngaySinh = DateTime.Parse($"{dt.Rows[0]["ngaySinh"]}"),
                soChungMinh = $"{dt.Rows[0]["soChungMinh"]}",
                diaChi = $"{dt.Rows[0]["diaChi"]}",
                soDienThoai = $"{dt.Rows[0]["soDienThoai"]}",
                ngayVaoLam = DateTime.Parse($"{dt.Rows[0]["ngayVaoLam"]}"),
            };
            cnn.Close();
            return nhanVien;
        }

        public bool them_nhanvien(string hoTen, bool gioiTinh, DateTime ngaySinh, string soChungMinh, string diaChi, string soDienThoai, DateTime ngayVaoLam)
        {
            SqlConnection cnn = ketnoi.MoKetNoi();
            SqlCommand cmd = new SqlCommand("them_nhanvien", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("hoTen", hoTen);
            cmd.Parameters.AddWithValue("gioiTinh", gioiTinh);
            cmd.Parameters.AddWithValue("ngaySinh", ngaySinh);
            cmd.Parameters.AddWithValue("soChungMinh", soChungMinh);
            cmd.Parameters.AddWithValue("diaChi", diaChi);
            cmd.Parameters.AddWithValue("soDienThoai", soDienThoai);
            cmd.Parameters.AddWithValue("ngayVaoLam", ngayVaoLam);

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
            public void xoa_nhanvien(int maNhanVien)
        {

            SqlConnection cnn = ketnoi.MoKetNoi();
            SqlCommand cmd = new SqlCommand("xoa_nhanvien", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("maNhanVien", maNhanVien);
            int i = cmd.ExecuteNonQuery();
            cnn.Close();
        }

        public void sua_nhanvien(string hoTen, bool gioiTinh, DateTime ngaySinh, string soChungMinh, string diaChi, string soDienThoai, DateTime ngayVaoLam, int maNhanVien)
        {
            SqlConnection cnn = ketnoi.MoKetNoi();
            SqlCommand cmd = new SqlCommand("sua_nhanvien", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("hoTen", hoTen);
            cmd.Parameters.AddWithValue("gioiTinh", gioiTinh);
            cmd.Parameters.AddWithValue("ngaySinh", ngaySinh);
            cmd.Parameters.AddWithValue("soChungMinh", soChungMinh);
            cmd.Parameters.AddWithValue("diaChi", diaChi);
            cmd.Parameters.AddWithValue("soDienThoai", soDienThoai);
            cmd.Parameters.AddWithValue("ngayVaoLam", ngayVaoLam);
            cmd.Parameters.AddWithValue("maNhanVien", maNhanVien);
            int i = cmd.ExecuteNonQuery();
            cnn.Close();
        }
    
    }
}
