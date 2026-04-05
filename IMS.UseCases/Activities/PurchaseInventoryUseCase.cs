using IMS.CoreBusiness;
using IMS.UseCases.Activities.Interfaces;
using IMS.UseCases.Inventories.Interfaces;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.UseCases.Activities
{
	public class PurchaseInventoryUseCase : IPurchaseInventoryUseCase
	{
		private readonly IInventoryTransactionRepository inventoryTransactionRepository;
		private readonly IInventoryRepository inventoryRepository;

		public PurchaseInventoryUseCase(
			IInventoryTransactionRepository inventoryTransactionRepository,
			IInventoryRepository inventoryRepository)
		{
			this.inventoryTransactionRepository = inventoryTransactionRepository;
			this.inventoryRepository = inventoryRepository;
		}

		public async Task ExecuteAsync(string poNumber, Inventory inventory,
			int quanity, string doneBy)
		{
			// Insert a record in the transaction table
			inventoryTransactionRepository.purchaseAsync(poNumber, inventory, quanity, doneBy, inventory.Price);

			// Update the inventory quantity
			inventory.Quantity += quanity;
			await inventoryRepository.UpdateInventoryAsync(inventory);
		}
	}
}
