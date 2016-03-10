using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace EntityLib
{
    internal interface IStudenRepository
    {
        string Insert(StudentModel model);

        string Update(StudentModel model);

        void Delete(string id);

        List<StudentModel> LoadListStudents();
    }
}
