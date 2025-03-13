using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
namespace Semana4.Models
{
    public class EnfermeroModel
    {
        [Key]
        public int IdEnfermero { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(25, ErrorMessage = "Máximo 25 caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [RegularExpression(@"^\d{8,15}$", ErrorMessage = "Formato inválido (8-15 dígitos)")]
        public string Telefono_Enfermero { get; set; }

        [Required(ErrorMessage = "La especialidad es requerida")]
        public int EspecialidadId { get; set; }

        [ForeignKey("EspecialidadId")]
        public virtual EspecialidadModel Especialidad { get; set; }
        public virtual ICollection<TratamientoModel> Tratamientos { get; set; }
    
}
}
