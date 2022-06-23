namespace Voyage.Common.RequestModels
{
    public class RegisterModelRequest
    {
        public string FirstName { get; set; } = null!;

        public string SeconName { get; set; } = null!;

        public string? Thirdname { get; set; } 

        public string UserName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
}
