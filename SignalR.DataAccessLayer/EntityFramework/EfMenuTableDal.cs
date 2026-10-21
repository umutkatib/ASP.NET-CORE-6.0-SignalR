using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework
{
	public class EfMenuTableDal : GenericRepository<MenuTable>, IMenuTableDal
	{
		public EfMenuTableDal(SignalRContext context) : base(context)
		{
		}

		public void ChangeMenuTableStatusToFalse(int id)
		{
			using var context = new SignalRContext();
			var value = context.MenuTables.Find(id);
			value.MenuTableStatus = false;
			context.SaveChanges();
		}

		public void ChangeMenuTableStatusToTrue(int id)
		{
			using var context = new SignalRContext();
			var value = context.MenuTables.Find(id);
			value.MenuTableStatus = true;
			context.SaveChanges();
		}

		public int MenuTableCount()
		{
			using var context = new SignalRContext();
			var value = context.MenuTables.Count();
			return value;
		}
	}
}
