using Microsoft.AspNetCore.Mvc;
using Namira.Areas.Admin.ViewModels;
using Namira.Areas.Admin.Models;

namespace Namira.Areas.Admin.Controllers
{
    public class PartialViewsController : Controller
    {
        public IActionResult DataOutput(DataOutputViewModel dataOutput)
        {
            return PartialView(dataOutput);
        }
        public IActionResult Pagination(Paginator paginator)
        {
            return PartialView(paginator);
        }
    }
}