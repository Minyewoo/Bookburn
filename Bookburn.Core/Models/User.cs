using System;
using System.Collections.Generic;

namespace Bookburn.Core.Models
{
    public class User
    {
        public long Id { get; set; }
        public string Nickname { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }
        public DateTime RegistrationDate { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<Book> Books { get; set; }
        public virtual ICollection<UserBookAction> Actions { get; set; }
    }
}