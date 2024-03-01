using System.Text.Json;

namespace BlazorCrudPractice.Client.Utility
{
    public static class HttpResponseExt
    {

        public async static Task<T> GetResponseData<T>(this HttpResponseMessage response)
        {
            T data = default(T);

            try
            {
                if (response != null)
                {

                    var responseStream = await response.Content.ReadAsStreamAsync();

                    if (responseStream != null)
                    {
                        var options = new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true,
                        };

                        data = await JsonSerializer.DeserializeAsync<T>(responseStream, options);
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return data;
        }
    }
}
