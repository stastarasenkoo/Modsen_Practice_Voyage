using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;

namespace Voyage.DataAccess.Helpers
{
    public static class ConfigureIdentity
    {
        public static IEnumerable<ApiResource> ApiResources =>
           new List<ApiResource>
           {
               new ApiResource("Voyage", "API")
               {
                    UserClaims =
                    {
                        JwtClaimTypes.Audience,
                        JwtClaimTypes.Role,
                    },
                    Scopes =
                    {
                        "Voyage"
                    },
               }
           };

        public static IEnumerable<IdentityResource> IdentityResources =>
           new List<IdentityResource>
           {
               new IdentityResources.OpenId(),
               new IdentityResources.Profile(),
           };

        public static IEnumerable<ApiScope> ApiScopes =>
           new List<ApiScope>
           {
                new ApiScope("Voyage","Voyage")
           };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId="swagger",
                    AllowedGrantTypes= GrantTypes.ResourceOwnerPassword,
                    ClientSecrets=
                    {
                        new Secret("eb300de4-add9-42f4-a3ac-abd3c60f1919".Sha256())
                    },
                    RedirectUris=
                    { 
                        "https://localhost:5084" 
                    },
                    AllowedScopes=
                    {
                    "Voyage",
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile
                    }
                }
            };
    }
}
