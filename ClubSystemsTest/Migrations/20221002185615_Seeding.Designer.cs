// <auto-generated />
using ClubSystemsTest;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ClubSystemsTest.Migrations
{
    [DbContext(typeof(MemberContext))]
    [Migration("20221002185615_Seeding")]
    partial class Seeding
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.9");

            modelBuilder.Entity("ClubSystemsTest.Client", b =>
                {
                    b.Property<int>("ClientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Forename")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ClientID");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("ClubSystemsTest.Membership", b =>
                {
                    b.Property<int>("MembershipID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Balance")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClientID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MembershipTypeID")
                        .HasColumnType("INTEGER");

                    b.HasKey("MembershipID");

                    b.HasIndex("ClientID");

                    b.HasIndex("MembershipTypeID");

                    b.ToTable("Memberships");
                });

            modelBuilder.Entity("ClubSystemsTest.MembershipType", b =>
                {
                    b.Property<int>("MembershipTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MembershipTypeID");

                    b.ToTable("MembershipTypes");
                });

            modelBuilder.Entity("ClubSystemsTest.Membership", b =>
                {
                    b.HasOne("ClubSystemsTest.Client", "client")
                        .WithMany("memberships")
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClubSystemsTest.MembershipType", "membershipType")
                        .WithMany()
                        .HasForeignKey("MembershipTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("client");

                    b.Navigation("membershipType");
                });

            modelBuilder.Entity("ClubSystemsTest.Client", b =>
                {
                    b.Navigation("memberships");
                });
#pragma warning restore 612, 618
        }
    }
}
