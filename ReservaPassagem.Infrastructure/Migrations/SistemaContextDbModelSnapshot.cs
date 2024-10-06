﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReservaPassagem.Infrastructure.Data.Context;

#nullable disable

namespace ReservaPassagem.Infrastructure.Migrations
{
    [DbContext(typeof(SistemaContextDb))]
    partial class SistemaContextDbModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ReservaPassagem.Domain.Entities.Assento", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Classe")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Disponivel")
                        .HasColumnType("bit");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("ReservaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("VooId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ReservaId");

                    b.HasIndex("VooId");

                    b.ToTable("Assentos");
                });

            modelBuilder.Entity("ReservaPassagem.Domain.Entities.Reserva", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PassageiroId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("StatusReserva")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("VooId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PassageiroId");

                    b.HasIndex("VooId");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("ReservaPassagem.Domain.Entities.Voo", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Chegada")
                        .HasMaxLength(50)
                        .HasColumnType("datetime2");

                    b.Property<string>("CompanhiaAerea")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("NumeroVoo")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("Partida")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Voos");
                });

            modelBuilder.Entity("ReservaPassagem.Domain.Passageiro", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Email");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Telefone");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Passageiro", (string)null);
                });

            modelBuilder.Entity("ReservaPassagem.Domain.Entities.Assento", b =>
                {
                    b.HasOne("ReservaPassagem.Domain.Entities.Reserva", "Reserva")
                        .WithMany("Assentos")
                        .HasForeignKey("ReservaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ReservaPassagem.Domain.Entities.Voo", "Voo")
                        .WithMany("Assentos")
                        .HasForeignKey("VooId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reserva");

                    b.Navigation("Voo");
                });

            modelBuilder.Entity("ReservaPassagem.Domain.Entities.Reserva", b =>
                {
                    b.HasOne("ReservaPassagem.Domain.Passageiro", "Passageiro")
                        .WithMany("Reservas")
                        .HasForeignKey("PassageiroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReservaPassagem.Domain.Entities.Voo", "Voo")
                        .WithMany("Reservas")
                        .HasForeignKey("VooId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Passageiro");

                    b.Navigation("Voo");
                });

            modelBuilder.Entity("ReservaPassagem.Domain.Entities.Voo", b =>
                {
                    b.OwnsOne("ReservaPassagem.Domain.ValueObjects.Destino", "Destino", b1 =>
                        {
                            b1.Property<Guid>("VooId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Cidade")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Pais")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("VooId");

                            b1.ToTable("Voos");

                            b1.WithOwner()
                                .HasForeignKey("VooId");
                        });

                    b.OwnsOne("ReservaPassagem.Domain.ValueObjects.Origem", "Origem", b1 =>
                        {
                            b1.Property<Guid>("VooId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Cidade")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Pais")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("VooId");

                            b1.ToTable("Voos");

                            b1.WithOwner()
                                .HasForeignKey("VooId");
                        });

                    b.Navigation("Destino")
                        .IsRequired();

                    b.Navigation("Origem")
                        .IsRequired();
                });

            modelBuilder.Entity("ReservaPassagem.Domain.Passageiro", b =>
                {
                    b.OwnsOne("ReservaPassagem.Domain.ValueObjects.Nome", "Nome", b1 =>
                        {
                            b1.Property<Guid>("PassageiroId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("PrimeiroNome")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("NVARCHAR")
                                .HasColumnName("Primeiro Nome");

                            b1.Property<string>("UltimoNome")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("NVARCHAR")
                                .HasColumnName("Ultimo Nome");

                            b1.HasKey("PassageiroId");

                            b1.ToTable("Passageiro");

                            b1.WithOwner()
                                .HasForeignKey("PassageiroId");
                        });

                    b.Navigation("Nome")
                        .IsRequired();
                });

            modelBuilder.Entity("ReservaPassagem.Domain.Entities.Reserva", b =>
                {
                    b.Navigation("Assentos");
                });

            modelBuilder.Entity("ReservaPassagem.Domain.Entities.Voo", b =>
                {
                    b.Navigation("Assentos");

                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("ReservaPassagem.Domain.Passageiro", b =>
                {
                    b.Navigation("Reservas");
                });
#pragma warning restore 612, 618
        }
    }
}
