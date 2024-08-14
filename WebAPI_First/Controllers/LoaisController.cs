using DemoEntityFrameworkCore.Data;
using DemoEntityFrameworkCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebAPI_First.Data;

namespace DemoEntityFrameworkCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaisController : ControllerBase
    {

        private readonly MyDbContext _context;
        public LoaisController(MyDbContext context) 
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll() 
        {

            try
            {
                var dsLoai = _context.Loais.ToList();
                return Ok(dsLoai);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            var dsLoai = _context.Loais.SingleOrDefault(lo => lo.MaLoai == id);
            if (dsLoai != null)
            {
                return Ok(dsLoai);
            }
            else
            {
                return NotFound();
            }
           
        }

        [HttpPost]
        [Authorize]
        public IActionResult CreateNew(LoaiModel mode)
        {
            try 
            {
                var loai = new Loai
                {
                    TenLoai = mode.TenLoai,
                };

                _context.Add(loai);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created,loai);
            }
            catch
            {
                return BadRequest();
            }
           
        }

        [HttpPut("{id}")]
        public IActionResult UpdateLoaiById(int id, LoaiModel model)
        {

            var loai = _context.Loais.SingleOrDefault(lo => lo.MaLoai == id);
            if (loai != null)
            {

                loai.TenLoai = model.TenLoai;

                _context.Update(loai);
                _context.SaveChanges();
                return NoContent();
            }
            else
            {
                return NotFound();
            }

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLoaiById(int id)
        {

            var dsLoai = _context.Loais.SingleOrDefault(lo => lo.MaLoai == id);
            if (dsLoai != null)
            {
                _context.Remove(dsLoai);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status200OK);
            }
            else
            {
                return NotFound();
            }

        }
    }
}
