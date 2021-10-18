using MediatR;
using MongoShop2._0.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoShop2._0.Domain.Commands.Request
{
    public class UpdateBookRequest: IRequest<Book>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
        public string Author { get; set; }

        public static implicit operator Book(UpdateBookRequest target) 
            => target is null ? null : new()
            {
                Author = target.Author,
                Category = target.Category,
                Name = target.Name,
                Price = target.Price
            };
    }
}
