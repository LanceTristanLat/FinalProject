using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Item
    {
        [Key]
        public int ProductID { get; set; }
        [Required(ErrorMessage ="Required.")]
        public string ProductName { get; set; }

        public string ProductCode { get; set; }
        [DataType(DataType.MultilineText)]
        public string ProductDescription { get; set; }
        [Required(ErrorMessage = "Required.")]
        public decimal ProductPrice { get; set; }
        [Display(Name ="Date Added")]
        public DateTime DateAdded { get; set; }
        [Display(Name ="Categories")]
        public Categories Categories { get; set; }

    }
    public enum Categories
    {
        Earphones = 1,
        Macbooks = 2,
        Iphones = 3,
        AppleWatch = 4
    }
}
