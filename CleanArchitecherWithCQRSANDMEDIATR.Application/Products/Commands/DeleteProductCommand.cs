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
    public record DeleteProductCommand : IRequest<Product>
    {
        public int Id { get; set; }
    }
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand,Product>
    {
        private readonly ApplicationDbContext _context;

        public DeleteProductCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product>Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var DeletedProduct = await _context.Products.FindAsync(request.Id);

            _context.Products.Remove(DeletedProduct);
            await _context.SaveChangesAsync(cancellationToken);
            return DeletedProduct;
        }
    }
}
