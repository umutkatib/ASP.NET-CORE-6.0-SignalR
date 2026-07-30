using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework
{
	public class EfHourDal : GenericRepository<Hour>, IHourDal
	{
		public EfHourDal(SignalRContext context) : base(context)
		{
		}
	}
}
