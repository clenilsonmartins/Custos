using Dal.Repositories;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Business
{
    public class DepartamentoBusiness : IDepartamentoBusiness
    //: IDepartamentoBusiness
    {
        private readonly UnitOfWork uow;

        public DepartamentoBusiness()
        {
            uow = new UnitOfWork();
        }

        public DepartamentoBusiness(UnitOfWork unitOfWork)
        {
            uow = unitOfWork;
        }

        public IEnumerable<Departamento> GetDepartamentos()
        {
            return uow.DepartamentoRepository.GetAll();
        }

        public Departamento GetDepartamento(int pCodigo)
        {
            return uow.DepartamentoRepository.Get(pCodigo);

        }

        public Resultado Insert(Departamento pObject)
        {
            var resultado = Library.Validation(pObject);
            resultado.Acao = "Inclusão de Departamento";
            var vDepartamento = uow.DepartamentoRepository.Get(pObject.Codigo);

            if ((vDepartamento != null) && (vDepartamento.Codigo > 0))
            {
                resultado.Inconsistencias.Add(
                    "Código de Departamento já cadastrado");
            }

            if (resultado.Inconsistencias.Count == 0)
            {
                uow.DepartamentoRepository.Insert(pObject);
                uow.Commit();
            }

            return resultado;

        }

        public Resultado Update(Departamento pObject)
        {
            var resultado = Library.Validation(pObject);
            resultado.Acao = "Atualização de Produto";

            if (resultado.Inconsistencias.Count == 0)
            {
                var vDepartamento = uow.DepartamentoRepository.Get(pObject.Codigo);

                if (vDepartamento == null)
                {
                    resultado.Inconsistencias.Add(
                        "Departamento não encontrado");
                }
                else
                {
                    uow.DepartamentoRepository.Update(pObject);
                    uow.Commit();
                }
            }

            return resultado;
        }

        public Resultado Delete(int pCodigo)
        {


            var resultado = new Resultado();
            resultado.Acao = "Exclusão de Produto";

            if (resultado.Inconsistencias.Count == 0)
            {
                var vDepartamento = uow.DepartamentoRepository.Get(pCodigo);

                if (vDepartamento == null)
                {
                    resultado.Inconsistencias.Add(
                        "Departamento não encontrado");
                }
                else
                {
                    uow.DepartamentoRepository.Delete(vDepartamento);
                    uow.Commit();
                }
            }

            return resultado;
        }
    }
}
