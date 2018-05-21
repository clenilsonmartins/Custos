using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.Repositories
{
    public interface IMovimentacaoRepository : IRepository<Movimentacao>
    {
        Movimentacao Get(int pCodigo);
    }
}
