using RINO.Context;
using RINO.Models;

namespace RINO.Repo.CategoryRepo
{
    public class CategoryRepo:ICategory
    {
        private readonly RinoDbContext _context;
        public CategoryRepo(RinoDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> Allcategories
        {
            get
            {
                return _context.Categories.OrderBy(d=>d.CategoryName);
            }
        }


}
}
