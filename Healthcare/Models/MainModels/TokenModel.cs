
using System.ComponentModel.DataAnnotations;

namespace Healthcare.Models
{
    public class TokenModel
    {
        [Key]
        public int Id { get; set; }
        public string Token { get; set; }
    }
}
