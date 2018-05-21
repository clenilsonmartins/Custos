using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.Repositories
{

    public interface IFuncionarioRepository : IRepository<Funcionario>
    {
        Funcionario Get(int pCodigo);
    }
}
