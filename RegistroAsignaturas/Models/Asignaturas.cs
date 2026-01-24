using System.ComponentModel.DataAnnotations;

namespace RegistroAsignaturas.Models
{
    public class Asignaturas
    {
        [Key]
        public int AsignaturaId { get; set; }

        [Required(ErrorMessage = "Campo obligatorio.")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "Campo obligatorio.")]
        public int Creditos { get; set; }   

        [Required(ErrorMessage = "Campo obligatorio.")]
        public string Codigo { get; set; } = string.Empty;

        [Required(ErrorMessage = "Campo obligatorio.")]
        public string Aula { get; set; } = string.Empty;
       
    }
}
