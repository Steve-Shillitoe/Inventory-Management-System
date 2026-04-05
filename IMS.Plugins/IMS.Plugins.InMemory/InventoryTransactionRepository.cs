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
				InventoryId = inventory.InventoryId
			}
	}
}
