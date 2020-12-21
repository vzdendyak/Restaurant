using MediatR;
using Restaurant.Data;
using Restaurant.Data.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.Features.Commands.OrderCRUD
{
    public class CreateOrder
    {
        public class Command : IRequest<bool>
        {
            public Order Order { get; set; }

            public Command(Order order)
            {
                Order = order;
            }
        }

        public class Handler : IRequestHandler<CreateOrder.Command, bool>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<bool> Handle(Command command, CancellationToken cancellationToken)
            {
                await _context.Orders.AddAsync(command.Order);
                await _context.SaveChangesAsync();
                return true;
            }
        }
    }
}