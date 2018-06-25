using Stock_Management.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Stock_Management.Models.ViewModels
{
    public class UserVM
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }

        public UserVM()
        { }

        public UserVM(UserDTO model)
        {
            this.Id = model.Id;
            this.FirstName = model.FirstName;
            this.LastName = model.LastName;
            this.Email = model.Email;
            this.UserName = model.UserName;
            this.Password = model.Password;
        }
    }
}