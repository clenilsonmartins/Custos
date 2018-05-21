using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace ControledeCustos.Controllers
{
    [Route("api/Movimentacao")]
    [EnableCors("PoliticSecurity")]
    public class MovimentacaoController : Controller
    {
        private readonly IMovimentacaoBusiness MovimentacaoBusiness;
        // GET: api/Movimentacao
        public MovimentacaoController()
        {
            MovimentacaoBusiness = new MovimentacaoBusiness();
        }
        [HttpGet]
        [Route("GetMovimentacaos")]
        public IEnumerable<Movimentacao> GetMovimentacaos()
        {
            return MovimentacaoBusiness.GetMovimentacoes();
        }

        [HttpGet]
        [Route("GetMovimentacao")]
        public Movimentacao GetMovimentacaos(int pCodigo)
        {
            return MovimentacaoBusiness.GetMovimentacao(pCodigo);
        }

        [HttpGet]
        public string Get()
        {
            return "ATIVO";

        }

        [HttpPost]
        [Route("Post")]
        public Resultado Post([FromBody] Movimentacao pObject)
        {
            return MovimentacaoBusiness.Insert(pObject);
        }

        [HttpPut]
        [Route("Put")]
        public Resultado Put([FromBody] Movimentacao pObject)
        {
            return MovimentacaoBusiness.Update(pObject);
        }

        [HttpDelete]
        [Route("Delete")]
        public Resultado Delete(int pCodigo)
        {
            return MovimentacaoBusiness.Delete(pCodigo);
        }
    }
}
