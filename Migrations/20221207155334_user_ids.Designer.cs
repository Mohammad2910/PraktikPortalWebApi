// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PraktikPortalWebApi.EfCore;

#nullable disable

namespace PraktikPortalWebApi.Migrations
{
    [DbContext(typeof(EF_DataContext))]
    [Migration("20221207155334_user_ids")]
    partial class user_ids
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PraktikPortalWebApi.EfCore.Internship", b =>
                {
                    b.Property<int>("InternshipId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("InternshipId"));

                    b.Property<int>("CompanySupervisor_id")
                        .HasColumnType("integer");

                    b.Property<int>("DTUSupervisor_id")
                        .HasColumnType("integer");

                    b.Property<string>("InternshipCompany")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("InternshipName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("user_id")
                        .HasColumnType("integer");

                    b.HasKey("InternshipId");

                    b.HasIndex("CompanySupervisor_id");

                    b.HasIndex("DTUSupervisor_id");

                    b.HasIndex("user_id");

                    b.ToTable("internship");
                });

            modelBuilder.Entity("PraktikPortalWebApi.EfCore.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("type")
                        .HasColumnType("integer");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("user");
                });

            modelBuilder.Entity("PraktikPortalWebApi.EfCore.Internship", b =>
                {
                    b.HasOne("PraktikPortalWebApi.EfCore.User", "CompanyUser")
                        .WithMany()
                        .HasForeignKey("CompanySupervisor_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PraktikPortalWebApi.EfCore.User", "DTUUser")
                        .WithMany()
                        .HasForeignKey("DTUSupervisor_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PraktikPortalWebApi.EfCore.User", "User")
                        .WithMany()
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CompanyUser");

                    b.Navigation("DTUUser");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
