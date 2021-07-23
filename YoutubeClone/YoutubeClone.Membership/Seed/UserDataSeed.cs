using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using YoutubeClone.Membership.Constant;
using YoutubeClone.Membership.Entities;

namespace YoutubeClone.Membership.Seed
{
    public class UserDataSeed : IUserDataSeed
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly ApplicationUser _adminUser;
        public UserDataSeed(UserManager<ApplicationUser> userManager,
            RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _adminUser = new ApplicationUser();
        }

        public async Task SeedUserAsync()
        {
            IdentityResult result = null;
            _adminUser.UserName = "admin@gmail.com";
            _adminUser.Email = "admin@gmail.com";

             var password = "Admin@1234";

            if (await _userManager.FindByEmailAsync(_adminUser.Email) == null)
            {
                result = await _userManager.CreateAsync(_adminUser,password);
                if (result.Succeeded)
                {
                    await _roleManager.CreateAsync(new Role() { Name = MemberRole.AdminRole });

                    await _roleManager.CreateAsync(new Role() { Name = MemberRole.UserRole });

                    await _userManager.AddToRoleAsync(_adminUser, MemberRole.AdminRole);
                }
            }
        }
    }
}
