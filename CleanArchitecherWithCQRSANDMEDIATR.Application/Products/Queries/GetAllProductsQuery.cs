using CleanArchitecherWithCQRSANDMEDIATR.Domain.Eintity;
using CleanArchitecherWithCQRSANDMEDIATR.Infrastructure.Data;
using MediatR;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecherWithCQRSANDMEDIATR.Application.Products.Queries
{
    public record GetAllProductsQuery : IRequest<List<Product>>;

    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<Product>>
    {
        private readonly ApplicationDbContext _context;

        public GetAllProductsQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Products.ToListAsync(cancellationToken);
        }
    }
}
