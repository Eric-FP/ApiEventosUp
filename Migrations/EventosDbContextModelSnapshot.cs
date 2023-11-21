﻿// <auto-generated />
using System;
using AppDeEventos.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AppDeEventos.Migrations
{
    [DbContext(typeof(EventosDbContext))]
    partial class EventosDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AppDeEventos.Models.Administrador", b =>
                {
                    b.Property<int>("IdAdministrador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdAdministrador"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Organizador")
                        .HasColumnType("boolean");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("IdAdministrador");

                    b.ToTable("Administradores");
                });

            modelBuilder.Entity("AppDeEventos.Models.Evento", b =>
                {
                    b.Property<int>("IdEvento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdEvento"));

                    b.Property<string>("Banner")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("Data")
                        .HasColumnType("date");

                    b.Property<int>("Disponivel")
                        .HasColumnType("integer");

                    b.Property<double>("Duracao")
                        .HasColumnType("double precision");

                    b.Property<string>("Local")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("OrganizadorId")
                        .HasColumnType("integer");

                    b.Property<string>("Palestrante")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("numMaxParticipantes")
                        .HasColumnType("integer");

                    b.Property<string>("titulo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("IdEvento");

                    b.HasIndex("OrganizadorId");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("AppDeEventos.Models.EventoVisitante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AdministradorIdAdministrador")
                        .HasColumnType("integer");

                    b.Property<int>("IdAdministrador")
                        .HasColumnType("integer");

                    b.Property<int>("IdVisitante")
                        .HasColumnType("integer");

                    b.Property<int>("VisitanteIdVisitante")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AdministradorIdAdministrador");

                    b.HasIndex("VisitanteIdVisitante");

                    b.ToTable("EventoVisitantes");
                });

            modelBuilder.Entity("AppDeEventos.Models.Visitante", b =>
                {
                    b.Property<int>("IdVisitante")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdVisitante"));

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("IdVisitante");

                    b.ToTable("Visitantes");
                });

            modelBuilder.Entity("EventoVisitante", b =>
                {
                    b.Property<int>("EventosIdEvento")
                        .HasColumnType("integer");

                    b.Property<int>("ListaParticipantesIdVisitante")
                        .HasColumnType("integer");

                    b.HasKey("EventosIdEvento", "ListaParticipantesIdVisitante");

                    b.HasIndex("ListaParticipantesIdVisitante");

                    b.ToTable("EventoVisitante");
                });

            modelBuilder.Entity("AppDeEventos.Models.Evento", b =>
                {
                    b.HasOne("AppDeEventos.Models.Administrador", "Organizador")
                        .WithMany()
                        .HasForeignKey("OrganizadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organizador");
                });

            modelBuilder.Entity("AppDeEventos.Models.EventoVisitante", b =>
                {
                    b.HasOne("AppDeEventos.Models.Administrador", "Administrador")
                        .WithMany()
                        .HasForeignKey("AdministradorIdAdministrador")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppDeEventos.Models.Visitante", "Visitante")
                        .WithMany()
                        .HasForeignKey("VisitanteIdVisitante")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Administrador");

                    b.Navigation("Visitante");
                });

            modelBuilder.Entity("EventoVisitante", b =>
                {
                    b.HasOne("AppDeEventos.Models.Evento", null)
                        .WithMany()
                        .HasForeignKey("EventosIdEvento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppDeEventos.Models.Visitante", null)
                        .WithMany()
                        .HasForeignKey("ListaParticipantesIdVisitante")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}