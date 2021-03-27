using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardOperationsController : ControllerBase
    {
        private ICardOperationService _cardOperationService;

        public CardOperationsController(ICardOperationService cardOperationService)
        {
            _cardOperationService = cardOperationService;
        }

        [HttpGet("getall")]

        public IActionResult GetAll()
        {
            var result = _cardOperationService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]

        public IActionResult GetById(int id)
        {
            var result = _cardOperationService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("add")]

        public IActionResult Add(CardOperation operation)
        {
            var result = _cardOperationService.Add(operation);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("update")]

        public IActionResult Update(CardOperation operation)
        {
            var result = _cardOperationService.Update(operation);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("delete")]

        public IActionResult Delete(CardOperation operation)
        {
            var result = _cardOperationService.Delete(operation);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }
    }
}
