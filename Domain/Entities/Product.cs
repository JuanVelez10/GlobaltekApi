using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Product
    {
        [Key]
        [Required]
        public Guid? Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public decimal Cost { get; set; }

        [Required]
        public bool State { get; set; }
    }


}
