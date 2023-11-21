using System.ComponentModel.DataAnnotations;

namespace AppDeEventos.Models
{
    public class Visitante : Usuario
    {
        [Key]
        public int IdVisitante { get; set; }
        public string Cidade { get; set; }
        public string Telefone { get; set; }
        public List<Evento> Eventos { get; set; }
    }
}
