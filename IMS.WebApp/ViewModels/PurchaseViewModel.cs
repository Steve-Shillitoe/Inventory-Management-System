using System.ComponentModel.DataAnnotations;

namespace IMS.WebApp.ViewModels
{
	public class PurchaseViewModel
	{
		
		[Required]
		public string PONumber { get; set; } = string.Empty;

		[Range(minimum:1, maximum: int.MaxValue, ErrorMessage = "Please select an inventory")]
		public int InventoryId { get; set; }
		[Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Quantity has to be greater than or equal to 1")]
		public int QuantityToPurchase { get; set; }

		[Range(minimum: 0.00, maximum: double.MaxValue, ErrorMessage = "Price cannot be negative.")]
		public double InventoryPrice { get; set; }
	}
}
