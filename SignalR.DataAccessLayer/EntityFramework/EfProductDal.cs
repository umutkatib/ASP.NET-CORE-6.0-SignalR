using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework
{
	public class EfProductDal : GenericRepository<Product>, IProductDal
	{
		public EfProductDal(SignalRContext context) : base(context)
		{
		}

		public List<Product> GetProductsWithCategories()
		{
			using var context = new SignalRContext();
			var values = context.Products.Include(x => x.Category).ToList();
			return values;
		}

		public int ProductCount()
		{
			using var context = new SignalRContext();
			return context.Products.Count();
		}

		public int ProductCountByCategoryNameBurger()
		{
			using var context = new SignalRContext();
			var values = context.Products.Where(x => x.CategoryID == 
												(context.Categories.Where(y => y.CategoryName == "Pizzalar & Burgerler")
												.Select(z => z.CategoryID)
												.FirstOrDefault())).Count();
			return values;
		}

		public int ProductCountByCategoryNameDrink()
		{
			using var context = new SignalRContext();
			var values = context.Products.Where(x => x.CategoryID ==
												(context.Categories.Where(y => y.CategoryName == "İçecek")
												.Select(z => z.CategoryID)
												.FirstOrDefault())).Count();
			return values;
		}

		public string ProductNameByMaxPrice()
		{
			using var context = new SignalRContext();
			var value = context.Products.Where(x => x.ProductPrice == (context.Products.Max(y => y.ProductPrice))).Select(z => z.ProductName).FirstOrDefault();
			return value;
		}

		public string ProductNameByMinPrice()
		{
			using var context = new SignalRContext();
			var value = context.Products.Where(x => x.ProductPrice == (context.Products.Min(y => y.ProductPrice))).Select(z => z.ProductName).FirstOrDefault();
			return value;
		}

		public decimal ProductPriceAvg()
		{
			using var context = new SignalRContext();
			var value = context.Products.Average(x => x.ProductPrice);
			return value;
		}

		public decimal ProductAvgPriceByHamburger()
		{
			using var context = new SignalRContext();
			var value = context.Products.Where(x => x.CategoryID == (context.Categories.Where(y => y.CategoryName == "Pizzalar & Burgerler").Select(z => z.CategoryID).FirstOrDefault())).Average(w => w.ProductPrice);
			return value;
		}

		public void ChangeProductStatusToFalse(int id)
		{
			using var context = new SignalRContext();
			var value = context.Products.Find(id);
			value.ProductStatus = false;	
			context.SaveChanges();
		}

		public void ChangeProductStatusToTrue(int id)
		{
			using var context = new SignalRContext();
			var value = context.Products.Find(id);
			value.ProductStatus = true;
			context.SaveChanges();
		}

		public List<Product> GetListStatusByTrue()
		{
			using var context = new SignalRContext();
			return context.Products.Where(x => x.ProductStatus == true).ToList();
		}
	}
}

