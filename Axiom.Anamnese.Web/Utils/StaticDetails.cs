namespace Axiom.Anamnese.Web.Utils
{
    public class StaticDetails
    {
        public static string? PersonAPIBase { get; set; }
        public static string? AuthAPIBase { get; set; }

        public const string RoleAdmin = "ADMIN";
        public const string RoleCostumer = "COSTUMER";
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