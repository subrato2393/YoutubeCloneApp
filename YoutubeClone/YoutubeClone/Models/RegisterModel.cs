using Autofac;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using YoutubeClone.Membership.Constant;
using YoutubeClone.Membership.Entities;

namespace YoutubeClone.Models
{
    public class RegisterModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        public string ReturnUrl { get; set; }
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
       
        public RegisterModel(SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public RegisterModel()
        {
            _signInManager = Startup.AutofacContainer.Resolve<SignInManager<ApplicationUser>>();
            _userManager = Startup.AutofacContainer.Resolve<UserManager<ApplicationUser>>();
        }

        public async Task GetExternalLoginProviderAsync()
        {
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IdentityResult> CreateUserAsync()
        {
            var user = GenerateUser();
          
            return  await _userManager.CreateAsync(user, Password);
        }

        private ApplicationUser GenerateUser()
        {
            var user = new ApplicationUser()
            {
                UserName = Email,
                Email = Email,
            };

            return user;
        }

        public async Task AddRoleToUser()
        {
            var user = await GetUser();

            await _userManager.AddToRoleAsync(user, MemberRole.UserRole);
        }

        public async Task SetBrowserCookie()
        {
          var user = await GetUser();

          await _signInManager.SignInAsync(user, isPersistent: false);                  
        }

        public async Task<ApplicationUser> GetUser()
        {
           return await _userManager.FindByEmailAsync(this.Email);
        }
    }
}
