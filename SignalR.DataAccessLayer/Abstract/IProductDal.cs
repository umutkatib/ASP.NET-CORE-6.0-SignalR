using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.Abstract
{
	public interface IProductDal : IGenericDal<Product>
	{
		List<Product> GetProductsWithCategories();
		int ProductCount();
		int ProductCountByCategoryNameBurger();
		int ProductCountByCategoryNameDrink();
		decimal ProductPriceAvg();
		string ProductNameByMaxPrice();
		string ProductNameByMinPrice();
		decimal ProductAvgPriceByHamburger();
		void ChangeProductStatusToFalse(int id);
		void ChangeProductStatusToTrue(int id);
		List<Product> GetListStatusByTrue();
	}
}
