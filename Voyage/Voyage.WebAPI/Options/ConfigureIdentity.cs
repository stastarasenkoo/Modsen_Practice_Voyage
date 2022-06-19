using IdentityServer4.Models;

namespace Voyage.WebAPI.Options
{
    public static class ConfigureIdentity
    {
        public static IEnumerable<ApiScope> ApiScopes =>
           new List<ApiScope>
           {
                new ApiScope("Voyage.WebApi","Voyage")
           };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId="swagger",
                    AllowedGrantTypes= GrantTypes.ClientCredentials,
                    ClientSecrets={
                        new Secret("eb300de4-add9-42f4-a3ac-abd3c60f1919".Sha256())
                    },
                    AllowedScopes={ "Voyage.WebApi" }
                }
            };
    }
}
