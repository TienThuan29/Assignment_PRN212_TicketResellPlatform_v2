using BusinessObject;
using DataAccessObject;
using Repository.Def;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Impl
{
    public class CategoryRepository : ICategoryRepository
    {
        public ICollection<Category> GetAllCategories()
        {
            return CategoryDAO.Instance.GetAllCategories();
        }

        public Category GetCategoryById(int id)
        {
            return CategoryDAO.Instance.GetCategoryById(id);
        }
    }
}
