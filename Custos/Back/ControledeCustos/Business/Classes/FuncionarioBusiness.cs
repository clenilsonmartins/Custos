using Dal.Repositories;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class FuncionarioBusiness :IFuncionarioBusiness
    {
        private readonly UnitOfWork uow;

        public FuncionarioBusiness()
        {
            uow = new UnitOfWork();
        }

        public FuncionarioBusiness(UnitOfWork unitOfWork)
        {
            uow = unitOfWork;
        }

        public IEnumerable<Funcionario> GetFuncionarios()
        {
            return uow.FuncionarioRepository.GetAll();
        }

        public Funcionario GetFuncionario(int pCodigo)
        {
            return uow.FuncionarioRepository.Get(pCodigo);
        }

        public Resultado Insert(Funcionario pObject)
        {
            var resultado = Library.Validation(pObject);
            resultado.Acao = "Inclusão de Funcionario";
            var vFuncionario = uow.FuncionarioRepository.Get(pObject.Codigo);

            if ((vFuncionario != null) && (vFuncionario.Codigo > 0))
            {
                resultado.Inconsistencias.Add(
                    "Código de Funcionario já cadastrado");
            }

            if ((vFuncionario.Departamentos == null) && (vFuncionario.Departamentos.Count == 0))
            {
                resultado.Inconsistencias.Add(
                    "DEverá Ser Selecionado Pelo Menos Um Departamento");
            }

            if (resultado.Inconsistencias.Count == 0)
            {
                uow.FuncionarioRepository.Insert(pObject);
                uow.Commit();
            }

            return resultado;

        }

        public Resultado Update(Funcionario pObject)
        {
            var resultado = Library.Validation(pObject);
            resultado.Acao = "Atualização de Produto";

            if (resultado.Inconsistencias.Count == 0)
            {
                var vFuncionario = uow.FuncionarioRepository.Get(pObject.Codigo);

                if (vFuncionario == null)
                {
                    resultado.Inconsistencias.Add(
                        "Funcionario não encontrado");
                }
                else
                {
                    uow.FuncionarioRepository.Update(pObject);
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
                var vFuncionario = uow.FuncionarioRepository.Get(pCodigo);
                if (vFuncionario == null)
                {
                    resultado.Inconsistencias.Add(
                        "Funcionario não encontrado");
                }
                else
                {
                    uow.FuncionarioRepository.Delete(vFuncionario);
                    uow.Commit();
                }
            }

            return resultado;
        }

    }
}
