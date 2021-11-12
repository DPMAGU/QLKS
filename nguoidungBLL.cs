using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
using DTO;


namespace BLL
{
    public class nguoidungBLL
    {
        NguoidungDAL ndDAL = new NguoidungDAL();
        public List<NguoiDungDTO> Hienthinguoidung()
        {
            var listNguoiDung = new List<NguoiDungDTO>();
            var dtNguoidung = ndDAL.hienthinguoidung();
            for (int i = 0; i < dtNguoidung.Rows.Count; i++)
            {
                listNguoiDung.Add(new NguoiDungDTO()
                {
                    TaiKhoan = dtNguoidung.Rows[i]["taiKhoan"].ToString(),
                    MatKhau = dtNguoidung.Rows[i]["matKhau"].ToString(),
                    PhanQuyen = dtNguoidung.Rows[i]["phanQuyen"].ToString(),
                    maNhanVien = int.Parse(dtNguoidung.Rows[i]["maNhanVien"].ToString()),
                });
            }
            return listNguoiDung;
            
        }

        public bool them_nguoidung( string taiKhoan, string matKhau, string phanQuyen, int maNhanVien)
        {
            return ndDAL.them_nguoidung(taiKhoan, matKhau, phanQuyen, maNhanVien);
        }

         public void xoa_nguoidung(string taiKhoan)
        {
            ndDAL.xoa_nguoidung(taiKhoan);
        }

        

        public void sua_nguoidung(string taiKhoan, string matKhau, string phanQuyen, int maNhanVien)
        {
            ndDAL.sua_nguoidung(taiKhoan, matKhau, phanQuyen, maNhanVien);
        }
    }
}