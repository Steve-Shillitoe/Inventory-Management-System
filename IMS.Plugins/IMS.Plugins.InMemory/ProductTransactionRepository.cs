using IMS.UseCases.PluginInterfaces;
using IMS.CoreBusiness;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Plugins.InMemory
{
	public class ProductTransactionRepository : IProductTransactionRepository
	{
		private List<ProductTransaction>_ProductTransactions  = new List<ProductTransaction>();

		private readonly IProductRepository _productRepository;
		private readonly IInventoryTransactionRepository _inventoryTransactionRepository;
		public ProductTransactionRepository(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}

		public async Task ProduceAsyn(string productionNumber, Product product, int quantity, string doneBy)
		{
			var prod = await _productRepository.GetProductByIdAsync(product.ProductId);
			if(prod != null)
				{ 
					foreach (var inventory in prod.ProductInventories)
					{
						if (inventory.Inventory != null)
						{  
						_inventoryTransactionRepository.produceAsync(productionNumber, 
									inventory.Inventory, inventory.InventoryQuantity * quantity, doneBy, -1);
						}
				}
			}
		}
	}
}
