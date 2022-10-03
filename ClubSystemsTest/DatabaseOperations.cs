using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Security.Cryptography.X509Certificates;

namespace ClubSystemsTest
{
    public class DatabaseOperations
    {
        public static List<Client> GetClientList()
        {
            using (var context = new MemberContext())
            {
                var clients = context.Clients.ToList();

                return clients;
            }
        }

        public static List<Membership> GetMembershipsFromClient(int clientId)
        {
            using (var context = new MemberContext())
            {
                var memberships = context.Memberships
                    .Where(membership => membership.ClientID == clientId)
                    .Include(membership => membership.membershipType)
                    .ToList();

                return memberships;
            }
        }

        public static List<Membership> GetMembershipsNegativeBalance()
        {
            using (var context = new MemberContext())
            {
                var memberships = context.Memberships
                    .Where(membership => membership.Balance < 0)
                    .Include(membership => membership.client)
                    .Include(membership => membership.membershipType)
                    .ToList();

                return memberships;

            }

        }
    }
}
