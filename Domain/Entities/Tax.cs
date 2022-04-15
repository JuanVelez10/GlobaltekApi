using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public  class Tax
    {
        [Key]
        [Required]
        public Guid? Id { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Percentage { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public bool State { get; set; }

    }
}
