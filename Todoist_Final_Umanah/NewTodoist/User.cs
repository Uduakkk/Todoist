using System;
using System.Collections.Generic;
using System.Text;

namespace NewTodoist
{
    public class User
    {
        public Guid Id { get; set; } 
        public string FirstName { get; set; }   
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string currentUser = null;

        public List<Items> item { get; set; } = new List<Items>();

        public User()
        {
        
        }
    }
}
