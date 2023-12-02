using System.ComponentModel.DataAnnotations;

namespace AppDeEventos.Models
{
    public class Administrador : Usuario
    {
        [Key]
        public int IdAdministrador { get; set; }
        public Boolean Organizador { get; set; }
    }
}
