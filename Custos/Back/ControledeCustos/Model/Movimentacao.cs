using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    public class Movimentacao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Display(Name = "Requerido Codigo da Movimentacao")]
        public int Codigo { get; set; }

        [Required]
        [Display(Name = "Requerido Codigo do Funcionario")]
        [ForeignKey("Funcionario")]
        public int CodigoFuncionario { get; set; }

        [Required]
        [Display(Name = "Requerido Codigo do Departamento")]
        [ForeignKey("Departamento")]
        public int CodigoDepartamento{ get; set; }

        [Required]
        [Display(Name = "Requerido Data da Movimentação")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataMovimentacao  { get; set; }

        [Required]
        [Display(Name = "Requerido Data da Movimentação")]
        [DataType("decimal(15,2)")]
        public decimal Valor { get; set; }


        [MaxLength(500, ErrorMessage = "No máximo {1} caracteres no campo {0} ")]
        public string Descricao { get; set; }

        public Funcionario Funcionario { get; set; }
        public Departamento Departamento { get; set; }
    }
}
