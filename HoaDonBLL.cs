using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using DTO;

namespace BLL
{
    public class HoaDonBLL
    {
        public void DanhSachHoaDon(DataGridView dt)
        {
            var danhSach = new HoaDonDAL();
            dt.DataSource = null;
            dt.DataSource = danhSach.DanhSachHoaDon();
        }

        public void LapHoaDon(HoaDonDTO hd)
        {
            var lap = new HoaDonDAL();
            lap.LapHoaDon(hd);
        }

    }

   
}
