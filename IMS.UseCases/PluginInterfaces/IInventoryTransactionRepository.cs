using IMS.CoreBusiness;

namespace IMS.UseCases.PluginInterfaces
{
	public interface IInventoryTransactionRepository
	{
		void purchaseAsync(string poNumber, Inventory inventory, int quanity, string doneBy, double price);
	}
}