using System;
using System.Collections.Generic;
using System.Text;
using IMS.CoreBusiness;

namespace IMS.UseCases.PluginInterfaces
{
    public interface IInventoryRepository
    {
		Task AddInventoryAsync(Inventory inventory);
        Task UpdateInventoryAsync(Inventory inventory);

		Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name);
		Task<Inventory?> GetInventoryByIDAsync(int id);
	}
}
