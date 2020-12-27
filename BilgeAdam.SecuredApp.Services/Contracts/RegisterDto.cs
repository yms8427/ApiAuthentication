using System;
using System.Collections.Generic;
using System.Text;

namespace BilgeAdam.SecuredApp.Services.Contracts
{
    public class RegisterDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
