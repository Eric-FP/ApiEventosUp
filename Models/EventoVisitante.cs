using System.ComponentModel.DataAnnotations;

namespace AppDeEventos.Models
{
    public class EventoVisitante
    {
        [Key]
        public int Id { get; set; }
        public Visitante Visitante { get; set; }
        public int IdVisitante { get; set; }
        public Administrador Administrador { get; set; }
        public int IdAdministrador { get; set; }
    }
}
