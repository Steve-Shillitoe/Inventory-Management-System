using System;
using System.Collections.Generic;
using System.Text;
using IMS.CoreBusiness;
using IMS.UseCases.Products.Interfaces;
using IMS.UseCases.PluginInterfaces;

namespace IMS.UseCases.Products
{
	public class ViewProductsByIdUseCase : IViewProductByIdUseCase
	{
		private readonly IProductRepository ProductRepository;
		public ViewProductsByIdUseCase(IProductRepository ProductRepository)
		{
			this.ProductRepository = ProductRepository;

		}
		public async Task<Product?> ExecuteAsync(int id)
		{
			return await ProductRepository.GetProductByIdAsync(id);
		}
	}
}
