using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data;
using Restaurant.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.Features.Queries.DishCRUD
{
    public class GetAllDishes
    {
        public class Query : IRequest<IEnumerable<Dish>>
        {
        }

        public class Handler : IRequestHandler<GetAllDishes.Query, IEnumerable<Dish>>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Dish>> Handle(Query request, CancellationToken cancellationToken)
            {
                var dishes = await _context.Dishes
                    .Select(d => new Dish
                    {
                        Id = d.Id,
                        Name = d.Name,
                        Description = d.Description,
                        Price = d.Price,
                        DishIngredients = d.DishIngredients.Select(di => new DishIngredient
                        {
                            DishId = di.DishId,
                            IngredientId = di.IngredientId
                        }).ToList(),
                    }).ToListAsync();
                return dishes;
            }
        }
    }
}