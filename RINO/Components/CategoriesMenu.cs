using Microsoft.AspNetCore.Mvc;
using RINO.Repo.CategoryRepo;

namespace RINO.Components
{
    public class CategoriesMenu:ViewComponent
    {
        private ICategory _category;
        public CategoriesMenu(ICategory category)
        {
            _category = category;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _category.Allcategories.OrderBy(c => c.CategoryName);
            return View(categories);    

        }
    }
}
