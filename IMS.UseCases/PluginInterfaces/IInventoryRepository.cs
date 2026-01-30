using System;
using System.Collections.Generic;
using System.Text;
using IMS.CoreBusiness;

namespace IMS.UseCases.PluginInterfaces
{
    public interface IInventoryRepository
    {
        Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name);
    }
}
