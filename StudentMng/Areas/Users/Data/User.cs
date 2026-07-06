using System.ComponentModel.DataAnnotations;

namespace StudentMng.Areas.Users.Data
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required,StringLength(10)]
        [DataType(DataType.Text)]
        public string UserName { get; set; }
        [Required,StringLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public string Role { get; set; }
    }
}