using DTO;
using DTO.Request;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class HoaDonDAL
    {
        private SqlConnection con { get; set; }

        public List<HoaDonRequest> DanhSachHoaDon()
        {
            string sTruyVan = string.Format($@"select *
             from dbo.hoadon as hd 
             inner join dbo.khachhang as kh on kh.maKhachHang = hd.maKhachHang
             inner join dbo.NhanVien as nv on nv.maNhanVien = hd.maNhanVien
             inner join dbo.thuephong as tp on tp.maKhachHang = kh.maKhachHang");
            con = ketnoi.MoKetNoi();
            DataTable dt = ketnoi.TruyVanLayDuLieu(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            var dsHoaDon = new List<HoaDonRequest>();
            foreach (var item in dt.Rows)
            {
                var hoaDon = (DataRow)item;
                var kh = new HoaDonRequest
                {
                    maHoaDon = int.Parse(hoaDon["maHoaDon"].ToString()),
                    maPhong = int.Parse(hoaDon["maPhong"].ToString()),
                    maKhachHang = int.Parse(hoaDon["maKhachHang"].ToString()),
                    tenKhachHang = hoaDon["tenKhachHang"].ToString(),
                    chungMinhNhanDan = hoaDon["chungMinhNhanDan"].ToString(),
                    diaChi = hoaDon["diaChi"].ToString(),
                    soDienThoai = hoaDon["sodienthoai"].ToString(),
                    gioiTinh = ($"{hoaDon["gioiTinh"]}") == "True" ? "Nam" : "Nữ",
                    ngaySinh = DateTime.Parse(hoaDon["ngaysinh"].ToString()),
                    quocTich = hoaDon["quoctich"].ToString(),
                    ngayLap = DateTime.Parse(hoaDon["ngayLap"].ToString()),
                    ngayDen = DateTime.Parse(hoaDon["ngayDen"].ToString()),
                    tongTien = string.IsNullOrEmpty($"{hoaDon["tongTien"]}")? 0 : int.Parse(hoaDon["tongTien"].ToString()),
                };
                if (!string.IsNullOrEmpty($"{hoaDon["ngayDi"]}"))
                    kh.ngayDi = DateTime.Parse(hoaDon["ngayDi"].ToString());

                dsHoaDon.Add(kh);
            }

            ketnoi.DongKetNoi(con);
            return dsHoaDon;
        }

        public void LapHoaDon(HoaDonDTO hd)
        {
            string sTruyVan = string.Format($"insert into dbo.hoadon values( {hd.maKhachHang}, {hd.maNhanVien}, '{hd.ngayLap.Year}-{hd.ngayLap.Month}-{hd.ngayLap.Day}', {hd.tongTien} )");
            con = ketnoi.MoKetNoi();
            ketnoi.TruyVanKhongLayDuLieu(sTruyVan, con);
            ketnoi.DongKetNoi(con);
        }

    }
}
