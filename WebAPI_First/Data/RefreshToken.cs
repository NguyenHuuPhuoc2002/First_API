using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI_First.Data
{
    [Table("RefreshToken")]
    public class RefreshToken
    {
        [Key] 
        public Guid Id { get; set; }    
        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public NguoiDung nguoiDung { get; set; }
        public string Token { get; set; }
        public string JwtId { get; set; }
        public bool IsUsed { get; set; }
        public bool IsRevoked { get; set; }
        public DateTime IssuedAt { get; set; }
        public DateTime ExpiredAt { get; set; }
    }
}
