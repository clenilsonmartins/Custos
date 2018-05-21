using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Business
{
    public static class Library
    {
        public static IEnumerable<ValidationResult> GetValidationErrors(object obj)
        {
            var resultadoValidacao = new List<ValidationResult>();
            var contexto = new ValidationContext(obj, null, null);
            Validator.TryValidateObject(obj, contexto, resultadoValidacao, true);
            return resultadoValidacao;
        }

        public static Resultado Validation(object pObject)
        {
            Resultado vResultado = new Resultado();
            var errors = Library.GetValidationErrors(pObject);
            if (errors.Any())
            {
                foreach (var erro in errors)
                {
                    vResultado.Inconsistencias.Add(erro.ErrorMessage);
                }
            }
            return vResultado;
        }
    }
}
