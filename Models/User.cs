
using System;

namespace Employex.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int Status { get; set; }
    }
}
