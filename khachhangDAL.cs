using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class khachhangDAL
    {
        private static SqlConnection con;

        public DataTable hienthikhachhang()
        {
            SqlConnection cnn = ketnoi.MoKetNoi();
            // Khai báo và khởi tạo đối tượng Command, truyền vào tên thủ tục tương ứng
            SqlCommand cmd = new SqlCommand("hienthikhachhang", cnn);
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
        public bool them_khachhang(string tenKhachHang, DateTime ngaySinh, bool gioiTinh, string chungMinhNhanDan, string diaChi, string soDienThoai, string quocTich)
        {
            SqlConnection cnn = ketnoi.MoKetNoi();
            SqlCommand cmd = new SqlCommand("them_khachhang", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("tenKhachHang", tenKhachHang);
            cmd.Parameters.AddWithValue("ngaySinh", ngaySinh);
            cmd.Parameters.AddWithValue("gioiTinh", gioiTinh);
            cmd.Parameters.AddWithValue("chungMinhNhanDan", chungMinhNhanDan);
            cmd.Parameters.AddWithValue("diaChi", diaChi);
            cmd.Parameters.AddWithValue("soDienThoai", soDienThoai);
            cmd.Parameters.AddWithValue("quocTich", quocTich);

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
        public void xoa_khachhang(int maKhachHang)
        {

            SqlConnection cnn = ketnoi.MoKetNoi();
            SqlCommand cmd = new SqlCommand("xoa_khachhang", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("maKhachHang", maKhachHang);

            int i = cmd.ExecuteNonQuery();
            cnn.Close();

        }

        public void sua_khachhang(string tenKhachHang, DateTime ngaySinh, bool gioiTinh, string chungMinhNhanDan, string diaChi, string soDienThoai, string quocTich, int maKhachHang)
        {
            SqlConnection cnn = ketnoi.MoKetNoi();
            SqlCommand cmd = new SqlCommand("sua_khachhang", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("tenKhachHang", tenKhachHang);
            cmd.Parameters.AddWithValue("ngaySinh", ngaySinh);
            cmd.Parameters.AddWithValue("gioiTinh", gioiTinh);
            cmd.Parameters.AddWithValue("chungMinhNhanDan", chungMinhNhanDan);
            cmd.Parameters.AddWithValue("diaChi", diaChi);
            cmd.Parameters.AddWithValue("soDienThoai", soDienThoai);
            cmd.Parameters.AddWithValue("quocTich", quocTich);
            cmd.Parameters.AddWithValue("maKhachHang", maKhachHang);

            int i = cmd.ExecuteNonQuery();
            cnn.Close();
        }


        // Tìm khách hàng theo mã số, trả về null nếu không thấy
        public static khachhangDTO TimKhachHangTheoMa(string ma)
        {
            string sTruyVan = string.Format($@"select * from khachhang where maKhachHang='{ma}'");
            con = ketnoi.MoKetNoi();
            DataTable dt = ketnoi.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }

            khachhangDTO kh = new khachhangDTO
            {
                maKhachHang = int.Parse(dt.Rows[0]["maKhachHang"].ToString()),
                tenKhachHang = dt.Rows[0]["tenKhachHang"].ToString(),
                chungMinhNhanDan = dt.Rows[0]["chungMinhNhanDan"].ToString(),
                diaChi = dt.Rows[0]["diachi"].ToString(),
                soDienThoai = dt.Rows[0]["sodienthoai"].ToString(),
                gioiTinh = ($"{dt.Rows[0]["gioiTinh"]}") == "True" ? "Nam" : "Nữ",
                ngaySinh = DateTime.Parse(dt.Rows[0]["ngaysinh"].ToString()),
                quocTich = dt.Rows[0]["quoctich"].ToString()
            };

            ketnoi.DongKetNoi(con);
            return kh;
        }

        //Tìm khách hàng theo phòng, trả về null nếu không thấy
        public static khachhangDTO TimKhachHangTheoPhong(string maPhong)
        {
            string sTruyVan = string.Format($@"select * from thuephong where maphong={maPhong}");
            con = ketnoi.MoKetNoi();
            DataTable dt = ketnoi.TruyVanLayDuLieu(sTruyVan, con);
            
            return TimKhachHangTheoMa(dt.Rows[0]["maKhachHang"].ToString());
        }

        // Tìm khách hàng theo tên, trả về null nếu không thấy
        public static List<khachhangDTO> TimKhachHangTheoTen(string ten)
        {
            string sTruyVan = string.Format($@"select * from khachhang");           
            con = ketnoi.MoKetNoi();
            DataTable dt = ketnoi.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }

            List<khachhangDTO> lstkhachhang = new List<DTO.khachhangDTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                khachhangDTO kh = new khachhangDTO();
                kh.maKhachHang = int.Parse(dt.Rows[i]["maKhachHang"].ToString());
                kh.tenKhachHang = dt.Rows[i]["tenKhachHang"].ToString();
                kh.chungMinhNhanDan = dt.Rows[i]["chungMinhNhanDan"].ToString();
                kh.diaChi = dt.Rows[i]["diachi"].ToString();
                kh.soDienThoai = dt.Rows[i]["sodienthoai"].ToString();
                kh.gioiTinh = bool.Parse($"{dt.Rows[i]["gioiTinh"]}") == true ? "Nam" : "Nữ";
                kh.ngaySinh = DateTime.Parse(dt.Rows[i]["ngaysinh"].ToString());
                kh.quocTich = dt.Rows[i]["quoctich"].ToString();
                lstkhachhang.Add(kh);
            }

            ketnoi.DongKetNoi(con);
            return lstkhachhang;
        }

        // Tìm khách hàng theo số chứng minh nhân dân, trả về null nếu không thấy
        public static khachhangDTO TimKhachHangTheoSoCMND(string so)
        {
            string sTruyVan = string.Format($@"select * from khachhang where chungMinhNhanDan='{so}'");
            con = ketnoi.MoKetNoi();
            DataTable dt = ketnoi.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            khachhangDTO kh = new khachhangDTO
            {
                maKhachHang = int.Parse(dt.Rows[0]["maKhachHang"].ToString()),
                tenKhachHang = dt.Rows[0]["tenKhachHang"].ToString(),
                chungMinhNhanDan = dt.Rows[0]["chungMinhNhanDan"].ToString(),
                diaChi = dt.Rows[0]["diachi"].ToString(),
                soDienThoai = dt.Rows[0]["sodienthoai"].ToString(),
                gioiTinh = ($"{dt.Rows[0]["gioiTinh"]}") == "True" ? "Nam" : "Nữ",
                ngaySinh = DateTime.Parse(dt.Rows[0]["ngaysinh"].ToString()),
                quocTich = dt.Rows[0]["quoctich"].ToString()
            };

            ketnoi.DongKetNoi(con);
            return kh;
        }

      


    }
}
