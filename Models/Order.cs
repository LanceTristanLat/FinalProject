using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        [Required(ErrorMessage = "Required.")]
        [Display(Name = "Product Name")]

        public string ProductName { get; set; }


        [Required(ErrorMessage = "Required.")] 
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Required.")] 
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Required.")]
        [DataType(DataType.MultilineText)]

        public string Address { get; set; }

        [Required(ErrorMessage = "Required.")] 
        public int ContactNum { get; set; }

        [Display(Name = "Date Ordered")]
        public DateTime DateAdded { get; set; }

        public ModeOfPayment ModeOfPayment { get; set; }
        
    }

    public enum ModeOfPayment
    {
        COD = 1,
        EPayment = 2,
        BankTransfer = 3
    }
}
