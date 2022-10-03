namespace ClubSystemsTest
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;

    public class MemberContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Membership> Memberships { get; set; }  
        public DbSet<MembershipType> MembershipTypes { get; set; }  

        public string DbPath { get; }

        public MemberContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "member.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }

    public class Client
    {
        public int ClientID { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public List<Membership> memberships { get; set; }
    }
    
    public class Membership
    {
        public int MembershipID { get; set; }
        public int ClientID { get; set; }
        public Client client { get; set; }
        public int MembershipTypeID { get; set; }
        public MembershipType membershipType { get; set; }
        public int Balance { get; set; } //in pence
    }

    public class MembershipType
    {
        public int MembershipTypeID { get; set; }
        public string Name { get; set; }
    }
}
