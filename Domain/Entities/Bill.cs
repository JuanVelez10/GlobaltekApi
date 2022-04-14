using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Domain.Enums.Enums;

namespace Domain.Entities
{
    public class Bill
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? Id { get; set; }

        [Required]
        [RegularExpression("[0-9]*", ErrorMessage = "Only numeric value")]
        public int Number { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [Required]
        public PaymentType PaymentType { get; set; }

        [Required]
        public Guid? IdPerson { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal SubTotal { get; set; }

        [Required]
        public Guid? IdDiscount { get; set; }

        [Required]
        public Guid? IdTax { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal DiscountTotal { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal TaxTotal { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Total { get; set; }

        public Person? Person { get; set; }
        public Tax? Tax { get; set; }
        public Discount? Discount { get; set; }
        public ICollection<BillDetail>? BillDetails { get; set; }

    }
}
