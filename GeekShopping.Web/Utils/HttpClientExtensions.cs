using System.Text.Json;

namespace GeekShopping.Web.Utils;

public static class HttpClientExtensions
{
	public static async Task<T> ReadContentAs<T>(this HttpResponseMessage response)
	{
		if (!response.IsSuccessStatusCode)
			throw new ApplicationException($"Something went wrong calling the API: {response.ReasonPhrase}");

		var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

		var deserializedResponse = JsonSerializer.Deserialize<T>(dataAsString, new JsonSerializerOptions
		{
			PropertyNameCaseInsensitive = true
		});

		if (deserializedResponse is null)
			throw new ApplicationException("Something went wrong with response deserialization!");

		return deserializedResponse;
	}
}
