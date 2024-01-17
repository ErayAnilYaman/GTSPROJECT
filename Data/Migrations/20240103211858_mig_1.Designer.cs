﻿// <auto-generated />
using System;
using Data.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(ThesesContext))]
    [Migration("20240103211858_mig_1")]
    partial class mig_1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Data.Models.Author", b =>
                {
                    b.Property<int>("AUTHORID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AUTHORID"));

                    b.Property<string>("AUTHORNAME")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("EMAIL")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("LASTNAME")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("AUTHORID");

                    b.ToTable("AUTHORS");
                });

            modelBuilder.Entity("Data.Models.CoSupervisorThesis", b =>
                {
                    b.Property<int>("COSUPERVISORTHESISID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("COSUPERVISORTHESISID"));

                    b.Property<int>("SUPERVISORID")
                        .HasColumnType("int");

                    b.Property<int>("THESISID")
                        .HasColumnType("int");

                    b.HasKey("COSUPERVISORTHESISID");

                    b.HasIndex("SUPERVISORID");

                    b.HasIndex("THESISID");

                    b.ToTable("COSUPERVISORTHESIS");
                });

            modelBuilder.Entity("Data.Models.Institute", b =>
                {
                    b.Property<int>("INSTITUTEID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("INSTITUTEID"));

                    b.Property<string>("NAME")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("INSTITUTEID");

                    b.ToTable("INSTITUTES");
                });

            modelBuilder.Entity("Data.Models.Keyword", b =>
                {
                    b.Property<int>("KEYWORDID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KEYWORDID"));

                    b.Property<string>("KEYWORD")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("KEYWORDID");

                    b.ToTable("KEYWORDS");
                });

            modelBuilder.Entity("Data.Models.SubjectTopic", b =>
                {
                    b.Property<int>("TOPICID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TOPICID"));

                    b.Property<string>("TOPICNAME")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("TOPICID");

                    b.ToTable("SUBJECTTOPICS");
                });

            modelBuilder.Entity("Data.Models.Supervisor", b =>
                {
                    b.Property<int>("SUPERVISORID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SUPERVISORID"));

                    b.Property<string>("EMAIL")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("FIRSTNAME")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("LASTNAME")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("TITLE")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("SUPERVISORID");

                    b.ToTable("SUPERVISORS");
                });

            modelBuilder.Entity("Data.Models.Thesis", b =>
                {
                    b.Property<int>("THESISID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("THESISID"));

                    b.Property<string>("ABSTRACT")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("AUTHORID")
                        .HasColumnType("int");

                    b.Property<int>("INSTITUTEID")
                        .HasColumnType("int");

                    b.Property<string>("LANGUAGE")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("NUMBER")
                        .HasColumnType("int");

                    b.Property<int>("PAGES")
                        .HasColumnType("int");

                    b.Property<DateTime>("SUBMISSIONDATE")
                        .HasColumnType("datetime2");

                    b.Property<int>("SUPERVISORID")
                        .HasColumnType("int");

                    b.Property<int>("THESISYEAR")
                        .HasColumnType("int");

                    b.Property<string>("TITLE")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("TYPE")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("UNIVERSITYID")
                        .HasColumnType("int");

                    b.HasKey("THESISID");

                    b.HasIndex("AUTHORID");

                    b.HasIndex("INSTITUTEID");

                    b.HasIndex("SUPERVISORID");

                    b.HasIndex("UNIVERSITYID");

                    b.ToTable("THESES");
                });

            modelBuilder.Entity("Data.Models.ThesisKeyword", b =>
                {
                    b.Property<int>("THESISKEYWORDID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("THESISKEYWORDID"));

                    b.Property<int>("KEYWORDID")
                        .HasColumnType("int");

                    b.Property<int>("THESISID")
                        .HasColumnType("int");

                    b.HasKey("THESISKEYWORDID");

                    b.HasIndex("KEYWORDID");

                    b.HasIndex("THESISID");

                    b.ToTable("THESISKEYWORD");
                });

            modelBuilder.Entity("Data.Models.ThesisSubjectTopic", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("SUBJECTTOPICTOPICID")
                        .HasColumnType("int");

                    b.Property<int>("THESISID")
                        .HasColumnType("int");

                    b.Property<int>("TOPICID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("SUBJECTTOPICTOPICID");

                    b.HasIndex("THESISID");

                    b.ToTable("THESISSUBJECTTOPIC");
                });

            modelBuilder.Entity("Data.Models.University", b =>
                {
                    b.Property<int>("UNIVERSITYID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UNIVERSITYID"));

                    b.Property<string>("NAME")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("UNIVERSITYID");

                    b.ToTable("UNIVERSITIES");
                });

            modelBuilder.Entity("Data.Models.CoSupervisorThesis", b =>
                {
                    b.HasOne("Data.Models.Supervisor", "SUPERVISOR")
                        .WithMany("COSUPERVISORTHESES")
                        .HasForeignKey("SUPERVISORID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Models.Thesis", "THESIS")
                        .WithMany("COSUPERVISORTHESES")
                        .HasForeignKey("THESISID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SUPERVISOR");

                    b.Navigation("THESIS");
                });

            modelBuilder.Entity("Data.Models.Thesis", b =>
                {
                    b.HasOne("Data.Models.Author", "AUTHOR")
                        .WithMany("THESES")
                        .HasForeignKey("AUTHORID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Models.Institute", "INSTITUTE")
                        .WithMany("THESES")
                        .HasForeignKey("INSTITUTEID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Models.Supervisor", "SUPERVISOR")
                        .WithMany()
                        .HasForeignKey("SUPERVISORID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Models.University", "UNIVERSITY")
                        .WithMany("THESES")
                        .HasForeignKey("UNIVERSITYID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AUTHOR");

                    b.Navigation("INSTITUTE");

                    b.Navigation("SUPERVISOR");

                    b.Navigation("UNIVERSITY");
                });

            modelBuilder.Entity("Data.Models.ThesisKeyword", b =>
                {
                    b.HasOne("Data.Models.Keyword", "KEYWORD")
                        .WithMany("THESISKEYWORDS")
                        .HasForeignKey("KEYWORDID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Models.Thesis", "THESIS")
                        .WithMany("THESISKEYWORDS")
                        .HasForeignKey("THESISID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KEYWORD");

                    b.Navigation("THESIS");
                });

            modelBuilder.Entity("Data.Models.ThesisSubjectTopic", b =>
                {
                    b.HasOne("Data.Models.SubjectTopic", "SUBJECTTOPIC")
                        .WithMany("THESISSUBJECTTOPCIS")
                        .HasForeignKey("SUBJECTTOPICTOPICID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Models.Thesis", "THESIS")
                        .WithMany("THESISSUBJECTTOPICS")
                        .HasForeignKey("THESISID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SUBJECTTOPIC");

                    b.Navigation("THESIS");
                });

            modelBuilder.Entity("Data.Models.Author", b =>
                {
                    b.Navigation("THESES");
                });

            modelBuilder.Entity("Data.Models.Institute", b =>
                {
                    b.Navigation("THESES");
                });

            modelBuilder.Entity("Data.Models.Keyword", b =>
                {
                    b.Navigation("THESISKEYWORDS");
                });

            modelBuilder.Entity("Data.Models.SubjectTopic", b =>
                {
                    b.Navigation("THESISSUBJECTTOPCIS");
                });

            modelBuilder.Entity("Data.Models.Supervisor", b =>
                {
                    b.Navigation("COSUPERVISORTHESES");
                });

            modelBuilder.Entity("Data.Models.Thesis", b =>
                {
                    b.Navigation("COSUPERVISORTHESES");

                    b.Navigation("THESISKEYWORDS");

                    b.Navigation("THESISSUBJECTTOPICS");
                });

            modelBuilder.Entity("Data.Models.University", b =>
                {
                    b.Navigation("THESES");
                });
#pragma warning restore 612, 618
        }
    }
}
