using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ThuePhongRequestDTO
    {
        // maThuePhong, a.maKhachHang, a.maPhong, tenKhachHang,ngaySinh,chungMinhNhanDan,diaChi,soDienThoai,ngayDen,donGia
        public int maThuePhong { get; set; }
        public int maKhachHang { get; set; }
        public int maPhong { get; set; }
        public string tenKhachHang { get; set; }
        public DateTime ngaySinh { get; set; }
        public string chungMinhNhanDan { get; set; }
        public string diaChi { get; set; }
        public string soDienThoai { get; set; }
        public DateTime ngayDen { get; set; }
        public float donGia { get; set; }
    }
}
