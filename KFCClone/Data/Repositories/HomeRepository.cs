using AutoMapper;
using KFCClone.DTOs.Auth;
using KFCClone.Models;

namespace KFCClone.Data.Repositories
{
    public class HomeRepository : IHomeRepository
    {
        private readonly DataContext _context;
        public HomeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetHomePageProductsAsync()
        {
            List<Product> products = await _context.Products.Where(x => x.IsHomePageProduct == true).Include(x => x.Category).ToListAsync();
            return products;
        }

        public async Task<List<Promotion>> GetPromotions()
        {
            List<Promotion> promotions = await _context.Promotions.ToListAsync();
            return promotions;
        }
    }
}