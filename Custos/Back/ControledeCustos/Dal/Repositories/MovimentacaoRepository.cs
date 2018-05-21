using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dal.Repositories
{
    public class MovimentacaoRepository : IMovimentacaoRepository
    {
        CustosContexto m_Context = null;

        public MovimentacaoRepository(CustosContexto context)
        {
            m_Context = context;
        }

        public IEnumerable<Movimentacao> GetAll(System.Linq.Expressions.Expression<Func<Movimentacao, bool>> predicate = null)
        {            
            if (predicate != null)
            {
                return m_Context.Movimentacao.Where(predicate);
            }
            else
            {
                return m_Context.Movimentacao;
            }

        }

        public Movimentacao Get(System.Linq.Expressions.Expression<Func<Movimentacao, bool>> predicate)
        {
            return m_Context.Movimentacao.SingleOrDefault(predicate);
        }


        public Movimentacao Get(int pCodigo)
        {
            return m_Context.Movimentacao.SingleOrDefault(Qry => Qry.Codigo == pCodigo);
        }

        public void Insert(Movimentacao entity)
        {
            m_Context.Movimentacao.Add(entity);
        }

        public void Update(Movimentacao entity)
        {
            var vObject = m_Context.Movimentacao.Where(Qry => Qry.Codigo == entity.Codigo).Single();
            vObject.CodigoDepartamento = entity.CodigoDepartamento;
            vObject.CodigoFuncionario = entity.CodigoFuncionario;
            vObject.DataMovimentacao = entity.DataMovimentacao;
            vObject.Descricao = entity.Descricao;
            vObject.Valor = entity.Valor;
        }

        public void Delete(Movimentacao entity)
        {
            var vObject = m_Context.Movimentacao.Where(Qry => Qry.Codigo == entity.Codigo).Single();
            m_Context.Movimentacao.Remove(vObject);
        }

        public int Count()
        {
            return m_Context.Movimentacao.Count();
        }
    }
}
