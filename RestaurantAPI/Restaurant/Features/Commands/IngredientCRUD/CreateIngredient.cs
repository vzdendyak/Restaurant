using MediatR;
using Restaurant.Data;
using Restaurant.Data.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.Features.Commands.IngredientCRUD
{
    public class CreateIngredient
    {
        public class Command : IRequest<bool>
        {
            public Ingredient Ingredient { get; set; }

            public Command(Ingredient ingredient)
            {
                Ingredient = ingredient;
            }
        }

        public class Handler : IRequestHandler<CreateIngredient.Command, bool>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<bool> Handle(Command command, CancellationToken cancellationToken)
            {
                await _context.Ingredients.AddAsync(command.Ingredient);
                await _context.SaveChangesAsync();
                return true;
            }
        }
    }
}