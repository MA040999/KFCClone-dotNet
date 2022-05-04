namespace KFCClone.DTOs.AddOn
{
    public class AddOnDto
    {
        public int AddOnId { get; set; }
        public string AddOnName { get; set; } = null!;
        public int AddOnPrice { get; set; }
        
        public int addonCount { get; set; }
    }
}
