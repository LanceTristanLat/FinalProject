using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace FinalProject.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int AccountID { get; set; }
        public UserTypes Type { get; set; }
        

    }
    public enum UserTypes
    {
        Admin = 1,
        Customer = 2,
    }
}
