using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dal.Repositories
{
    public class DepartamentoRepository : IDepartamentoRepository
    {
        CustosContexto m_Context = null;

        public DepartamentoRepository(CustosContexto context)
        {
            m_Context = context;
        }

        public IEnumerable<Departamento> GetAll(System.Linq.Expressions.Expression<Func<Departamento, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return m_Context.Departamento.Where(predicate);
            }
            else
            {
                return m_Context.Departamento;
            }
        }

        public Departamento Get(int pCodigo)
        {
            return m_Context.Departamento.SingleOrDefault(Qry=> Qry.Codigo == pCodigo);
        }

        public Departamento Get(System.Linq.Expressions.Expression<Func<Departamento, bool>> predicate)
        {
            return m_Context.Departamento.SingleOrDefault(predicate);
        }

        public void Insert(Departamento entity)
        {
            m_Context.Departamento.Add(entity);
        }

        public void Update(Departamento entity)
        {
            try
            {
                var vObject = m_Context.Departamento.Where(Qry => Qry.Codigo == entity.Codigo).Single();
                vObject.Nome = entity.Nome;

            }
            catch (Exception erro)
            {

                throw new Exception (erro.Message);
            }
        }

        public void Delete(Departamento entity)
        {
            var vObject = m_Context.Departamento.Where(Qry => Qry.Codigo == entity.Codigo).Single();
            m_Context.Departamento.Remove(vObject);
        }

        public int Count()
        {
            return m_Context.Departamento.Count();
        }
    }
}
