using Model;
using System;

namespace Dal.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private CustosContexto _contexto = null;
        private FuncionarioRepository funcionarioRepository = null;
        private DepartamentoRepository departamentoRepository = null;
        private MovimentacaoRepository movimentacaoRepository = null;

        public UnitOfWork()
        {
            _contexto = new CustosContexto();
        }

        public void Commit()
        {
            _contexto.SaveChanges();
        }

        public IFuncionarioRepository FuncionarioRepository
        {
            get
            {
                if (funcionarioRepository == null)
                {
                    funcionarioRepository = new FuncionarioRepository(_contexto);
                }
                return funcionarioRepository;
            }
        }
        public IDepartamentoRepository DepartamentoRepository
        {
            get
            {
                if (departamentoRepository == null)
                {
                    departamentoRepository = new DepartamentoRepository(_contexto);
                }
                return departamentoRepository;
            }
        }
        public IMovimentacaoRepository MovimentacaoRepository
        {
            get
            {
                if (movimentacaoRepository == null)
                {
                    movimentacaoRepository = new MovimentacaoRepository(_contexto);
                }
                return movimentacaoRepository;
            }
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _contexto.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
