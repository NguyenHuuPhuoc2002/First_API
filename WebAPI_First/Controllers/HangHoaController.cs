using DemoEntityFrameworkCore.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebAPI_First.Data;
using WebAPI_First.Models;

namespace WebAPI_First.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        //  public static List<HangHoa> hangHoas = new List<HangHoa>();
        private readonly MyDbContext _context;

        public HangHoaController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        /* public IActionResult GetAll() {
             return Ok(hangHoas);
         }
         [HttpGet("{id}")]
         public IActionResult GetById(string id)
         {
             try
             {
                 //LINQ Query [Ob]
                 var hangHoa = hangHoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));

                 if (hangHoa == null)
                 {
                     return NotFound();
                 }
                 return Ok(hangHoa);
             }
             catch
             {
                 return BadRequest();
             }
         }
         [HttpPost]
         public IActionResult Create(HangHoaVM hangHoaVM)
         {
             var hanghoa = new HangHoa
             {
                 MaHangHoa = Guid.NewGuid(),
                 TenHangHoa = hangHoaVM.TenHangHoa,
                 DonGia = hangHoaVM.DonGia,
             };
             hangHoas.Add(hanghoa);
             return Ok(new
             {
                 Success = true, Data = hanghoa
             });
         }
         [HttpPut("{id}")]
         public IActionResult Edit(HangHoa hangHoaEdit, string id)
         {
             try
             {
                 //LINQ Query [Ob]
                 var hangHoa = hangHoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));

                 if (hangHoa == null)
                 {
                     return NotFound();
                 }
                 if (id != hangHoa.MaHangHoa.ToString()) {
                     return BadRequest();
                 }
                 //update
                 hangHoa.TenHangHoa = hangHoaEdit.TenHangHoa;
                 hangHoa.DonGia = hangHoaEdit.DonGia;

                 return Ok();
             }
             catch
             {
                 return BadRequest();
             }
         }
         [HttpDelete("{id}")]
         public IActionResult Delete(string id)
         {
             try
             {
                 //LINQ Query [Ob]
                 var hangHoa = hangHoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));

                 if (hangHoa == null)
                 {
                     return NotFound();
                 }
                 if (id != hangHoa.MaHangHoa.ToString())
                 {
                     return BadRequest();
                 }
                 //delete
                 hangHoas.Remove(hangHoa);

                 return Ok();
             }
             catch
             {
                 return BadRequest();
             }
         }
 */
        #region Truyền ảnh cách 1:
        [HttpPost]
        [Route("uploadfile")]
        public async Task<IActionResult> PostWithImage([FromForm] HangHoaModel hangHoa)
        {
            var findHangHoa = _context.HangHoas.Find(hangHoa.MaHangHoa);
            if (findHangHoa != null)
            {
                return Ok("Mã sản phẩm đã tồn tại");
            }
            else
            {
                var _hangHoa = new WebAPI_First.Data.HangHoa
                {
                    MaHh = Guid.NewGuid(),
                    TenHh = hangHoa.TenHangHoa,
                    Mota = "No",
                    DonGia = hangHoa.DonGia,
                    GiamGia = 0,
                    MaLoai = null,
                };
                //xử lý ảnh
                if (hangHoa.Image.Length > 0)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", hangHoa.Image.FileName);
                    using (var stream = System.IO.File.Create(path))
                    {
                        await hangHoa.Image.CopyToAsync(stream);
                    }
                    _hangHoa.Hinh = "/images/" + hangHoa.Image.FileName;
                }
                else
                {
                    _hangHoa.Hinh = "";
                }
                _context.HangHoas.Add(_hangHoa);
                _context.SaveChanges();
                return Ok("Thành công !");
            }
        }
        #endregion

        #region Truyền ảnh cách 2:
        [HttpPost]
        [Route("uploadfileV2")]
        public async Task<IActionResult> PostWithImageV2([FromForm] string datajson, IFormFile fileimage)
        {
            // convert datajson sang object HangHoa
            var product = JsonConvert.DeserializeObject<HangHoaModel>(datajson);


            var findHangHoa = _context.HangHoas.Find(product.MaHangHoa);
            if (findHangHoa != null)
            {
                return Ok("Mã sản phẩm đã tồn tại");
            }
            else
            {
                var _hangHoa = new WebAPI_First.Data.HangHoa
                {
                    MaHh = Guid.NewGuid(),
                    TenHh = product.TenHangHoa,
                    Mota = "No",
                    DonGia = product.DonGia,
                    GiamGia = 0,
                    MaLoai = null,
                };
                //xử lý ảnh
                if (fileimage.Length > 0)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileimage.FileName);
                    using (var stream = System.IO.File.Create(path))
                    {
                        await fileimage.CopyToAsync(stream);
                    }
                    _hangHoa.Hinh = "/images/" + fileimage.FileName;
                }
                else
                {
                    _hangHoa.Hinh = "";
                }
                _context.HangHoas.Add(_hangHoa);
                _context.SaveChanges();
                return Ok("Thành công !");
            }
        }
        #endregion
    }
}
