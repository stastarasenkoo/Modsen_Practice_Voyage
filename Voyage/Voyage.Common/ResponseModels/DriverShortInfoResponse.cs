namespace Voyage.Common.ResponseModels
{
    public class DriverShortInfoResponse
    {
        public int UserId { get; set; }

        public string UserFirstName { get; set; } = null!;

        public string UserSecondName { get; set; } = null!;

        public string UserPhoneNumber { get; set; } = null!;
    }
}
