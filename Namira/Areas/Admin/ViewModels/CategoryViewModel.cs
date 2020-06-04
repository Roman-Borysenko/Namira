using System.Collections.Generic;
using Namira.Areas.Admin.Models;

namespace Namira.Areas.Admin.ViewModels
{
    public class CategoryViewModel<T>
    {
        public List<Entities.Category> ParentCategories { get; set; }
        public List<Entities.Language> Languages  { get; set; }
        public List<T> Data { get; set; }
    }
}
