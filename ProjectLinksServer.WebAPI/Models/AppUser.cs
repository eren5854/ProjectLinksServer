using Microsoft.AspNetCore.Identity;

namespace ProjectLinksServer.WebAPI.Models;

public sealed class AppUser : IdentityUser<Guid>
{
    public List<Category>? Categories { get; set; }
}
