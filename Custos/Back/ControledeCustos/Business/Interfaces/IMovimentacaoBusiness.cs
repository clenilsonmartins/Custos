using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public interface IMovimentacaoBusiness
    {
        IEnumerable<Movimentacao> GetMovimentacoes();
        Movimentacao GetMovimentacao(int pCodigo);
        Resultado Insert(Movimentacao pObject);
        Resultado Update(Movimentacao pObject);
        Resultado Delete(int pCodigo);
    }
}
