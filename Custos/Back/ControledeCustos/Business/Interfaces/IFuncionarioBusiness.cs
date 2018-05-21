using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public interface IFuncionarioBusiness
    {
        IEnumerable<Funcionario> GetFuncionarios();
        Funcionario GetFuncionario(int pCodigo);
        Resultado Insert(Funcionario pObject);
        Resultado Update(Funcionario pObject);
        Resultado Delete(int pCodigo);
    }
}
