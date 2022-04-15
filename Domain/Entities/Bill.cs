using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Domain.Enums.Enums;

namespace Domain.Entities
{
    public class Bill
    {
        [Key]
        [Required]
        public Guid? Id { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [RegularExpression("[0-9]*", ErrorMessage = "Only numeric value")]
        public int Number { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [Required]
        public PaymentType PaymentType { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal SubTotal { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal DiscountTotal { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal TaxTotal { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Total { get; set; }

        [Required]
        public Guid? PersonId { get; set; }

        [Required]
        public Guid? TaxId { get; set; }

        [Required]
        public Guid? DiscountId { get; set; }

        public virtual Person? Person { get; set; }
        public virtual Tax? Tax { get; set; }
        public virtual Discount? Discount { get; set; }
        public ICollection<BillDetail>? BillDetails { get; set; }

    }
}
