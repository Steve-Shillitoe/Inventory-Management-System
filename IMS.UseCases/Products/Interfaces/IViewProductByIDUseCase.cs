using IMS.CoreBusiness;

namespace IMS.UseCases.Products.Interfaces
{
	public interface IViewProductByIDUseCase
	{
		Task<Product?> ExecuteAsync(int id);
	}
}