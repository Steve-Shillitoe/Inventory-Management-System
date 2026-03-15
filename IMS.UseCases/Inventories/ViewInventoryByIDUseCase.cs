using System;
using System.Collections.Generic;
using System.Text;
using IMS.CoreBusiness;
using IMS.UseCases.Inventories.Interfaces;
using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases.Inventories
{
	public class ViewInventoriesByIDUseCase : IViewInventoryByIDUseCase
	{
		private readonly IInventoryRepository inventoryRepository;
		public ViewInventoriesByIDUseCase(IInventoryRepository inventoryRepository)
		{
			this.inventoryRepository = inventoryRepository;

		}
		public async Task<Inventory> ExecuteAsync(int id)
		{
			return await inventoryRepository.GetInventoryByIDAsync(id);
		}
	}
}
