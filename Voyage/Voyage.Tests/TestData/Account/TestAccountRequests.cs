using Voyage.Common.RequestModels.Account;

namespace Voyage.Tests.TestData.Account
{
    public class TestAccountRequests
    {
        public static SignUpRequestModel Register =>
           new SignUpRequestModel
           {
               FirstName = "First",
               SecondName = "Second",
               ThirdName = null,
               Email = "user@m.com",
               Password = "password",
               PhoneNumber = "12-34-56",
               UserName = "User1"
           };
    }
}
