using System;
using System.Collections.Generic;
using System.Text;
using IMS.CoreBusiness;
using IMS.UseCases.Inventories.Interfaces;
using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases.Inventories
{
	public class ViewInventoryByIdUseCase : IViewInventoryByIdUseCase
	{
		private readonly IInventoryRepository inventoryRepository;
		public ViewInventoryByIdUseCase(IInventoryRepository inventoryRepository)
		{
			this.inventoryRepository = inventoryRepository;

		}
		public async Task<Inventory> ExecuteAsync(int id)
		{
			return await inventoryRepository.GetInventoryByIDAsync(id);
		}
	}
}
