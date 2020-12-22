using AutoMapper;
using Restaurant.BLL.Data.DTOs;
using Restaurant.DAL.Data.Models;

namespace Restaurant.BLL.Data
{
    public class AutoMapperProfiler : Profile
    {
        public AutoMapperProfiler()
        {
            CreateMap<Dish, DishDto>();
            CreateMap<DishDto, Dish>();

            CreateMap<IngredientDto, Ingredient>();
            CreateMap<Ingredient, IngredientDto>();

            CreateMap<DishIngredient, DishIngredientDto>();
            CreateMap<DishIngredientDto, DishIngredient>();

            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();
        }
    }
}