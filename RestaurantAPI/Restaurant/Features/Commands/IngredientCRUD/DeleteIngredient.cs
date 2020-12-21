using MediatR;
using Restaurant.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.Features.Commands.IngredientCRUD
{
    public class DeleteIngredient
    {
        public class Command : IRequest<bool>
        {
            public int IngredientId { get; set; }

            public Command(int ingredientId)
            {
                IngredientId = ingredientId;
            }
        }

        public class Handler : IRequestHandler<DeleteIngredient.Command, bool>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<bool> Handle(Command command, CancellationToken cancellationToken)
            {
                var result = await _context.Ingredients.FindAsync(command.IngredientId);
                if (result != null)
                {
                    _context.Ingredients.Remove(result);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
        }
    }
}