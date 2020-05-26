using Microsoft.AspNetCore.Mvc;
using Namira.Areas.Admin.ViewModels;

namespace Namira.Areas.Admin.Controllers
{
    public class PartialViewsController : Controller
    {
        public IActionResult DataOutput(DataOutputViewModel data)
        {
            return PartialView(data);
        }
    }
}