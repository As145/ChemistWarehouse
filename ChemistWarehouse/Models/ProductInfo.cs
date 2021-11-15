using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ChemistWarehouse.Models
{
    public class ProductInfo
    {
        [Key]
        public int ProductID { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Required]
        [Display(Name = "Product Price")]
        public float Price { get; set; }

        [Required]
        [Display(Name = "Sale Price")]
        public float SalePrice { get; set; }

        [Required]
        [StringLength(1500)]
        [Display(Name = "Product Description")]
        public string Description { get; set; }


        [Required]
        public int CategoryID { get; set; }

        [ForeignKey("CategoryID")]
        [InverseProperty("ProductInfos")]
        public virtual Category Category { get; set; }

        [Required]
        [StringLength(20)]
        public string Extension { get; set; }

        [NotMapped]
        public ImageUpload File { get; set; }

        public virtual ICollection<CartItem> ProductCartItems { get; set; }
    }
}
