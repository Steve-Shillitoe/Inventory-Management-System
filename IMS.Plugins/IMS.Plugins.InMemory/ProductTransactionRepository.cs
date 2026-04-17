using IMS.UseCases.PluginInterfaces;
using IMS.CoreBusiness;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Plugins.InMemory
{
	public class ProductTransactionRepository : IProductTransactionRepository
	{
		private List<ProductTransaction>_productTransactions  = new List<ProductTransaction>();

		private readonly IProductRepository _productRepository;
		private readonly IInventoryTransactionRepository _inventoryTransactionRepository;
		private readonly IInventoryRepository _inventoryRepository;

		public ProductTransactionRepository(IProductRepository productRepository, 
			IInventoryTransactionRepository inventoryTransactionRepository,
			IInventoryRepository inventoryRepository)
		{
			_productRepository = productRepository;
			_inventoryTransactionRepository = inventoryTransactionRepository;
			_inventoryRepository = inventoryRepository;
		}

		public async Task ProduceAsyn(string productionNumber, Product product, int quantity, double price, string doneBy)
		{
			//decrease inventory quantity for each inventory used in the production of the product
			var prod = await _productRepository.GetProductByIdAsync(product.ProductId);
			if(prod != null)
				{ 
					foreach (var inventory in prod.ProductInventories)
					{
						if (inventory.Inventory != null)
						{
						// add inventory transaction for the inventory used in the production of the product
						_inventoryTransactionRepository.produceAsync(productionNumber, 
									inventory.Inventory, 
									inventory.InventoryQuantity * quantity, 
									doneBy, -1);
						// decrease the inventory quantity
						var inv = await _inventoryRepository.GetInventoryByIdAsync(inventory.InventoryId);
						inv.Quantity -= inventory.InventoryQuantity * quantity;
						await _inventoryRepository.UpdateInventoryAsync(inv);
					}
				}
			}
			// add the production transaction
			_productTransactions.Add(new ProductTransaction
			{
				ProductionNumber = productionNumber,
				ProductId = product.ProductId,
				QuantityBefore = product.Quantity,
				ActivityType = ProductTransactionType.ProduceProduct,
				QuantityAfter = product.Quantity + quantity,
				DoneBy = doneBy,
				TransactionDate = DateTime.Now,
				//UnitPrice = price
			});

		}
	}
}
