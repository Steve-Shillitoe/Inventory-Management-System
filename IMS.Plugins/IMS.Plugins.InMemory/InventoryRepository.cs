using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.Plugins.InMemory
{
	public class InventoryRepository : IInventoryRepository
	{
		private List<Inventory> _inventories;
		public InventoryRepository()
		{
			_inventories = new List<Inventory>()
			{
				new Inventory { InventoryId = 1, InventoryName = "Bike Seat", Quantity = 10, Price = 2 },
				new Inventory { InventoryId = 2, InventoryName = "Bike Body", Quantity = 10, Price = 15 },
				new Inventory { InventoryId = 3, InventoryName = "Bike Wheels", Quantity = 20, Price = 8 },
				new Inventory { InventoryId = 4, InventoryName = "Bike Pedals", Quantity = 20, Price = 1 },
			};
		}


		public Task AddInventoryAsync(Inventory inventory)
		{
			if (_inventories.Any(x => x.InventoryName.Equals(inventory.InventoryName, StringComparison.OrdinalIgnoreCase)))
			{ return Task.CompletedTask; }

			var maxId = _inventories.Max(x => x.InventoryId);
			inventory.InventoryId = maxId + 1;

			_inventories.Add(inventory);

			return Task.CompletedTask;
		}

		public Task UpdateInventoryAsync(Inventory inventory)
		{
			// Check if another inventory with the same name exists (excluding the current inventory)
			// This ensures that we don't have duplicate inventory names after the update
			// The check is done by comparing the inventory name of the inventory being updated with all other inventories in the list,
			// excluding the one being updated (identified by its InventoryId).
			if (_inventories.Any(x => x.InventoryId != inventory.InventoryId &&
				x.InventoryName.Equals(inventory.InventoryName, StringComparison.OrdinalIgnoreCase)))
				return Task.CompletedTask;

			// Find the index of the inventory to be edited
			//var index = _inventories.FindIndex(i => i.InventoryId == inventory.InventoryId);
			//if (index != -1)
			//{
			//	_inventories[index] = inventory;
			//}

			// Alternatively, you could find the inventory directly and update its properties
			var inventoryToUpdate = _inventories.FirstOrDefault(i => i.InventoryId == inventory.InventoryId);
			// If the inventory is found, update it
			if (inventoryToUpdate != null)
			{
				inventoryToUpdate.InventoryName = inventory.InventoryName;
				inventoryToUpdate.Quantity = inventory.Quantity;
				inventoryToUpdate.Price = inventory.Price;
			}
			return Task.CompletedTask;
		}

		public async Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name)
		{
			if (string.IsNullOrEmpty(name))
				return _inventories;

			return _inventories
				.Where(x => x.InventoryName
				.Contains(name, StringComparison.OrdinalIgnoreCase));
		}

		public async Task<Inventory?> GetInventoryByIdAsync(int id)
		{
			return await Task.FromResult(_inventories.FirstOrDefault(x => x.InventoryId == id));
		}

		public Task DeleteInventoryByIdAsync(int inventoryId)
		{
			var inventory = _inventories.FirstOrDefault(x => x.InventoryId == inventoryId);

			// Check if the inventory to be deleted exists in the list
			if (inventory != null) { 
				_inventories.Remove(inventory);
				return Task.CompletedTask;
			}

			//return Task.CompletedTask;
		}
	}
}
