using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public interface IDepartamentoBusiness 
    {
        IEnumerable<Departamento> GetDepartamentos();
        Departamento GetDepartamento(int pCodigo);
        Resultado Insert(Departamento pObject);
        Resultado Update(Departamento pObject);
        Resultado Delete(int pCodigo);

    }
}
