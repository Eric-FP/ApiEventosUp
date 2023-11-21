using AppDeEventos.Models;
using Microsoft.EntityFrameworkCore;

namespace AppDeEventos.Data
{
    public class EventosDbContext : DbContext
    {
        public EventosDbContext(DbContextOptions<EventosDbContext> options) : base(options) { 
        
        }
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Visitante> Visitantes { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<EventoVisitante> EventoVisitantes { get; set; }
    }
}
