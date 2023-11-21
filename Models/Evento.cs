using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AppDeEventos.Models
{
    public class Evento
    {
        [Key]
        public int IdEvento { get; set; }
        public Administrador Organizador { get; set; }
        public int OrganizadorId { get; set; }
        public string Palestrante { get; set; }
        public string titulo { get; set; }
        public string descricao { get; set; }
        public string Banner { get; set; }
        public string Local { get; set; }
        public DateOnly Data { get; set; }
        public double Duracao { get; set; }
        public int numMaxParticipantes { get; set; }
        public int Disponivel { get; set; }
        [JsonIgnore]
        public List<Visitante> ListaParticipantes{ get; set; }
    }
}
