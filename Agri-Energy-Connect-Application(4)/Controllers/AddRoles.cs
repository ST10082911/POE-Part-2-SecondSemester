using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agri_Energy_Connect_Application_4_.Controllers
{/// <summary>
/// Controller for user roles
/// </summary>
    [Authorize(Roles = "Employee")]
    public class AddRolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public AddRolesController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        //List all the Roles Created by Users
        public IActionResult Index()
        {
            var roles = _roleManager.Roles;
            return View(roles);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole model)
        {
            if (!_roleManager.RoleExistsAsync(model.Name).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(model.Name)).GetAwaiter().GetResult();

            }
            return RedirectToAction("Index");
        }
    }
}
