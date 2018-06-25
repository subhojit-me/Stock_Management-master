using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Stock_Management.Models.ViewModels
{
    public class LoginVM
    {
        [Required]
        public string userName { get; set; }

        [Required]
        public string password { get; set; }

        public bool rememberme { get; set; }
    }
}