using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;
using DTO;

namespace BLL
{
   public class khachhangBLL
    {
        khachhangDAL khDAL = new khachhangDAL();
        public DataTable hienthikhachhang()
        {
            return khDAL.hienthikhachhang();
        }
        public bool them_khachhang(string tenKhachHang, DateTime ngaySinh, bool gioiTinh, string chungMinhNhanDan, string diaChi, string soDienThoai, string quocTich)
        {
            return khDAL.them_khachhang(tenKhachHang, ngaySinh, gioiTinh, chungMinhNhanDan, diaChi, soDienThoai, quocTich);
        }
         public void xoa_khachhang(int maKhachHang)
        {
            khDAL.xoa_khachhang(maKhachHang);

        }

        public void sua_khachhang(string tenKhachHang, DateTime ngaySinh, bool gioiTinh, string chungMinhNhanDan, string diaChi, string soDienThoai, string quocTich,int maKhachHang)
        {

            khDAL.sua_khachhang(tenKhachHang, ngaySinh, gioiTinh, chungMinhNhanDan, diaChi, soDienThoai, quocTich, maKhachHang);
        }
        //tìm khách hàng theo mã khách hàng---
        public khachhangDTO TimkhachHangTheoMa(string ma)
        {
            return khachhangDAL.TimKhachHangTheoMa(ma);
        }

        //tìm khách hàng theo tên---
        public List<khachhangDTO> TimKhachHangTheoTen(string ten)
        {
            var list = khachhangDAL.TimKhachHangTheoTen(ten);
            return list.Where(x => x.tenKhachHang.ToLower().Contains(ten.ToLower())).ToList();
        }
        //tìm khách hàng theo số chứng minh nhân dân---
        public  khachhangDTO TimKhachHangTheoSoCMND(string so)
        {
            return khachhangDAL.TimKhachHangTheoSoCMND(so);
        }
        //tìm khách hàng theo phòng---
        public khachhangDTO TimKhachHangTheoPhong(string maPhong)
        {
            return khachhangDAL.TimKhachHangTheoPhong(maPhong);
        }


    }
}
