using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dal.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        CustosContexto m_Context = null;

        public FuncionarioRepository(CustosContexto context)
        {
            m_Context = context;
        }

        public IEnumerable<Funcionario> GetAll(System.Linq.Expressions.Expression<Func<Funcionario, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return m_Context.Funcionario.Where(predicate);
            }
            else
            {
                return m_Context.Funcionario;
            }
        }

        public Funcionario Get(int pCodigo)
        {
            return m_Context.Funcionario.SingleOrDefault(Qry => Qry.Codigo == pCodigo);
        }

        public Funcionario Get(System.Linq.Expressions.Expression<Func<Funcionario, bool>> predicate)
        {
            return m_Context.Funcionario.SingleOrDefault(predicate);
        }

        public void Insert(Funcionario entity)
        {
            m_Context.Funcionario.Add(entity);
        }

        public void Update(Funcionario entity)
        {
            var vObject = m_Context.Funcionario.Where(Qry => Qry.Codigo == entity.Codigo).Single();
            vObject.Nome = entity.Nome;
            vObject.Email = entity.Email;
        }

        public void Delete(Funcionario entity)
        {
            var vObject = m_Context.Funcionario.Where(Qry => Qry.Codigo == entity.Codigo).Single();
            m_Context.Funcionario.Remove(vObject);
        }

        public int Count()
        {
            return m_Context.Funcionario.Count();
        }
    }
}
