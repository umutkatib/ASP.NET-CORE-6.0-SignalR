using Microsoft.AspNetCore.SignalR;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using System.Runtime.CompilerServices;

namespace SignalRApi.Hubs
{
	public class SignalRHub : Hub
	{
		private readonly ICategoryService _categoryService;
		private readonly IProductService _productService;
		private readonly IOrderService _orderService;
		private readonly IMoneyCaseService _moneyCaseService;
		private readonly IMenuTableService _menuTableService;
		private readonly IBookingService _bookingService;
		private readonly INotificationService _notificationService;

		public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, IMoneyCaseService moneyCaseService, IMenuTableService menuTableService, IBookingService bookingService, INotificationService notificationService)
		{
			_categoryService = categoryService;
			_productService = productService;
			_orderService = orderService;
			_moneyCaseService = moneyCaseService;
			_menuTableService = menuTableService;
			_bookingService = bookingService;
			_notificationService = notificationService;
		}

		public async Task SendStatistics()
		{
			var value1 = _categoryService.TCategoryCount();
			await Clients.All.SendAsync("ReceiveCategoryCount", value1);

			var value2 = _productService.TProductCount();
			await Clients.All.SendAsync("ReceiveProductCount", value2);

			var value3 = _categoryService.TActiveCategoryCount();
			await Clients.All.SendAsync("ReceiveActiveCategoryCount", value3);

			var value4 = _categoryService.TPassiveCategoryCount();
			await Clients.All.SendAsync("ReceivePassiveCategoryCount", value4);

			var value5 = _productService.TProductCountByCategoryNameBurger();
			await Clients.All.SendAsync("ReceiveProductCountByCategoryNameBurger", value5);

			var value6 = _productService.TProductCountByCategoryNameDrink();
			await Clients.All.SendAsync("ReceiveProductCountByCategoryNameDrink", value6);

			var value7 = _productService.TProductPriceAvg();
			await Clients.All.SendAsync("ReceiveProductPriceAvg", value7.ToString("0.00"));

			var value8 = _productService.TProductNameByMaxPrice();
			await Clients.All.SendAsync("ReceiveProductNameByMaxPrice", value8);

			var value9 = _productService.TProductNameByMinPrice();
			await Clients.All.SendAsync("ReceiveProductNameByMinPrice", value9);

			var value10 = _productService.TProductAvgPriceByHamburger();
			await Clients.All.SendAsync("ReceiveProductAvgPriceByHamburger", value10.ToString("0.00"));

			var value11 = _orderService.TTotalOrderCount();
			await Clients.All.SendAsync("ReceiveTotalOrderCount", value11);

			var value12 = _orderService.TTotalActiveOrderCount();
			await Clients.All.SendAsync("ReceiveActiveOrderCount", value12);

			var value13 = _orderService.TLastOrderPrice();
			await Clients.All.SendAsync("ReceiveLastOrderPrice", value13.ToString("0.00"));

			var value14 = _moneyCaseService.TTotalMoneyCaseAmount();
			await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", value14.ToString("0.00"));

			var value15 = _orderService.TTodayTotalPrice();
			await Clients.All.SendAsync("ReceiveTodayTotalPrice", value15.ToString("0.00"));

			var value16 = _menuTableService.TMenuTableCount();
			await Clients.All.SendAsync("ReceiveMenuTableCount", value16);
		}

		public async Task SendProgress()
		{
			var value1 = _moneyCaseService.TTotalMoneyCaseAmount();
			await Clients.All.SendAsync("ReceiveMoneyCaseAmount", value1.ToString("0.00"));

			var value2 = _orderService.TTotalActiveOrderCount();
			await Clients.All.SendAsync("ReceiveTotalActiveOrderCount", value2);

			var value3 = _menuTableService.TMenuTableCount();
			await Clients.All.SendAsync("ReceiveMenuTableCount", value3);

			var value5 = _productService.TProductPriceAvg();
			await Clients.All.SendAsync("ReceiveProductPriceAvg", value5);

			var value6 = _productService.TProductAvgPriceByHamburger();
			await Clients.All.SendAsync("ReceiveProductAvgPriceByHamburger", value6);

			var value7 = _productService.TProductCountByCategoryNameDrink();
			await Clients.All.SendAsync("ReceiveProductCountByCategoryNameDrink", value7);

			var value8 = _orderService.TTotalOrderCount();
			await Clients.All.SendAsync("ReceiveTotalOrderCount", value8);

			var value9 = _orderService.TTodayTotalPrice();
			await Clients.All.SendAsync("ReceiveTodayTotalPrice", value9);

			var value10 = _categoryService.TCategoryCount();
			await Clients.All.SendAsync("ReceiveCategoryCount", value10);

			var value11 = _productService.TProductCount();
			await Clients.All.SendAsync("ReceiveProductCount", value11);

			var value12 = _bookingService.TBookingCount();
			await Clients.All.SendAsync("ReceiveBookingCount", value12);
		}

		public async Task GetBookingList()
		{
			var values = _bookingService.TGetListAll();
			await Clients.All.SendAsync("ReceiveBookingList", values);
		}

		public async Task SendNotification()
		{
			var value1 = _notificationService.TNotificationCountByStatusFalse();
			await Clients.All.SendAsync("ReceiveNotificationCountByFalse", value1);

			var values = _notificationService.TGetAllNotificationByFalse();
			await Clients.All.SendAsync("ReceiveGetAllNotificationByFalse", values);
		}

		public async Task GetMenuTableStatus()
		{
			var value = _menuTableService.TGetListAll();
			await Clients.All.SendAsync("ReceiveMenuTableStatus", value);
		}

		public async Task SendMessage(string user, string message)
		{
			await Clients.All.SendAsync("ReceiveMessage", user, message);
		}

		public static int clientCount { get; set; } = 0;
		public override async Task OnConnectedAsync()
		{
			clientCount++;
			await Clients.All.SendAsync("ReceiveClientCount", clientCount);
			await base.OnConnectedAsync();
		}

		public override async Task OnDisconnectedAsync(Exception? exception)
		{
			clientCount--;
			await Clients.All.SendAsync("ReceiveClientCount", clientCount);
			await base.OnDisconnectedAsync(exception);
		}
	}
}
