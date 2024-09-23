using AutoMapper;
using TestApi.Models.DTOs.Request;
using TestApi.Models.DTOs.Response;
using TestApi.Models.Entities;
using TestApi.Repositories.IRepository;

namespace TestApi.Services
{
    public class ProductService
    {
        private readonly IMapper mapper;
        private readonly IProductRepository productRepository;

        public ProductService(IMapper mapper, IProductRepository productRepository)
        {
            this.mapper = mapper;
            this.productRepository = productRepository;
        }

        public async Task CreateProduct(ProductRequest productRequest)
        {
            var product = mapper.Map<Product>(productRequest);
            product.IsProductActive = true;
            await productRepository.Insert(product);
        }

        public async Task UpdateProduct(int id, ProductRequest productRequest)
        {
            var existingProduct = await productRepository.GetById(id);
            if (existingProduct == null)
            {
                throw new KeyNotFoundException("No se ha encontrado el producto");
            }
            else
            {
                mapper.Map(existingProduct, productRequest);
                await productRepository.Update(existingProduct);
            }
        }

        public async Task<ProductResponse> GetProductById(int id)
        {
            var existingProduct = await productRepository.GetById(id);
            if (existingProduct == null)
            {
                throw new KeyNotFoundException("No se ha encontrado el producto");
            }
            else
            {
                return mapper.Map<ProductResponse>(existingProduct);
            }
        }
        public async Task<List<ProductResponse>> GetAllProducts()
        {
            var products = await productRepository.GetAll();
            return mapper.Map<List<ProductResponse>>(products);
        }

        public async Task DeleteProduct(int id)
        {
            var existingProduct = await productRepository.GetById(id);
            if (existingProduct == null)
            {
                throw new KeyNotFoundException("No se ha encontrado el producto");
            }
            else
            {       
                existingProduct.IsProductActive = false;
                await productRepository.Update(existingProduct);
            }
        }

    }
}
