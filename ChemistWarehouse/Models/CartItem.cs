using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ChemistWarehouse.Models
{
    public class CartItem
    {
        [Key]
        public int CartItemID { get; set; }

        [Required]
        public int CartID { get; set; }

        [ForeignKey("CartID")]
        [InverseProperty("CartItems")]
        public virtual Cart Cart { get; set; }

        [Required]
        public int ProductID { get; set; }

        [ForeignKey("ProductID")]
        [InverseProperty("ProductCartItems")]
        public virtual ProductInfo ProductInfo { get; set; }

        [Display(Name = "Purchase Price")]
        public float Price { get; set; }

        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Display(Name = "Total Price")]
        public float Total { get; set; }
    }
}
