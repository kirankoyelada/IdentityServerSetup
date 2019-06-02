using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Kiran.IDP
{
    public static class Config
    {
        //adding test users
        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId="subject id is sample",
                    Username="kiran",
                    Password="ashok",
                    Claims=new List<Claim>
                    {
                        new Claim("given_name","kiran"),
                        new Claim("family_name","koyelada")
                    }
                }
            };
        }

        //adding scopes
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        //get clients

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>()
            {
                new Client()
                {
                    ClientName="Test MVC Application",
                    ClientId="TestMVCClient",
                    AllowedGrantTypes=GrantTypes.Hybrid,
                    RedirectUris=new List<string>()
                    {
                        "https://localhost:44369/signin-oidc"
                    },
                    PostLogoutRedirectUris=new List<string>()
                    {
                        "https://localhost:44369/signout-callback-oidc"
                    },
                    AllowedScopes =new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile                        
                    },
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    }
                }
            };
        }
    }
}
