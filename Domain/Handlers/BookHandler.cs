using MediatR;
using MongoShop2._0.Contexts;
using MongoShop2._0.Data;
using MongoShop2._0.Domain.Commands.Request;
using MongoShop2._0.Domain.Entities;
using MongoShop2._0.Domain.Queries.Requests;
using MongoShop2._0.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MongoShop2._0.Domain.Handlers
{
    public class BookHandler : IRequestHandler<GetBookRequest, Book>, 
                               IRequestHandler<GetBooksRequest, IEnumerable<Book>>,
                               IRequestHandler<AddBookRequest, Book>,
                               IRequestHandler<UpdateBookRequest, Book>,
                               IRequestHandler<DeleteBookRequest, string>
    {
        private readonly IUnitOfWork<Book> _uow;
        public BookHandler(IUnitOfWork<Book> uow) => _uow = uow;

        public async Task<Book> Handle(GetBookRequest request, CancellationToken cancellationToken) => await _uow.Repository.GetOne(request.Id);

        public async Task<IEnumerable<Book>> Handle(GetBooksRequest request, CancellationToken cancellationToken) => await _uow.Repository.Get();

        public Task<Book> Handle(AddBookRequest request, CancellationToken cancellationToken)
        {
            var book = _uow.Repository.Create(request);
            _uow.SaveChangesAsync();
            return Task.FromResult(book);
        }

        public Task<Book> Handle(UpdateBookRequest request, CancellationToken cancellationToken)
        {
            var book = _uow.Repository.Update(request);
            _uow.SaveChangesAsync();

            return Task.FromResult(book);
        }

        public Task<string> Handle(DeleteBookRequest request, CancellationToken cancellationToken)
        {
            _uow.Repository.Delete(request.Id);
            _uow.SaveChangesAsync();

            return Task.FromResult("Book successfuly deleted");
        }
    }
}
