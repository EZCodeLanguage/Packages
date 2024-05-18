using static EZCodeLanguage.EZHelp;
using System.Net;
using System.Text;

namespace Http
{
    public class HTTP
    {
        public static void WebInstall(object _downloadUrl, object _downloadFilePath)
        {
            try
            {
                string brokenDownloadUrl = GetParameter<string>(_downloadUrl, typeof(string)),
                    brokenRelativeDownloadFilePath = GetParameter<string>(_downloadFilePath, typeof(string));

                string downloadUrl = FixUrlPath(brokenDownloadUrl),
                    downloadRelativeFilePath = FixDirPath(brokenRelativeDownloadFilePath);

                string fullFilePath = Path.GetFullPath(downloadRelativeFilePath);

                WebClient webClient = new WebClient();
                webClient.DownloadFile(downloadUrl, fullFilePath);
            }
            catch (Exception ex)
            {
                throw ThrowError(ex);
            }
        }
        public static HttpClient HttpClient()
        {
            HttpClientHandler handler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.All
            };

            return new HttpClient();
        }
        public static string GET(object _urlPath)
        {
            try
            {
                string brokenUrlPath = GetParameter<string>(_urlPath, typeof(string));
                string urlPath = FixUrlPath(brokenUrlPath);

                return GetAsync(urlPath).Result;
            }
            catch (Exception ex)
            {
                throw ThrowError(ex);
            }
        }
        public static string POST(object _urlPath, string _data, string _contentType)
        {
            try
            {
                string brokenUrlPath = GetParameter<string>(_urlPath, typeof(string)),
                    data = GetParameter<string>(_data, typeof(string)),
                    contentType = GetParameter<string>(_contentType, typeof(string)),
                    urlPath = FixUrlPath(brokenUrlPath);

                return PostAsync(urlPath, data, contentType).Result;
            }
            catch (Exception ex)
            {
                throw ThrowError(ex);
            }
        }
        public static async Task<string> GetAsync(string uri)
        {
            using HttpResponseMessage response = await HttpClient().GetAsync(uri);

            return await response.Content.ReadAsStringAsync();
        }
        public static async Task<string> PostAsync(string uri, string data, string contentType)
        {
            using HttpContent content = new StringContent(data, Encoding.UTF8, contentType);

            HttpRequestMessage requestMessage = new HttpRequestMessage()
            {
                Content = content,
                Method = HttpMethod.Post,
                RequestUri = new Uri(uri)
            };

            using HttpResponseMessage response = await HttpClient().SendAsync(requestMessage);

            return await response.Content.ReadAsStringAsync();
        }
    }
}
