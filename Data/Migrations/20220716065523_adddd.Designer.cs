﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using movieapplication.Data;

#nullable disable

namespace movieapplication.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220716065523_adddd")]
    partial class adddd
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("movieapplication.Model.Actor", b =>
                {
                    b.Property<int>("ActorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ActorId"), 1L, 1);

                    b.Property<string>("ActorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ActorId");

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("movieapplication.Model.Movie", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MovieId"), 1L, 1);

                    b.Property<string>("MovieName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProducerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MovieId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("movieapplication.Model.MovieActorId", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AIdNavigationActorId")
                        .HasColumnType("int");

                    b.Property<int>("ActorIds")
                        .HasColumnType("int");

                    b.Property<int>("MIdNavigationMovieId")
                        .HasColumnType("int");

                    b.Property<int>("MovieIds")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AIdNavigationActorId");

                    b.HasIndex("MIdNavigationMovieId");

                    b.ToTable("MoviesActorIds");
                });

            modelBuilder.Entity("movieapplication.Model.MovieActorId", b =>
                {
                    b.HasOne("movieapplication.Model.Actor", "AIdNavigation")
                        .WithMany()
                        .HasForeignKey("AIdNavigationActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("movieapplication.Model.Movie", "MIdNavigation")
                        .WithMany()
                        .HasForeignKey("MIdNavigationMovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AIdNavigation");

                    b.Navigation("MIdNavigation");
                });
#pragma warning restore 612, 618
        }
    }
}