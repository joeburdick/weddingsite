using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using wedding.Repositories;

namespace wedding.Migrations
{
    [DbContext(typeof(RSVPContext))]
    partial class RSVPContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("wedding.Models.RSVP", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Attending");

                    b.Property<int>("Chicken");

                    b.Property<string>("Names");

                    b.Property<int>("Salmon");

                    b.Property<int>("TriTip");

                    b.HasKey("Id");

                    b.ToTable("RSVPs");
                });
        }
    }
}
