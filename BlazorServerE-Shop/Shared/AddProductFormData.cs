
namespace BlazorServerEShop.Shared
{
	public class AddProductFormData
	{
        public string Name { get; set; }
        public string Sku { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }

        public AddProductFormData(string name, string sku, string currency, decimal amount)
        {
            Name = name;
            Sku = sku;
            Currency = currency;
            Amount = amount;
        }
    }
}

