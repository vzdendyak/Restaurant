using AutoMapper;
using MedClinicalAPI.Exceptions;
using Restaurant.BLL.BusinessLogic.Interfaces;
using Restaurant.BLL.Data.DTOs;
using Restaurant.DAL.Data.Models;
using Restaurant.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
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

        public async Task<IEnumerable<IngredientDto>> GetAllAsync()
        {
            var ingredients = await _ingredientRepository.GetAll();
            var dtoIngredients = _mapper.Map<IEnumerable<Ingredient>, IEnumerable<IngredientDto>>(ingredients);
            return dtoIngredients;
        }

        public async Task<IngredientDto> GetAsync(int id)
        {
            var ingredient = await _ingredientRepository.Get(id);
            var dtoIngredient = _mapper.Map<IngredientDto>(ingredient);
            return dtoIngredient;
        }

        public async Task CreateAsync(IngredientDto ingredient)
        {
            var origIngredient = _mapper.Map<IngredientDto, Ingredient>(ingredient);
            await _ingredientRepository.Create(origIngredient);
        }

        public async Task UpdateAsync(IngredientDto ingredient)
        {
            var origIngredient = _mapper.Map<Ingredient>(ingredient);
            await _ingredientRepository.Update(origIngredient);
        }

        public async Task DeleteAsync(int id)
        {
            var realItem = await _ingredientRepository.Get(id);

            if (realItem == null) throw new NotFoundException();

            await _ingredientRepository.Delete(id);
        }

        public async Task<IEnumerable<IngredientDto>> GetByName(string name)
        {
            if (name.Equals("null"))
            {
                var ingredients = await _ingredientRepository.GetAll();
                return _mapper.Map<IEnumerable<IngredientDto>>(ingredients);
            }
            else
            {
                var ingredient = await _ingredientRepository.GetByName(name);
                return _mapper.Map<IEnumerable<IngredientDto>>(ingredient);
            }
        }

        public async Task<IEnumerable<IngredientDto>> GetByDish(int id)
        {
            var ingredients = await _ingredientRepository.GetByDish(id);
            var dto = _mapper.Map<IEnumerable<IngredientDto>>(ingredients);
            return dto;
        }
    }
}