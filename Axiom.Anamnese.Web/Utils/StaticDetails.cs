namespace Axiom.Anamnese.Web.Utils
{
    public class StaticDetails
    {
        public static string? PersonAPIBase { get; set; }
        public const string TokenCookie = "JWTToken";

        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}