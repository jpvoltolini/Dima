using Microsoft.AspNetCore.Identity;

namespace Dima.Api.Models
{
    public class User : IdentityUser<long>
    {
        /// <summary>
        /// uma lista de Perfis.
        /// </summary>

        public List<IdentityRole<long>>? Roles { get; set; }

    }
}
