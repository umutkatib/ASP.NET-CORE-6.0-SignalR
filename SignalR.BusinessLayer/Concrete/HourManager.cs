using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Concrete
{
	public class HourManager : IHourService
	{
		private readonly IHourDal _hourDal;

		public HourManager(IHourDal hourDal)
		{
			_hourDal = hourDal;
		}

		public void TAdd(Hour entity)
		{
			_hourDal.Add(entity);
		}

		public void TDelete(Hour entity)
		{
			_hourDal.Delete(entity);
		}

		public Hour TGetByID(int id)
		{
			return _hourDal.GetByID(id);
		}

		public List<Hour> TGetListAll()
		{
			return _hourDal.GetListAll();
		}

		public void TUpdate(Hour entity)
		{
			_hourDal.Update(entity);
		}
	}
}
