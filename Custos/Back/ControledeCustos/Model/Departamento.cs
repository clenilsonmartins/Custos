using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    public class Departamento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Display(Name = "Requerido Codigo do Departamento")]
        public int Codigo { get; set; }

        [Required]
        [Display(Name = "Requerido Nome do Departamento")]
        [MaxLength(100, ErrorMessage = "No máximo {1} caracteres no campo {0} ")]
        public string Nome { get; set; }

    }
}
