namespace LostPropertyOffice.Service.Controllers.Entities
{
    public class UserFilter
    {
        public string? Role { get; set; }
        public string? LoginPart { get; set; }
        public string? PhoneNumberPart { get; set; }
        public string? EmailPart { get; set; }
        public string? Position { get; set; }
    }
}