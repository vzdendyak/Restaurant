using AutoMapper;
using Restaurant.BLL.BusinessLogic.Interfaces;
using Restaurant.BLL.Data.DTOs;
using Restaurant.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.BLL.BusinessLogic
{
    public class IngredientBl : IIngredientBl
    {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IMapper _mapper;

        public IngredientBl(IIngredientRepository ingredientRepository, IMapper mapper)
        {
            _ingredientRepository = ingredientRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<IngredientDto>> GetByName(string name)
        {
            var ingredient = await _ingredientRepository.GetByName(name);
            return _mapper.Map<IEnumerable<IngredientDto>>(ingredient);
        }
    }
}