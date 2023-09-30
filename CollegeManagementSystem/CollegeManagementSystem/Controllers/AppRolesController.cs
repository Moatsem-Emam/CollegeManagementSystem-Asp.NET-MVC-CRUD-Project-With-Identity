using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace CollegeManagementSystem.Controllers
{
	[Authorize(Roles ="Admin")]
	public class AppRolesController : Controller
	{
		readonly RoleManager<IdentityRole> _RoleManager;
        public AppRolesController(RoleManager<IdentityRole> roleManager)
        {
			_RoleManager=roleManager;

		}
		//List all the roles created by the users
        public IActionResult Index()
		{
			var roles = _RoleManager.Roles;
			return View(roles);
		}
		public IActionResult CreateView()
		{
			return View("Create");
		}
		[HttpPost]
		public async Task<IActionResult> CreateNew(IdentityRole model)
		{
			//Avoid dublicated roles
			if (!_RoleManager.RoleExistsAsync(model.Name).GetAwaiter().GetResult())
			{
				_RoleManager.CreateAsync(new IdentityRole(model.Name)).GetAwaiter().GetResult();
			}
			return RedirectToAction("Index");
		}
	}
}
