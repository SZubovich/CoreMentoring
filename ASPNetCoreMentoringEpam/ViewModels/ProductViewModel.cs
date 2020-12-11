using System.ComponentModel.DataAnnotations;

namespace ASPNetCoreMentoringEpam.ViewModels
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }

        [Required]
        [MinLength(3)]
        [StringLength(100)]
        public string ProductName { get; set; }
        public string Supplier { get; set; }
        public string Category { get; set; }

        [Required]
        [MinLength(3)]
        [StringLength(100)]
        public string QuantityPerUnit { get; set; }

        [Range(0.0, 100_000.0)]
        public decimal? UnitPrice { get; set; }

        [Range(0, 32_000)]
        public short? UnitsInStock { get; set; }

        [Range(0, 32_000)]
        public short? UnitsOnOrder { get; set; }

        [Range(0, 32_000)]
        public short? ReorderLevel { get; set; }

        [Required]
        public bool Discontinued { get; set; }
    }
}
