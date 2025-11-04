using CleanArchitecherWithCQRSANDMEDIATR.Domain.Eintity;
using CleanArchitecherWithCQRSANDMEDIATR.Infrastructure.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecherWithCQRSANDMEDIATR.Application.Products.Queries
{
    public record GetProductByIdQuery : IRequest<Product?>
    {
        public int Id { get; set; }
    }

    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product?>
    {
        private readonly ApplicationDbContext _context;
        public GetProductByIdQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Product?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Products.FindAsync(new object?[] { request.Id }, cancellationToken);
        }
    }
}