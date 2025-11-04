using CleanArchitecherWithCQRSANDMEDIATR.Domain.Eintity;
using CleanArchitecherWithCQRSANDMEDIATR.Infrastructure.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecherWithCQRSANDMEDIATR.Application.Products.Commands
{
    public record CreateProductCommand : IRequest<Product>
    {
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    };

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand,Product>
    {
        private readonly ApplicationDbContext _context;
        public CreateProductCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Product> Handle(CreateProductCommand requst, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = requst.Name,
                Price = requst.Price,
                Stock = requst.Stock
            };
            _context.Products.Add(product);
            await _context.SaveChangesAsync(cancellationToken);
            return product;
        }
    }

}
