using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    public class FuncionarioDepartamentos
    {        
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        [Display(Name = "Requerido Codigo do Funcionario")]
        public int CodigoFuncionario { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        [Display(Name = "Requerido Codigo do Departamento")]
        public int CodigoDepartamento { get; set; }

        public Funcionario Funcionario { get; set; }
        public Departamento Departamento { get; set; }
    }
}
