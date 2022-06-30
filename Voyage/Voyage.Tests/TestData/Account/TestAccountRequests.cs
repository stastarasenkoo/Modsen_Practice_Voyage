using Voyage.Common.RequestModels;

namespace Voyage.Tests.TestData.Account
{
    public class TestAccountRequests
    {
        public static RegisterModelRequest Register =>
           new RegisterModelRequest
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
