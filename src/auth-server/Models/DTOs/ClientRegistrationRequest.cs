using System.ComponentModel.DataAnnotations;

namespace SimpleAuthServer.Models.DTOs
{
    public class ClientRegistrationRequest
    {
        [Required]
        public string ClientName { get; set;} = string.Empty;
        [Required]
        public IEnumerable<string> RedirectUris { get; set; } = Enumerable.Empty<string>();
        [Required]
        public IEnumerable<string> Scopes { get; set; } = Enumerable.Empty<string>();
        [Required]
        public string ClientUri { get; private set; } = string.Empty;
    }
}