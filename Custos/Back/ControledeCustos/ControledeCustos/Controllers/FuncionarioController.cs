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
    [Route("api/Funcionario")]
    [EnableCors("PoliticSecurity")]
    public class FuncionarioController : Controller
    {
        private readonly IFuncionarioBusiness FuncionarioBusiness;
        // GET: api/Funcionario
        public FuncionarioController()
        {
            FuncionarioBusiness = new FuncionarioBusiness();
        }
        [HttpGet]
        [Route("GetFuncionarios")]
        public IEnumerable<Funcionario> GetFuncionarios()
        {
            return FuncionarioBusiness.GetFuncionarios();
        }

        [HttpGet]
        [Route("GetFuncionario")]
        public Funcionario GetFuncionarios(int pCodigo)
        {
            return FuncionarioBusiness.GetFuncionario(pCodigo);
        }

        [HttpGet]
        public string Get()
        {
            return "ATIVO";

        }

        [HttpPost]
        [Route("Post")]
        public Resultado Post([FromBody] Funcionario pObject)
        {
            return FuncionarioBusiness.Insert(pObject);
        }

        [HttpPut]
        [Route("Put")]
        public Resultado Put([FromBody] Funcionario pObject)
        {
            return FuncionarioBusiness.Update(pObject);
        }

        [HttpDelete]
        [Route("Delete")]
        public Resultado Delete(int pCodigo)
        {
            return FuncionarioBusiness.Delete(pCodigo);
        }
    }
}
