using AutoMapper;
using MedClinicalAPI.Exceptions;
using Restaurant.BLL.BusinessLogic.Interfaces;
using Restaurant.BLL.Data.DTOs;
using Restaurant.DAL.Data.Models;
using Restaurant.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.BLL.BusinessLogic
{
    public class DishBl : IDishBl
    {
        private readonly IDishRepository _dishRepository;
        private readonly IMapper _mapper;
        private readonly IIngredientRepository _ingredientRepository;

        public DishBl(IDishRepository dishRepository, IMapper mapper, IIngredientRepository ingredientRepository)
        {
            _dishRepository = dishRepository;
            _mapper = mapper;
            _ingredientRepository = ingredientRepository;
        }

        public async Task<IEnumerable<DishDto>> GetAllAsync()
        {
            var dishes = await _dishRepository.GetAll();
            var dtoDishes = _mapper.Map<IEnumerable<Dish>, IEnumerable<DishDto>>(dishes);
            return dtoDishes;
        }

        public async Task<DishDto> GetAsync(int id)
        {
            var dish = await _dishRepository.Get(id);
            if (dish == null)
                throw new NotFoundException("Dish not found.");

            var dtoDish = _mapper.Map<DishDto>(dish);
            return dtoDish;
        }

        public async Task CreateAsync(DishDto dish)
        {
            var origDish = _mapper.Map<DishDto, Dish>(dish);

            var dishes = await _dishRepository.GetAll();
            var isDish = dishes.Any(d => d.Name == dish.Name);
            if (isDish)
                throw new BadRequestException("Dish with the same name is exist.");

            await _dishRepository.Create(origDish);
        }

        public async Task UpdateAsync(DishDto dish)
        {
            var origDish = _mapper.Map<Dish>(dish);
            await _dishRepository.Update(origDish);
        }

        public async Task DeleteAsync(int id)
        {
            var realItem = await _dishRepository.Get(id);

            if (realItem == null) throw new NotFoundException();

            await _dishRepository.Delete(id);
        }

        public async Task AddIngredientToDish(int dishId, int ingredientId)
        {
            var existingIngredients = await _ingredientRepository.GetByDish(dishId);
            if (existingIngredients.Any(i => i.Id == ingredientId))
                throw new BadRequestException("This ingredient is already exist in dish");

            await _dishRepository.AddIngredientToDish(dishId, ingredientId);
        }

        public async Task DeleteIngredientFromDish(int dishId, int ingredientId)
        {
            await _dishRepository.RemoveIngredientFromDish(dishId, ingredientId);
        }

        public async Task<IEnumerable<DishDto>> GetByIngredient(int ingredientId)
        {
            var dishes = await _dishRepository.GetByIngredient(ingredientId);
            var dtoDishes = _mapper.Map<IEnumerable<Dish>, IEnumerable<DishDto>>(dishes);
            return dtoDishes;
        }
    }
}