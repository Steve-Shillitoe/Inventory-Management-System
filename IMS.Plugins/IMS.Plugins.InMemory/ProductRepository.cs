using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.Plugins.InMemory
{
	public class ProductRepository : IProductRepository
	{
		private List<Product> _products;
		public ProductRepository()
		{
			_products = new List<Product>()
			{
				new Product { ProductId = 1, ProductName = "Bike", Quantity = 10, Price = 200 },
				new Product { ProductId = 2, ProductName = "Car", Quantity = 10, Price = 15000 },
			};
		}


		public Task AddProductAsync(Product product)
		{
			if (_products.Any(x => x.ProductName.Equals(product.ProductName, StringComparison.OrdinalIgnoreCase)))
			{ return Task.CompletedTask; }

			var maxId = _products.Max(x => x.ProductId);
			product.ProductId = maxId + 1;

			_products.Add(product);

			return Task.CompletedTask;
		}

		public Task UpdateProductAsync(Product product)
		{
			// Check if another product with the same name exists (excluding the current product)
			// This ensures that we don't have duplicate product names after the update
			// The check is done by comparing the product name of the product being updated with all other inventories in the list,
			// excluding the one being updated (identified by its ProductId).
			if (_products.Any(x => x.ProductId != product.ProductId &&
				x.ProductName.Equals(product.ProductName, StringComparison.OrdinalIgnoreCase)))
				return Task.CompletedTask;

			// Find the index of the product to be edited
			//var index = _products.FindIndex(i => i.ProductId == product.ProductId);
			//if (index != -1)
			//{
			//	_products[index] = product;
			//}

			// Alternatively, you could find the product directly and update its properties
			var productToUpdate = _products.FirstOrDefault(i => i.ProductId == product.ProductId);
			// If the product is found, update it
			if (productToUpdate != null)
			{
				productToUpdate.ProductName = product.ProductName;
				productToUpdate.Quantity = product.Quantity;
				productToUpdate.Price = product.Price;
			}
			return Task.CompletedTask;
		}

		public async Task<IEnumerable<Product>> GetProductsByNameAsync(string name)
		{
			if (string.IsNullOrEmpty(name))
				return _products;

			return _products
				.Where(x => x.ProductName
				.Contains(name, StringComparison.OrdinalIgnoreCase));
		}

		public async Task<Product?> GetProductByIdAsync(int id)
		{
			return await Task.FromResult(_products.FirstOrDefault(x => x.ProductId == id));
		}

		public Task DeleteProductByIdAsync(int productId)
		{
			var product = _products.FirstOrDefault(x => x.ProductId == productId);

			// Check if the product to be deleted exists in the list
			if (product != null) { 
				_products.Remove(product);
			}

			return Task.CompletedTask;
		}
	}
}
