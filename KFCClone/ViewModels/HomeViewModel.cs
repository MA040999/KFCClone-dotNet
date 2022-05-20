using KFCClone.Models;

namespace KFCClone.ViewModel
{
    public class HomeViewModel
    {
        public List<Product> products { get; set; } = new List<Product>();
        public List<Promotion> promotions { get; set; } = new List<Promotion>();


    }
}
