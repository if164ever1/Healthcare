using System.ComponentModel.DataAnnotations;

namespace Healthcare.Models.Responce
{
    public class LoginResponse
    {
        public int Id { get; set; }
        public string Token { get; set; }
    }
}
