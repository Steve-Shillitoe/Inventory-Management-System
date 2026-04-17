namespace IMS.UseCases.PluginInterfaces
{
	public interface IProductTransactionRepository
	{
		public Task ProduceAsyn(string productionNumber, CoreBusiness.Product product, int quantity, double price, string doneBy);
	}
}