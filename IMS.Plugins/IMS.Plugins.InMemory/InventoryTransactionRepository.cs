using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Plugins.InMemory
{
	public class InventoryTransactionRepository : IInventoryTransactionRepository
	{
		public List<InventoryTransaction> inventoryTransactions { get; set; } = new List<InventoryTransaction>();

		public InventoryTransactionRepository()
		{
		}

		public void purchaseAsync(string poNumber, Inventory inventory, int quanity,
			string doneBy, double price)
		{
			inventoryTransactions.Add(new InventoryTransaction
			{
				PONumber = poNumber,
				InventoryId = inventory.InventoryId,
				QuantityBefore = inventory.Quantity,
				ActivityType = InventoryTransactionType.PurchaseInventory,
				QuantityAfter = inventory.Quantity + quanity,
				TransactionDate = DateTime.Now,
				DoneBy = doneBy,
				UnitPrice = price
			});
		}

		public void produceAsync(string productionNumber, Inventory inventory, int quanityToConsume, string doneBy, double price)
		{
			inventoryTransactions.Add(new InventoryTransaction
			{
				ProductionNumber = productionNumber,
				InventoryId = inventory.InventoryId,
				QuantityBefore = inventory.Quantity,
				ActivityType = InventoryTransactionType.ProduceProduct,
				QuantityAfter = inventory.Quantity - quanityToConsume,
				TransactionDate = DateTime.Now,
				DoneBy = doneBy,
				UnitPrice = price
			});
		}
	}
}
