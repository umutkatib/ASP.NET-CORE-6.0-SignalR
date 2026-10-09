using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework
{
	public class EfDiscountDal : GenericRepository<Discount>, IDiscountDal
	{
		public EfDiscountDal(SignalRContext context) : base(context)
		{
		}

		public void ChangeStatusToFalse(int id)
		{
			using var context = new SignalRContext();
			var value = context.Discounts.Find(id);
			value.DiscountStatus = false;
			context.SaveChanges();
		}

		public void ChangeStatusToTrue(int id)
		{
			using var context = new SignalRContext();
			var value = context.Discounts.Find(id);
			value.DiscountStatus = true;
			context.SaveChanges();
		}

		public List<Discount> GetListStatusByTrue()
		{
			using var context = new SignalRContext();
			return context.Discounts.Where(x => x.DiscountStatus == true).ToList();
		}
	}
}
