using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IFuncionarioRepository FuncionarioRepository { get; }
        IDepartamentoRepository DepartamentoRepository { get; }
        IMovimentacaoRepository MovimentacaoRepository { get; }
        void Commit();
    }
}



