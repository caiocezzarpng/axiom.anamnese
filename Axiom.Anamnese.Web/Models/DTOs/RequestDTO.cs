using static Axiom.Anamnese.Web.Utils.StaticDetails;

namespace Axiom.Anamnese.Web.Models.DTOs
{
    public class RequestDTO
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string? Url { get; set; }
        public object? Data { get; set; }
        public string? AccessToken { get; set; }
    }
}
