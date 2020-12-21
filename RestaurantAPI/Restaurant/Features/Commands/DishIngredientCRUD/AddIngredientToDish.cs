using MediatR;
using Restaurant.Data;
using Restaurant.Data.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.Features.Commands.DishIngredientCRUD
{
    public class AddIngredientToDish
    {
        public class Command : IRequest<bool>
        {
            public int DishId { get; set; }
            public int IngredientId { get; set; }

            public Command(int dishId, int ingredientId)
            {
                DishId = dishId;
                IngredientId = ingredientId;
            }
        }

        public class Handler : IRequestHandler<AddIngredientToDish.Command, bool>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<bool> Handle(Command command, CancellationToken cancellationToken)
            {
                var dishIngredient = new DishIngredient
                {
                    DishId = command.DishId,
                    IngredientId = command.IngredientId
                };
                _context.DishIngredients.Add(dishIngredient);
                await _context.SaveChangesAsync();
                return true;
            }
        }
    }
}