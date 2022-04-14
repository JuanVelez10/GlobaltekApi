using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Entities
{
    public class BillDetail
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? Id { get; set; }

        [Required]
        public Guid? IdBill { get; set; }

        [Required]
        public Guid? IdProduct { get; set; }

        [Required]
        [RegularExpression("[0-9]*", ErrorMessage = "Only numeric value")]
        public int Amount { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal UnitCost { get; set; }

        public Bill? Bill { get; set; }
        public Product? Product { get; set; }

    }
}
