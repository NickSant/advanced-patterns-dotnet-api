using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoShop2._0.Domain.Commands.Request;
using MongoShop2._0.Domain.Entities;
using MongoShop2._0.Domain.Queries.Requests;
using MongoShop2._0.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace MongoShop2._0.Controllers
{
    public class BooksController : BaseController
    {
        public BooksController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        public Task<IActionResult> GetBooks()
        {
            var request = new GetBooksRequest();
            return ExecuteCommand(request);
        } 
       
        [HttpGet("{Id}")]
        public Task<IActionResult> GetBook([FromRoute] GetBookRequest request) => ExecuteCommand(request);

        [HttpPost]
        public Task<IActionResult> AddBook([FromBody] AddBookRequest request) => ExecuteCommand(request);

        [HttpDelete("{Id}")]
        public Task<IActionResult> DeleteBook([FromRoute] DeleteBookRequest request) => ExecuteCommand(request);

        [HttpPut("{id}")]
        public Task<IActionResult> UpdateBook([FromRoute] Guid id, [FromBody]UpdateBookRequest request)
        {
            request.Id = id;
            return ExecuteCommand(request);
        }
    }
}
