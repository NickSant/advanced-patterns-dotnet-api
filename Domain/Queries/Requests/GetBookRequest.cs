using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoShop2._0.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoShop2._0.Domain.Queries.Requests
{
    public class GetBookRequest : IRequest<Book>
    {
        [FromRoute]
        public Guid Id { get; set; }
    }
}
