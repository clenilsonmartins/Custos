using Dal.Repositories;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{

    public class MovimentacaoBusiness : IMovimentacaoBusiness
    {
        private readonly UnitOfWork uow;

        public MovimentacaoBusiness()
        {
            uow = new UnitOfWork();
        }

        public MovimentacaoBusiness(UnitOfWork unitOfWork)
        {
            uow = unitOfWork;
        }

        public IEnumerable<Movimentacao> GetMovimentacoes()
        {
            return uow.MovimentacaoRepository.GetAll();
        }

        public Movimentacao GetMovimentacao(int pCodigo)
        {
            return uow.MovimentacaoRepository.Get(pCodigo);
        }


        public Resultado Insert(Movimentacao pObject)
        {
            var resultado = Library.Validation(pObject);
            resultado.Acao = "Inclusão de Movimentacao";
            var vMovimentacao = uow.MovimentacaoRepository.Get(pObject.Codigo);

            if ((vMovimentacao != null) && (vMovimentacao.Codigo > 0))
            {
                resultado.Inconsistencias.Add(
                    "Código de Movimentacao já cadastrado");
            }

            if (resultado.Inconsistencias.Count == 0)
            {
                uow.MovimentacaoRepository.Insert(pObject);
                uow.Commit();
            }

            return resultado;

        }

        public Resultado Update(Movimentacao pObject)
        {
            var resultado = Library.Validation(pObject);
            resultado.Acao = "Atualização de Produto";

            if (resultado.Inconsistencias.Count == 0)
            {
                var vMovimentacao = uow.MovimentacaoRepository.Get(pObject.Codigo);

                if (vMovimentacao == null)
                {
                    resultado.Inconsistencias.Add(
                        "Movimentacao não encontrado");
                }
                else
                {
                    uow.MovimentacaoRepository.Update(pObject);
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
                var vMovimentacao = uow.MovimentacaoRepository.Get(pCodigo);

                if (vMovimentacao == null)
                {
                    resultado.Inconsistencias.Add(
                        "Movimentacao não encontrado");
                }
                else
                {
                    uow.MovimentacaoRepository.Delete(vMovimentacao);
                    uow.Commit();
                }
            }

            return resultado;
        }

    }

}
