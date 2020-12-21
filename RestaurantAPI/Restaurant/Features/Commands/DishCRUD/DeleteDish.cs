using MediatR;
using Restaurant.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.Features.Commands.DishCRUD
{
    public class DeleteDish
    {
        public class Command : IRequest<bool>
        {
            public int DishId { get; set; }

            public Command(int dishId)
            {
                DishId = dishId;
            }
        }

        public class Handler : IRequestHandler<DeleteDish.Command, bool>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<bool> Handle(Command command, CancellationToken cancellationToken)
            {
                var result = await _context.Dishes.FindAsync(command.DishId);
                if (result != null)
                {
                    _context.Dishes.Remove(result);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
        }
    }
}