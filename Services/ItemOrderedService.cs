using AutoMapper;
using TestApi.Models.DTOs.Request;
using TestApi.Models.DTOs.Response;
using TestApi.Models.Entities;
using TestApi.Repositories.IRepository;

namespace TestApi.Services
{
    public class ItemOrderedService
    {
        private readonly IMapper mapper;
        private readonly IItemOrderedRepository itemOrderedRepository;

        public ItemOrderedService(IMapper mapper, IItemOrderedRepository itemOrderedRepository)
        {
            this.mapper = mapper;
            this.itemOrderedRepository = itemOrderedRepository;
        }

        public async Task CreateItemOrdered(ItemOrderedRequest itemOrderedRequest)
        {
            var ItemOrdered = mapper.Map<ItemOrdered>(itemOrderedRequest);
            ItemOrdered.IsItemOrderedActive = true;
            await itemOrderedRepository.Insert(ItemOrdered);
        }

        public async Task UpdateItemOrdered(int id, ItemOrderedRequest itemOrderedRequest)
        {
            var ItemOrderedExist = await itemOrderedRepository.GetById(id);
            if (ItemOrderedExist == null)
            {
                throw new KeyNotFoundException("No se ha encontrado el producto ordenado");
            }
            else
            {
                mapper.Map(ItemOrderedExist, itemOrderedRequest);
                await itemOrderedRepository.Update(ItemOrderedExist);
            }
        }

        public async Task<ItemOrderedResponse> GetItemOrderedById(int id)
        {
            var ItemOrderedExist = await itemOrderedRepository.GetById(id);
            if (ItemOrderedExist == null)
            {
                throw new KeyNotFoundException("No se ha encontrado el producto ordenado");
            }
            else
            {
                return mapper.Map<ItemOrderedResponse>(ItemOrderedExist);
            }
        }

        public async Task<List<ItemOrderedResponse>> GetAllItemsOrdered()
        {
            var ItemsOrdered = await itemOrderedRepository.GetAll();
            return mapper.Map<List<ItemOrderedResponse>>(ItemsOrdered);
        }

        public async Task DeleteItemOrdered(int id)
        {
            var ItemOrderedExist = await itemOrderedRepository.GetById(id);
            if (ItemOrderedExist == null)
            {
                throw new KeyNotFoundException("No se ha encontrado el producto ordenado");
            }
            else
            {
                ItemOrderedExist.IsItemOrderedActive = false;
                await itemOrderedRepository.Update(ItemOrderedExist);
            }
        }

    }
}
