using dotnetsln5.Business;
using dotnetsln5.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetsln5.Controllers
{
    [ApiController]
    [Route("Endereco")]
    public class EnderecoController : Controller
    {
        private readonly ILogger<EnderecoController> _logger;
        private readonly IEnderecoBusiness _business;

        public EnderecoController(ILogger<EnderecoController> logger, IEnderecoBusiness business)
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
        public ActionResult Post([FromBody] Endereco endereco)
        {
            return Ok(_business.Create(endereco));
        }

        [HttpPut]
        public ActionResult Put([FromBody] Endereco endereco)
        {
            return Ok(_business.Edit(endereco));
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            _business.Delete(id);
            return Ok();
        }
    }
}
