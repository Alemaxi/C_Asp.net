using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetsln5.Business;
using dotnetsln5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace dotnetsln5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly ILogger<PessoaController> _logger;
        private readonly IPessoaBusiness _business;

        public PessoaController(ILogger<PessoaController> logger, IPessoaBusiness business)
        {
            _logger = logger;
            _business = business;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_business.FindAll());
        }

        [HttpGet("{id}")]
        public ActionResult Get(long id)
        {
            return Ok(_business.FindByID(id));
        }

        [HttpPost]
        public ActionResult Post([FromBody] Pessoa pessoa)
        {
            return Ok(_business.Create(pessoa));
        }

        [HttpPut]
        public ActionResult Put([FromBody] Pessoa pessoa)
        {
            return Ok(_business.Edit(pessoa));
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            _business.Delete(id);
            return Ok();
        }

        
    }
}
