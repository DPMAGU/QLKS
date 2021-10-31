using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDonDTO
    {
        public int maHoaDon { get; set; }
        public int maKhachHang { get; set; }
        public int? maNhanVien { get; set; }
        public int tongTien { get; set; }
        public DateTime ngayLap { get; set; }
    }
}
