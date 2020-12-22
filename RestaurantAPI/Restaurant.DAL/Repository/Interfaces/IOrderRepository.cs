﻿using Restaurant.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DAL.Repository.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAll();

        Task<Order> Get(int id);

        //Task<IEnumerable<Order>> GetByIngredient(int ingredientId);

        Task Create(Order order);

        Task Update(Order order);

        Task Delete(int id);

        Task<DishOrders> GetDishOrder(int dishOrderId);

        Task AddDishOrderToOrder(DishOrders dishOrders);

        Task RemoveDishOrderFromOrder(int dishOrderId);
    }
}