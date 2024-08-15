using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Metadata;

namespace WebAPI_First.Models
{
    public class HangHoaVM
    {
        public string TenHangHoa { get; set; }
        public double DonGia { get; set; }
    }

    public class HangHoa: HangHoaVM
    {
        public Guid MaHangHoa { get; set; }
    }

    public class HangHoaModel
    {
        public string TenHangHoa { get; set; }
        public Guid MaHangHoa { get; set; }
        public double DonGia { get; set; }
     /*   public string TenLoai { get; set; }
*/
        public IFormFile Image { get; set; }
    }
}
