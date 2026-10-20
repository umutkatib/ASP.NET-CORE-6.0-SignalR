using Microsoft.AspNetCore.Mvc.ModelBinding;
using SignalRWebUI.Models;

namespace SignalRWebUI.Extensions
{
	public static class ModelStateExtensions
	{
		public static async Task AddApiErrorsAsync(this ModelStateDictionary modelState, HttpResponseMessage response)
		{
			try
			{
				var errorResponse = await response.Content.ReadFromJsonAsync<ApiValidationErrorResponse>();
				if (errorResponse?.Errors == null) return;

				foreach (var error in errorResponse.Errors)
					foreach (var message in error.Value)
						modelState.AddModelError(error.Key, message);
			}
			catch (System.Text.Json.JsonException)
			{
				modelState.AddModelError(string.Empty, "Beklenmeyen bir hata oluştu.");
			}
		}
	}
}