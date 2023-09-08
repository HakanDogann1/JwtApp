using AutoMapper;
using JwtApp.API.Persistance.Core.Application.DTOs;
using JwtApp.API.Persistance.Core.Application.Features.CQRS.Commands;
using JwtApp.API.Persistance.Core.Application.Features.CQRS.Queries;
using JwtApp.API.Persistance.Core.Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtApp.API.Controllers
{
    [Authorize(Roles ="Admin,Member")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var result = await _mediator.Send(new GetAllProductQuery());
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result =await _mediator.Send(new GetByIdProductQueryResult(id));
            return result == null?  NoContent():Ok(result);
            
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateProductCommand createProductCommand)
        {
           await _mediator.Send(createProductCommand);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Remove(int id)
        {
            await _mediator.Send(new DeleteProductCommand(id));
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductCommand updateProductCommand)
        {
            await _mediator.Send(updateProductCommand);
            return Ok();
        }
    }
}
