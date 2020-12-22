using AutoMapper;
using Restaurant.BLL.BusinessLogic.Interfaces;
using Restaurant.BLL.Data.DTOs;
using Restaurant.DAL.Data.Models;
using Restaurant.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.BLL.BusinessLogic
{
    public class OrderBl : IOrderBl
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderBl(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderDto>> GetAllAsync()
        {
            var orders = await _orderRepository.GetAll();
            var dtoOrders = _mapper.Map<IEnumerable<Order>, IEnumerable<OrderDto>>(orders);
            return dtoOrders;
        }

        public async Task<OrderDto> GetAsync(int id)
        {
            var order = await _orderRepository.Get(id);
            var dtoOrder = _mapper.Map<OrderDto>(order);
            return dtoOrder;
        }

        public async Task CreateAsync(OrderDto order)
        {
            var origOrder = _mapper.Map<OrderDto, Order>(order);
            await _orderRepository.Create(origOrder);
        }

        public async Task UpdateAsync(OrderDto order)
        {
            var origDish = _mapper.Map<Order>(order);
            await _orderRepository.Update(origDish);
        }

        public async Task DeleteAsync(int id)
        {
            var realItem = await _orderRepository.Get(id);

            if (realItem == null) throw new NotImplementedException();

            await _orderRepository.Delete(id);
        }

        public async Task AddDishOrderToOrder(DishOrdersDto dishOrders)
        {
            var origDishOrders = _mapper.Map<DishOrdersDto, DishOrders>(dishOrders);
            await _orderRepository.AddDishOrderToOrder(origDishOrders);
        }

        public async Task RemoveDishOrderFromOrder(int dishOrderId)
        {
            var realItem = await _orderRepository.GetDishOrder(dishOrderId);

            if (realItem == null) throw new NotImplementedException();

            await _orderRepository.RemoveDishOrderFromOrder(dishOrderId);
        }
    }
}