﻿// <auto-generated />
using System;
using FoodJournalWebApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FoodJournalWebApp.Migrations
{
    [DbContext(typeof(FoodJournalWebAppContext))]
    [Migration("20240117014140_AddMeal")]
    partial class AddMeal
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FoodJournalWebApp.Models.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("MealId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MealId");

                    b.ToTable("Ingredient");
                });

            modelBuilder.Entity("FoodJournalWebApp.Models.Meal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<int?>("WellnessCheckId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WellnessCheckId");

                    b.ToTable("Meal");
                });

            modelBuilder.Entity("FoodJournalWebApp.Models.PhysiologicalFeedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descriptor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sentiment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PhysiologicalFeedback");
                });

            modelBuilder.Entity("FoodJournalWebApp.Models.WellnessCheck", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PhysiologicalFeedbackId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PhysiologicalFeedbackId");

                    b.ToTable("WellnessCheck");
                });

            modelBuilder.Entity("FoodJournalWebApp.Models.Ingredient", b =>
                {
                    b.HasOne("FoodJournalWebApp.Models.Meal", null)
                        .WithMany("Ingredients")
                        .HasForeignKey("MealId");
                });

            modelBuilder.Entity("FoodJournalWebApp.Models.Meal", b =>
                {
                    b.HasOne("FoodJournalWebApp.Models.WellnessCheck", "WellnessCheck")
                        .WithMany()
                        .HasForeignKey("WellnessCheckId");

                    b.Navigation("WellnessCheck");
                });

            modelBuilder.Entity("FoodJournalWebApp.Models.WellnessCheck", b =>
                {
                    b.HasOne("FoodJournalWebApp.Models.PhysiologicalFeedback", "PhysiologicalFeedback")
                        .WithMany()
                        .HasForeignKey("PhysiologicalFeedbackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PhysiologicalFeedback");
                });

            modelBuilder.Entity("FoodJournalWebApp.Models.Meal", b =>
                {
                    b.Navigation("Ingredients");
                });
#pragma warning restore 612, 618
        }
    }
}