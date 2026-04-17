using IMS.CoreBusiness;
using IMS.UseCases.Activities.Interfaces;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.UseCases.Activities
{
	public class ProduceProductUseCase : IProduceProductUseCase
	{
		private readonly IProductTransactionRepository _productTransactionRepository;
		private readonly IProductRepository _productRepository;

		public ProduceProductUseCase(IProductTransactionRepository productTransactionRepository,
			IProductRepository productRepository)
		{
			_productTransactionRepository = productTransactionRepository;
			_productRepository = productRepository;
		}

		public async Task ExecuteAsync(string productionNumber, Product product,
								int quantity, string doneBy)
		{
			// Add transaction record
			await _productTransactionRepository.ProduceAsyn(productionNumber, product, quantity, 0, doneBy);

			// Decrease inventory quantity

			// Increase product quantity
			product.Quantity += quantity;
			await _productRepository.UpdateProductAsync(product);


		}
	}
}
