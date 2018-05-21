using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Newtonsoft.Json.Linq;

namespace ControledeCustos.Controllers
{
    [Route("api/Departamento")]    
    [EnableCors("PoliticSecurity")]
    public class DepartamentoController : Controller
    {
        private readonly IDepartamentoBusiness DepartamentoBusiness;
        // GET: api/Departamento
        public DepartamentoController()
        {
            DepartamentoBusiness = new DepartamentoBusiness();
        }
        [HttpGet]
        [Route("GetDepartamentos")]
        public IEnumerable<Departamento> GetDepartamentos()
        {
            return DepartamentoBusiness.GetDepartamentos();
        }

        [HttpGet]
        [Route("GetDepartamento")]
        public Departamento GetDepartamentos(int pCodigo)
        {
            return DepartamentoBusiness.GetDepartamento(pCodigo);
        }

        [HttpGet]
        public string Get()
        {
            return "ATIVO";
            
        }
              
        [HttpPost]
        [Route("Post")]
        public Resultado Post([FromBody] Departamento pObject)
        {
            return DepartamentoBusiness.Insert(pObject);
        }
                
        [HttpPut]
        [Route("Put")]
        public Resultado Put([FromBody] Departamento pObject)
        {
            return DepartamentoBusiness.Update(pObject);
        }
        
        [HttpDelete]
        [Route("Delete")]
        public Resultado Delete(int pCodigo)
        {
            return DepartamentoBusiness.Delete(pCodigo);
        }
    }
}
