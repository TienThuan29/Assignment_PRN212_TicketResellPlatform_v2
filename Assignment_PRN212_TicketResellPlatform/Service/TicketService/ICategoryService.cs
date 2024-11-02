using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.TicketService
{
    public interface ICategoryService
    {
        public ICollection<Category> GetAllCategories();

        public Category GetCategoryById(int id);
    }
}
