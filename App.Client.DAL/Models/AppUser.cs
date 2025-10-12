
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Client.DAL.Models {
    public class AppUser : IdentityUser {
    
        public string firstName {  get; set; }

        public string lastName { get; set; }

        public bool isAgree { get; set; }


    
    }
}
