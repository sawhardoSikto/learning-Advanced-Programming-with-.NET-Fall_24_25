using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IgenericRepo<CLASS>
    {
        bool Create(CLASS obj);
        bool Delete(int id);   
        List<CLASS> GetAll();
        CLASS GetById(int id);
        bool Update(CLASS obj);

    }
}
