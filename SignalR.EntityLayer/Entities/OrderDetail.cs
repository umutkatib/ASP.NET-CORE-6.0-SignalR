namespace SignalR.EntityLayer.Entities
{
	public class OrderDetail
	{
		public int OrderDetailID { get; set; }
		public int ProductID { get; set; }
		public Product Product { get; set; }
		public int OrderDetailCount { get; set; }
		public decimal OrderDetailUnitPrice { get; set; }
		public decimal OrderDetailTotalPrice { get; set; }
		public int OrderID { get; set; }
		public Order Order { get; set; }
	}
}
