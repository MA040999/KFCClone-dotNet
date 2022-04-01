using AutoMapper;
using KFCClone.DTOs.Product;
using KFCClone.Interfaces;
using KFCClone.Models;

namespace KFCClone.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ProductRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetProductByIdResponseDto> GetProductById(int productId)
        {
            Product product = await _context.Products.Include(x => x.ProductAddOns).ThenInclude(addon => addon.AddOn).SingleAsync(x => x.Id == productId);

            if (product == null) throw new KeyNotFoundException("Product does not exist");

            var response = _mapper.Map<GetProductByIdResponseDto>(product);

            return response;
        }
    }
}
