using System.ComponentModel.DataAnnotations;

namespace RegistroTiposPuntos.Models
{
    public class TiposPuntos
    {
        [Key]
        public int TipoId { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "La descripción es obligatoria")]
        public string Descripcion { get; set; } = string.Empty;

        [Required(ErrorMessage = "El valor de puntos es obligatorio")]
        public int ValorPuntos { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un color")]
        public string Color { get; set; } = string.Empty;

        [Required(ErrorMessage = "Debe seleccionar un icono")]
        public string Icono { get; set; } = string.Empty;

        public bool Activo { get; set; } = true;
    }
}
