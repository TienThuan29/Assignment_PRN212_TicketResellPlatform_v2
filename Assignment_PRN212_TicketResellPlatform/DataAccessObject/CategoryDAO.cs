using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class CategoryDAO
    {
        private PRN212_TicketResellPlatformContext context;

        private static CategoryDAO instance;

        public static CategoryDAO Instance
        {
            get => instance = instance ?? (instance = new CategoryDAO());   
        }

        private CategoryDAO() 
        {
            this.context = new PRN212_TicketResellPlatformContext();
        }

        public ICollection<Category> GetAllCategories()
        {
            return context.Categories.ToList();
        }

        public Category GetCategoryById(int id)
        {
            return context.Categories.SingleOrDefault(cate => cate.Id.Equals(id));
        }
    }
}
