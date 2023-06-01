using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PhoneShop.AdminApp.Areas.Identity.Data;

namespace PhoneShop.AdminApp.Areas.Identity.Pages.Role
{
    public class UserModel : PageModel
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserModel(RoleManager<IdentityRole> roleManager,
                          UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        
        public List<UserInList> users { get; set; }
        public class UserInList : ApplicationUser
        {
            // Liệt kê các Role của User ví dụ: "Admin,Editor" ...
            public string listroles { set; get; }
        }

        [TempData] // Sử dụng Session
        public string StatusMessage { get; set; }


        public IActionResult OnPost() => NotFound("Cấm post");

        public async Task OnGet()
        {
            var lusers = (from u in _userManager.Users
                          orderby u.UserName
                          select new UserInList()
                          {
                              Id = u.Id,
                              UserName = u.UserName,
                          });
            users = await lusers.ToListAsync();
            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                user.listroles = string.Join(",", roles.ToList());
            }

        }
    }
}
