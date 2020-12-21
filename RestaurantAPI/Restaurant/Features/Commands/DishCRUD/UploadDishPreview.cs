using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.Features.Commands.DishCRUD
{
    public class UploadDishPreview
    {
        public class Command : IRequest<bool>
        {
            public IFormFile File { get; set; }
            public int DishId { get; set; }

            public Command(IFormFile file, int dishId)
            {
                File = file;
                DishId = dishId;
            }
        }

        public class Handler : IRequestHandler<UploadDishPreview.Command, bool>
        {
            private AppDbContext _context;

            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<bool> Handle(Command command, CancellationToken cancellationToken)
            {
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                var dish = await _context.Dishes.Where(dep => dep.Id == command.DishId).FirstOrDefaultAsync();
                if (command.File.Length == 0 || dish == null)
                    return false;

                var fileName = ContentDispositionHeaderValue.Parse(command.File.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(pathToSave, fileName);
                var dbPath = Path.Combine(folderName, fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    command.File.CopyTo(stream);
                }
                dish.PreviewPath = dbPath;
                _context.Dishes.Update(dish);
                await _context.SaveChangesAsync();
                return true;
            }
        }
    }
}