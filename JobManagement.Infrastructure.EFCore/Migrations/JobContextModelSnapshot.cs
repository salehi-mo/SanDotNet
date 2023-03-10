// <auto-generated />
using System;
using JobManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JobManagement.Infrastructure.EFCore.Migrations
{
    [DbContext(typeof(JobContext))]
    partial class JobContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JobManagement.Domain.PersonAgg.Person", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CodMelli")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Fam")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("Nam")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("NamPed")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("NoShe")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<long>("PerId")
                        .HasColumnType("bigint");

                    b.Property<long?>("PersonEshtegVazId")
                        .HasColumnType("bigint");

                    b.Property<long?>("PersonOzvNoaId")
                        .HasColumnType("bigint");

                    b.Property<long?>("QorbId")
                        .HasColumnType("bigint");

                    b.Property<long?>("QorbMoasId")
                        .HasColumnType("bigint");

                    b.Property<long?>("QorbMoasPorId")
                        .HasColumnType("bigint");

                    b.Property<long?>("QorbMoasPorKarId")
                        .HasColumnType("bigint");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.HasKey("Id");

                    b.HasIndex("PersonEshtegVazId");

                    b.HasIndex("PersonOzvNoaId");

                    b.HasIndex("QorbId");

                    b.HasIndex("QorbMoasId");

                    b.HasIndex("QorbMoasPorId");

                    b.HasIndex("QorbMoasPorKarId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("JobManagement.Domain.PersonEshtegVazAgg.PersonEshtegVaz", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<long>("PersonEshtegVazId")
                        .HasColumnType("bigint");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.HasKey("Id");

                    b.ToTable("PersonEshtegVazs");
                });

            modelBuilder.Entity("JobManagement.Domain.PersonOzvNoaAgg.PersonOzvNoa", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<long>("PersonOzvNoaId")
                        .HasColumnType("bigint");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.HasKey("Id");

                    b.ToTable("PersonOzvNoas");
                });

            modelBuilder.Entity("JobManagement.Domain.QorbAgg.Qorb", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<long>("QorbId_sana")
                        .HasColumnType("bigint");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.HasKey("Id");

                    b.ToTable("Qorbs");
                });

            modelBuilder.Entity("JobManagement.Domain.QorbMoasAgg.QorbMoas", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<long>("QorbId")
                        .HasColumnType("bigint");

                    b.Property<long>("QorbMoasId_sana")
                        .HasColumnType("bigint");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.HasKey("Id");

                    b.HasIndex("QorbId");

                    b.ToTable("QorbMoass");
                });

            modelBuilder.Entity("JobManagement.Domain.QorbMoasPorAgg.QorbMoasPor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<long>("QorbMoasId")
                        .HasColumnType("bigint");

                    b.Property<long>("QorbMoasPorId_sana")
                        .HasColumnType("bigint");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.HasKey("Id");

                    b.HasIndex("QorbMoasId");

                    b.ToTable("QorbMoasPors");
                });

            modelBuilder.Entity("JobManagement.Domain.QorbMoasPorKarAgg.QorbMoasPorKar", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<long>("QorbMoasPorId")
                        .HasColumnType("bigint");

                    b.Property<long>("QorbMoasPorKarId_sana")
                        .HasColumnType("bigint");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.HasKey("Id");

                    b.HasIndex("QorbMoasPorId");

                    b.ToTable("QorbMoasPorKars");
                });

            modelBuilder.Entity("JobManagement.Domain.PersonAgg.Person", b =>
                {
                    b.HasOne("JobManagement.Domain.PersonEshtegVazAgg.PersonEshtegVaz", "PersonEshtegVaz")
                        .WithMany("Persons")
                        .HasForeignKey("PersonEshtegVazId");

                    b.HasOne("JobManagement.Domain.PersonOzvNoaAgg.PersonOzvNoa", "PersonOzvNoa")
                        .WithMany("Persons")
                        .HasForeignKey("PersonOzvNoaId");

                    b.HasOne("JobManagement.Domain.QorbAgg.Qorb", "Qorb")
                        .WithMany("Persons")
                        .HasForeignKey("QorbId");

                    b.HasOne("JobManagement.Domain.QorbMoasAgg.QorbMoas", "QorbMoas")
                        .WithMany("Persons")
                        .HasForeignKey("QorbMoasId");

                    b.HasOne("JobManagement.Domain.QorbMoasPorAgg.QorbMoasPor", "QorbMoasPor")
                        .WithMany("Persons")
                        .HasForeignKey("QorbMoasPorId");

                    b.HasOne("JobManagement.Domain.QorbMoasPorKarAgg.QorbMoasPorKar", "QorbMoasPorKar")
                        .WithMany("Persons")
                        .HasForeignKey("QorbMoasPorKarId");
                });

            modelBuilder.Entity("JobManagement.Domain.QorbMoasAgg.QorbMoas", b =>
                {
                    b.HasOne("JobManagement.Domain.QorbAgg.Qorb", "Qorb")
                        .WithMany("QorbMoass")
                        .HasForeignKey("QorbId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JobManagement.Domain.QorbMoasPorAgg.QorbMoasPor", b =>
                {
                    b.HasOne("JobManagement.Domain.QorbMoasAgg.QorbMoas", "QorbMoas")
                        .WithMany("QorbMoasPors")
                        .HasForeignKey("QorbMoasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JobManagement.Domain.QorbMoasPorKarAgg.QorbMoasPorKar", b =>
                {
                    b.HasOne("JobManagement.Domain.QorbMoasPorAgg.QorbMoasPor", "QorbMoasPor")
                        .WithMany("QorbMoasPorKars")
                        .HasForeignKey("QorbMoasPorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
