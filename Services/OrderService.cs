using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestApi.Models.DTOs.Request;
using TestApi.Models.DTOs.Response;
using TestApi.Models.Entities;
using TestApi.Repositories.IRepository;

namespace TestApi.Services
{
    public class OrderService
    {
        private readonly IMapper mapper;
        private readonly IOrderRepository orderRepository;

        public OrderService(IMapper mapper, IOrderRepository orderRepository)
        {
            this.mapper = mapper;
            this.orderRepository = orderRepository;
        }

        public async Task CreateOrder(OrderRequest orderRequest)
        {
            var order = mapper.Map<Order>(orderRequest);
            order.IsOrderActive = true;
            await orderRepository.Insert(order);
        }

        public async Task UpdateOrder(int id, [FromBody] OrderRequest orderRequest)
        {
            var orderExist = await orderRepository.GetById(id);
            if (orderExist == null)
            {
                throw new KeyNotFoundException("La orden no fue encontrada");
            }
            else
            {
                mapper.Map(orderRequest, orderExist);
                await orderRepository.Update(orderExist);
            }
        }

        public async Task<OrderResponse> GetOrderById(int id)
        {
            var order = await orderRepository.GetById(id);
            if (order == null)
            {
                throw new KeyNotFoundException("La orden no fue encontrada");
            }
            else
            {
                return mapper.Map<OrderResponse>(order);
            }
        }

        public async Task<List<OrderResponse>> GetAllOrders()
        {
            var orders = await orderRepository.GetAll();            
            return mapper.Map<List<OrderResponse>>(orders);
        }

        public async Task DeactivateOrder(int id)
        {
            var order = await orderRepository.GetById(id);
            if (order == null)
            {
                throw new KeyNotFoundException("La orden no fue encontrada");
            }
            else
            {
                order.IsOrderActive = false;
                await orderRepository.Update(order);
            }
        }

    }
}
