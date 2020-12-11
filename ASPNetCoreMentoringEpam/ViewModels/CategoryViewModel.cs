using System;
using System.ComponentModel.DataAnnotations;

namespace ASPNetCoreMentoringEpam.ViewModels
{
    public class CategoryViewModel
    {
        public int CategoryId { get; set; }

        [Required]
        [MinLength(3)]
        [StringLength(100)]
        public string CategoryName { get; set; }

        [Required]
        [MinLength(3)]
        [StringLength(100)]
        public string Description { get; set; }

        public byte[] Picture { get; set; }
    }
}