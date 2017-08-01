using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using restaurante.Configuration;

namespace restaurante.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20170728132244_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("restaurante.Models.Pratos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao");

                    b.Property<string>("Foto");

                    b.Property<string>("Nome");

                    b.Property<decimal>("Preco");

                    b.Property<int>("RestauranteId");

                    b.HasKey("Id");

                    b.HasIndex("RestauranteId");

                    b.ToTable("tb_prato");
                });

            modelBuilder.Entity("restaurante.Models.Restaurante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Endereco");

                    b.Property<string>("Logo");

                    b.Property<string>("Nome");

                    b.Property<string>("Telefone");

                    b.HasKey("Id");

                    b.ToTable("tb_restaurante");
                });

            modelBuilder.Entity("restaurante.Models.Pratos", b =>
                {
                    b.HasOne("restaurante.Models.Restaurante", "Restaurante")
                        .WithMany("Pratos")
                        .HasForeignKey("RestauranteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
