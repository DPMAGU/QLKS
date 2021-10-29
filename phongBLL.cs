using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAL;
using DTO;

namespace BLL
{
   public class phongBLL
    {
        phongDAL Stclr = new phongDAL();
        public List<phongDTO> hienthithongtinphong()
        {
            var thongTin = Stclr.hienthithongtinphong();
            var danhSachPhong = new List<phongDTO>();
            foreach (var item in thongTin.Rows)
            {
                var p = (DataRow)item;
                var phong = new phongDTO()
                {
                    maPhong = $"{p["maPhong"]}",
                    tinhTrang = $"{p["tinhTrang"]}",
                    loaiPhong = $"{p["loaiPhong"]}",
                    donGia = float.Parse($"{p["donGia"]}")

                };
                danhSachPhong.Add(phong);
            }
            return danhSachPhong;
        }
    }
}
