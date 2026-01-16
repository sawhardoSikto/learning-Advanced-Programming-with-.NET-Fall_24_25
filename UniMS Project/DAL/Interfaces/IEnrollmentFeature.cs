using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IEnrollmentFeature
    {
        bool Enroll(int sId, int cId, string semester);
        bool UpdateGrade(int Id, string Grade);
        List<Enrollment> GetByStudent(int sId);
    }

}
