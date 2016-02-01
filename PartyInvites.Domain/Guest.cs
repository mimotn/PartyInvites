namespace PartyInvites.Domain
{
    public class Guest
    {
        //[Required(ErrorMessage = "Please enter your name")]
        //[Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }

        //[Required(ErrorMessage = "Please enter your email")]
        //[RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter a valid email")]
        public string Email { get; set; }

        //[Required(ErrorMessage = "Please enter your phone number")]
        public string Phone { get; set; }

        //[Required(ErrorMessage = "Please specify whether you'll attend")]
        public bool WillAttend { get; set; }
    }
}