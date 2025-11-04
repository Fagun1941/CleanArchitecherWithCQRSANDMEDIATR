using CleanArchitecherWithCQRSANDMEDIATR.Domain.Eintity;
using CleanArchitecherWithCQRSANDMEDIATR.Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecherWithCQRSANDMEDIATR.Application.Products.Commands
{
    public record UpdateProductCommand : IRequest<Product>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    };
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Product>
    {
        private readonly ApplicationDbContext _context;
        public UpdateProductCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product>Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FindAsync(request.Id);

            product.Name = request.Name;
            product.Price = request.Price;
            product.Stock = request.Stock;

            await _context.SaveChangesAsync(cancellationToken);
            return product;
        }
    }
    
}
