using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChemistWarehouse.Models
{
    public class Cart
    {
        [Key]
        public int CartID { get; set; }

        [Required]
        [Display(Name = "User ID")]
        public string UserID { get; set; }

        [Display(Name = "Cart Date")]
        public DateTime CartDate { get; set; }

        [Display(Name = "Cart Status")]
        public string CartStatus { get; set; }

        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }

        [StringLength(500)]
        [Display(Name = "Shipping Address")]
        public string Address { get; set; }

        [StringLength(20)]
        [Display(Name = "Contact No")]
        public string ContactNo { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }
    }

}
