using AutoMapper;
using Restaurant.BLL.BusinessLogic.Interfaces;
using Restaurant.BLL.Data.DTOs;
using Restaurant.DAL.Data.Models;
using Restaurant.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant.BLL.BusinessLogic
{
    public class DishBl : IDishBl
    {
        private readonly IDishRepository _dishRepository;
        private readonly IMapper _mapper;

        public DishBl(IDishRepository dishRepository, IMapper mapper)
        {
            _dishRepository = dishRepository;
            _mapper = mapper;
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
            var dtoDish = _mapper.Map<DishDto>(dish);
            return dtoDish;
        }

        public async Task CreateAsync(DishDto dish)
        {
            var origDish = _mapper.Map<DishDto, Dish>(dish);
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

            if (realItem == null) throw new NotImplementedException();

            await _dishRepository.Delete(id);
        }

        public async Task AddIngredientToDish(int dishId, int ingredientId)
        {
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