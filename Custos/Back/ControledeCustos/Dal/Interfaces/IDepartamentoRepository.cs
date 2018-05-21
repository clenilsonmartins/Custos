using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.Repositories
{
    public interface IDepartamentoRepository : IRepository<Departamento>
    {
        Departamento Get(int pCodigo);
    }
}
