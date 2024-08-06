using Axiom.Anamnese.Web.Models.Dto;
using Axiom.Anamnese.Web.Service.IService;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using static Axiom.Anamnese.Web.Utils.StaticDetails;

namespace Axiom.Anamnese.Web.Service
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ITokenProvider _tokenProvider;


        public BaseService(IHttpClientFactory httpClientFactory, ITokenProvider tokenProvider)
        {
            _httpClientFactory = httpClientFactory;
            _tokenProvider = tokenProvider;
        }

        public async Task<ResponseDto?> SendAsync(RequestDto requestDTO, bool withBearer = true)
        {
            try
            {
                HttpClient client = _httpClientFactory.CreateClient("AnamneseAPI");
                HttpRequestMessage message = new();
                message.Headers.Add("Accept", "application/json");

                if (withBearer)
                {
                    var token = _tokenProvider.GetToken();
                    message.Headers.Add("Authorization", $"Bearer {token}");
                }

                message.RequestUri = new Uri(requestDTO.Url);

                if (requestDTO.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(requestDTO.Data), Encoding.UTF8, "application/json");
                }

                HttpResponseMessage? apiResponse = null;

                switch (requestDTO.ApiType)
                {
                    case ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }

                apiResponse = await client.SendAsync(message);

                switch (apiResponse.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        return new() { Success = false, Message = "Not found" };
                    case HttpStatusCode.Forbidden:
                        return new() { Success = false, Message = "Access denied" };
                    case HttpStatusCode.Unauthorized:
                        return new() { Success = false, Message = "Unauthorized" };
                    case HttpStatusCode.InternalServerError:
                        return new() { Success = false, Message = "Internal server error" };
                    default:
                        var apiContent = await apiResponse.Content.ReadAsStringAsync();
                        var apiResponseDTO = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
                        return apiResponseDTO;
                }
            }
            catch (Exception ex)
            {
                var dto = new ResponseDto()
                {
                    Message = ex.Message.ToString(),
                    Success = false
                };

                return dto;
            }
        }
    }
}