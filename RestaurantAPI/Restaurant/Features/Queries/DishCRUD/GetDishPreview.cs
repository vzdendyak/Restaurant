using MedClinicalAPI.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.Features.Queries.DishCRUD
{
    public class GetDishPreview
    {
        public class Query : IRequest<string>
        {
            public int Id { get; set; }

            public Query(int id)
            {
                Id = id;
            }
        }

        public class Handler : IRequestHandler<GetDishPreview.Query, string>
        {
            private readonly AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<string> Handle(Query request, CancellationToken cancellationToken)
            {
                var dish = await _context.Dishes.Where(dep => dep.Id == request.Id).FirstOrDefaultAsync();
                if (dish == null)
                    throw new NotFoundException("Department not found");

                return dish.PreviewPath;
            }
        }
    }
}