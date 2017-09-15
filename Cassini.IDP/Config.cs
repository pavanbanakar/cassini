using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Cassini.IDP
{
    public static class Config
    {
        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>()
            {

                new TestUser
                {
                SubjectId = "C525A66D-7792-4822-B817-004EBD8BD684",
                Username = "admin1",
                Password = "password",
                Claims = new List<Claim>
                {
                    new Claim("first_name","adminfirstname"),
                    new Claim("last_name","adminlastname")
                },
               

                },
                 new TestUser
                {
                SubjectId = "C752A91F-5961-4BEE-B4B0-008BDC7EBB92",
                Username = "admin2",
                Password = "password",
                Claims = new List<Claim>
                {
                    new Claim("first_name","admin2firstname"),
                    new Claim("last_name","admin2lastname")
                }

                }
            };
        }

        public static List<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>()
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()

            };
        }

        public static List<Client> GetClients()
        {
            return new List<Client> {
                new Client
                {
                    ClientName = "Cassini WebClient",
                   ClientId = "cassiniwebclient",
                   AllowedGrantTypes = GrantTypes.Hybrid,
                   RedirectUris = new List<string>
                   {
                       "https://localhost:44344/signin-oidc"
                   },
                   AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    }
                }
            };
        }
    }
}
