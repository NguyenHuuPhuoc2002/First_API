using WebAPI_First.Models;

namespace WebAPI_First.Services
{
    public interface IHangHoaRepository
    {
       List<HangHoaModel> GetAll(string search, double? from, double? to, string sortBy, int page);
    }
}
