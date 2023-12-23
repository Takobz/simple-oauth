﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimpleAuthServer.Data;

#nullable disable

namespace auth_server.Migrations
{
    [DbContext(typeof(AuthServerContext))]
    partial class AuthServerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("SimpleAuthServer.Data.Entities.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ClientSecret")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ClientUri")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Contacts")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("GrantTypes")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LogoUri")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RedirectUris")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ResponseTypes")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Scope")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TokenEndpointAuthMethod")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TosUri")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });
#pragma warning restore 612, 618
        }
    }
}
