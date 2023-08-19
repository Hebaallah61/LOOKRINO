using RINO.Models;

namespace RINO.Repo.CategoryRepo
{
    public interface ICategory
    {
        IEnumerable<Category> Allcategories { get; }
    }
}
