using IMS.CoreBusiness;
using IMS.UseCases.Products.Interfaces;
using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases.Products
{
	public class DeleteProductUseCase : IDeleteProductUseCase
	{
		private readonly IProductRepository _productRepository;
		public DeleteProductUseCase(IProductRepository productRepository)
		{
			this._productRepository = productRepository;
		}
		public async Task ExecuteAsync(int productId)
		{
			await this._productRepository.DeleteProductByIdAsync(productId);
		}
	}
}
