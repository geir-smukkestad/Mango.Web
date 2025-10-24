using System.ComponentModel.DataAnnotations;

namespace Mango.Common.Dto.Auth
{
    public class LoginRequestDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
