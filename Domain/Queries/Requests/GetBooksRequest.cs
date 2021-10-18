using MediatR;
using MongoShop2._0.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoShop2._0.Domain.Queries.Requests
{
    public class GetBooksRequest : IRequest<IEnumerable<Book>>
    {
    }
}
