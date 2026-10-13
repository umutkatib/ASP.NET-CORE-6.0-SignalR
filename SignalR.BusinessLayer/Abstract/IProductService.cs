using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Abstract
{
	public interface IProductService : IGenericService<Product>
	{
		List<Product> TGetProductsWithCategories();
		int TProductCount();
		int TProductCountByCategoryNameBurger();
		int TProductCountByCategoryNameDrink();
		decimal TProductPriceAvg();
		string TProductNameByMaxPrice();
		string TProductNameByMinPrice();
		decimal TProductAvgPriceByHamburger();
		void TChangeProductStatusToFalse(int id);
		void TChangeProductStatusToTrue(int id);
		List<Product> TGetListStatusByTrue();
		List<Product> TGetLast9Products();


	}
}
