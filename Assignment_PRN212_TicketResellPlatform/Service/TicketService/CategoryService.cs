using BusinessObject;
using Repository.Def;
using Repository.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.TicketService
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository categoryRepository;

        public CategoryService()
        {
            this.categoryRepository = new CategoryRepository();
        }

        public ICollection<Category> GetAllCategories()
        {
            return categoryRepository.GetAllCategories();
        }
    }
}
