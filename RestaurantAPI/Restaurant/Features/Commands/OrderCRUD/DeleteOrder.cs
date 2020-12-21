using MediatR;
using Restaurant.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.Features.Commands.OrderCRUD
{
    public class DeleteOrder
    {
        public class Command : IRequest<bool>
        {
            public int OrderId { get; set; }

            public Command(int orderId)
            {
                OrderId = orderId;
            }
        }

        public class Handler : IRequestHandler<DeleteOrder.Command, bool>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<bool> Handle(Command command, CancellationToken cancellationToken)
            {
                var result = await _context.Orders.FindAsync(command.OrderId);
                if (result != null)
                {
                    _context.Orders.Remove(result);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
        }
    }
}