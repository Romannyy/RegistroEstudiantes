
using System.ComponentModel.DataAnnotations;
namespace RegistroEstudiantes.Models
{
    public class Estudiantes
    {
        [Key]
        public int EstudianteId { get; set; }
        public string Nombres { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
