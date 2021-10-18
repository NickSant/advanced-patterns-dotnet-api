using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoShop2._0.Domain.Commands.Request
{
    public class DeleteBookRequest : IRequest<string>
    { 
        [FromRoute]
        public Guid Id { get; set; }
    }
}
