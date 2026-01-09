using DAL.EF;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICategoryFeatures
    {
        public Category GetByName(string name);
        public List<Category> GetwithProduts();

    }
}
