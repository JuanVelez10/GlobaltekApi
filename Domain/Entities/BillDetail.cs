using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Entities
{
    public class BillDetail
    {
        [Key]
        [Required]
        public Guid? Id { get; set; }

        [Required]
        [RegularExpression("[0-9]*", ErrorMessage = "Only numeric value")]
        public int Amount { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal UnitCost { get; set; }

        [Required]
        public Guid? BillId { get; set; }

        [Required]
        public Guid? ProductId { get; set; }

        public virtual Bill? Bill { get; set; }
        public virtual Product? Product { get; set; }

    }
}
