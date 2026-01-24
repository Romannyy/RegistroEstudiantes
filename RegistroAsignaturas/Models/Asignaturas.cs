using System.ComponentModel.DataAnnotations;

namespace RegistroAsignaturas.Models
{
    public class Asignaturas
    {
        [Key]
        public int AsignaturaId { get; set; }

        [Required(ErrorMessage = "Nombre de asignatura obligatorio.")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "Créditos obligatorios.")]
        [Range(1, 10, ErrorMessage = "Los créditos deben estar entre 1 y 10.")]
        public int Creditos { get; set; } = 1;

        [Required(ErrorMessage = "Código de asignatura obligatorio.")]
        public string Codigo { get; set; } = string.Empty;

        [Required(ErrorMessage = "La asignatura debe tener un aula.")]
        public string Aula { get; set; } = string.Empty;
       
    }
}
