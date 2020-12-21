using MediatR;
using Restaurant.Data;
using Restaurant.Data.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.Features.Commands.DishCRUD
{
    public class CreateDish
    {
        public class Command : IRequest<bool>
        {
            public Dish Dish { get; set; }

            public Command(Dish dish)
            {
                Dish = dish;
            }
        }

        public class Handler : IRequestHandler<CreateDish.Command, bool>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<bool> Handle(Command command, CancellationToken cancellationToken)
            {
                await _context.Dishes.AddAsync(command.Dish);
                await _context.SaveChangesAsync();
                return true;
            }
        }
    }
}