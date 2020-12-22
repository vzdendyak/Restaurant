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
    public class OrderBl : IOrderBl
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IDishRepository _dishRepository;
        private readonly IMapper _mapper;

        public OrderBl(IOrderRepository orderRepository, IDishRepository dishRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _dishRepository = dishRepository;
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

            var orders = await _orderRepository.GetAll();
            var isOrder = orders.Any(d => d.OwnerName == order.OwnerName && d.TableNumber == order.TableNumber);
            if (isOrder)
                throw new BadRequestException("This customer has already placed an order for this table.");

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

        public async Task AddDishToOrderAsync(DishOrdersDto dishOrders)
        {
            var origDishOrders = _mapper.Map<DishOrdersDto, DishOrders>(dishOrders);

            var order = await _orderRepository.Get(dishOrders.OrderId);
            var dish = await _dishRepository.Get(dishOrders.DishId);

            order.TotalPrice += dish.Price * dishOrders.PortionNumber;

            await _orderRepository.Update(order);

            await _orderRepository.AddDishToOrderAsync(origDishOrders);
        }

        public async Task RemoveDishOrderFromOrder(int dishOrderId)
        {
            var realItem = await _orderRepository.GetDishOrder(dishOrderId);

            if (realItem == null) throw new NotImplementedException();

            var order = await _orderRepository.Get(realItem.OrderId);
            var dish = await _dishRepository.Get(realItem.DishId);

            order.TotalPrice -= dish.Price * realItem.PortionNumber;

            await _orderRepository.Update(order);

            await _orderRepository.RemoveDishOrderFromOrder(dishOrderId);
        }

        public async Task<IEnumerable<DishOrdersDto>> GetAllDishesForOrder(int orderId)
        {
            var dishOrders = await _orderRepository.GetAllDishesForOrder(orderId);
            var dtoDishOrders = _mapper.Map<IEnumerable<DishOrders>, IEnumerable<DishOrdersDto>>(dishOrders);
            return dtoDishOrders;
        }

        public async Task<IEnumerable<OrderDto>> GetByTableNumber(int tableNumber)
        {
            if (tableNumber == 0)
            {
                var orders = await _orderRepository.GetAll();
                return _mapper.Map<IEnumerable<OrderDto>>(orders);
            }
            else
            {
                var order = await _orderRepository.GetByTableNumber(tableNumber);
                return _mapper.Map<IEnumerable<OrderDto>>(order);
            }
        }
    }
}