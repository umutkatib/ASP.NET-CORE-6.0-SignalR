using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework
{
	public class EfTestimonialDal : GenericRepository<Testimonial>, ITestimonialDal
	{
		public EfTestimonialDal(SignalRContext context) : base(context)
		{
		}

		public void ChangeTestimonialStatusToFalse(int id)
		{
			using var context = new SignalRContext();
			var value = context.Testimonials.Find(id);
			value.TestimonialStatus = false;
			context.SaveChanges();
		}

		public void ChangeTestimonialStatusToTrue(int id)
		{
			using var context = new SignalRContext();
			var value = context.Testimonials.Find(id);
			value.TestimonialStatus = true;
			context.SaveChanges();
		}

		public List<Testimonial> GetListStatusByTrue()
		{
			using var context = new SignalRContext();
			return context.Testimonials.Where(x => x.TestimonialStatus).ToList();
		}
	}
}
