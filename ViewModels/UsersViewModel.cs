using Bmerketo.Models.Identity;

namespace Bmerketo.ViewModels
{
    public class UsersViewModel
    {
        public IEnumerable<AppUser> Users { get; set; } = new List<AppUser>();

    }
}
