﻿// <auto-generated />
using System;
using ExamManagementAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ExamManagementAPI.Migrations
{
    [DbContext(typeof(AppDataContext))]
    partial class AppDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ExamManagementAPI.Models.Exam", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedBy")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExamName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("TotalScore")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedBy")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("ExamManagementAPI.Models.ObjectiveQuestion", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedBy")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExamId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Question")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuestionNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedBy")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ExamId");

                    b.ToTable("ObjectiveQuestions");
                });

            modelBuilder.Entity("ExamManagementAPI.Models.QuestionOptions", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedBy")
                        .HasColumnType("datetime2");

                    b.Property<string>("ObjectiveQuestionId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("OptionContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OptionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedBy")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ObjectiveQuestionId");

                    b.ToTable("QuestionOptions");
                });

            modelBuilder.Entity("ExamManagementAPI.Models.TheoryQuestion", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedBy")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExamId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Question")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuestionNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedBy")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ExamId");

                    b.ToTable("TheoryQuestions");
                });

            modelBuilder.Entity("ExamManagementAPI.Models.ObjectiveQuestion", b =>
                {
                    b.HasOne("ExamManagementAPI.Models.Exam", null)
                        .WithMany("ObjectiveQuestions")
                        .HasForeignKey("ExamId");
                });

            modelBuilder.Entity("ExamManagementAPI.Models.QuestionOptions", b =>
                {
                    b.HasOne("ExamManagementAPI.Models.ObjectiveQuestion", null)
                        .WithMany("QuestionOptions")
                        .HasForeignKey("ObjectiveQuestionId");
                });

            modelBuilder.Entity("ExamManagementAPI.Models.TheoryQuestion", b =>
                {
                    b.HasOne("ExamManagementAPI.Models.Exam", null)
                        .WithMany("TheoryQuestions")
                        .HasForeignKey("ExamId");
                });

            modelBuilder.Entity("ExamManagementAPI.Models.Exam", b =>
                {
                    b.Navigation("ObjectiveQuestions");

                    b.Navigation("TheoryQuestions");
                });

            modelBuilder.Entity("ExamManagementAPI.Models.ObjectiveQuestion", b =>
                {
                    b.Navigation("QuestionOptions");
                });
#pragma warning restore 612, 618
        }
    }
}
