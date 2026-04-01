using IMS.CoreBusiness.Validations;
using System.ComponentModel.DataAnnotations;

namespace IMS.CoreBusiness
{
	public class Product
	{
		public int ProductId { get; set; }

		[Required]
		[StringLength(150)]
		public string ProductName { get; set; } = string.Empty;

		[Range(0, int.MaxValue, ErrorMessage = "Quantity must be greator or equal to 0.")]
		public int Quantity { get; set; }

		[Range(0, int.MaxValue, ErrorMessage = "Price must be greator or equal to 0.")]
		public double Price { get; set; }

		//One product can have many inventories,
		//and one inventory can have many products.
		//So we have a many-to-many relationship between Product and Inventory.
		//To represent this relationship, we use a junction table called ProductInventory.
		//The Product class has a collection of ProductInventory to represent
		//the many-to-many relationship with Inventory.

		[Product_EnsurePriceGreaterThanInventoriesCost]
		public List<ProductInventory> ProductInventories { get; set; } = new List<ProductInventory>();

		public void AddInventory(Inventory inventory)
		{
			if (!this.ProductInventories.Any(
				x => x.Inventory is not null &&
				x.Inventory.InventoryName.Equals(inventory.InventoryName)))
			{
				this.ProductInventories.Add(new ProductInventory
				{
					InventoryId = inventory.InventoryId,
					Inventory = inventory,
					InventoryQuantity = 1,
					ProductId = this.ProductId,
					Product = this
				});
			}
		}

		public void RemoveInventory(ProductInventory inventory)
		{
			this.ProductInventories?.Remove(inventory);
		}

	}
}
