
using Application.Interfaces;
using Application.Services;
using System.ComponentModel.DataAnnotations;
using static Domain.Enums.Enums;

namespace Api.References
{
    public class LoginRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
