using System;

namespace BilgeAdam.SecuredApp.Model
{
    public class RegisterInputModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
