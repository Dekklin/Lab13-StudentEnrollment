﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentEnrollment.Data;

namespace StudentEnrollment.Migrations
{
    [DbContext(typeof(StudentDB))]
    partial class StudentDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StudentEnrollment.Models.Classes", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Subject");

                    b.Property<string>("Teacher");

                    b.HasKey("ID");

                    b.ToTable("Class");
                });

            modelBuilder.Entity("StudentEnrollment.Models.Student", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClassID");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("ClassID");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("StudentEnrollment.Models.Student", b =>
                {
                    b.HasOne("StudentEnrollment.Models.Classes", "Class")
                        .WithMany()
                        .HasForeignKey("ClassID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
