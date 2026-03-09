using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;

namespace IMS.Plugins.InMemory
{
	public class InventoryRepository : IInventoryRepository
	{
		private List<Inventory> _inventories;
		public InventoryRepository()
		{
			_inventories = new List<Inventory>();
			{
				_inventories.Add(new Inventory() { });
				_inventories.Add(new Inventory() { });
				_inventories.Add(new Inventory() { });
			}
		}

		public Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name)
		{
			throw new NotImplementedException();
		}
	}
}
