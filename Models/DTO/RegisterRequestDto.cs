using System.ComponentModel.DataAnnotations;

namespace TaskManagerAPI.Models.DTO
{
    public class RegisterRequestDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }

        public string[] Roles { get; set; }
    }
}
