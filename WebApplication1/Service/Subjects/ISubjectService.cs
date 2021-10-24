using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.SubjectTable;

namespace WebApplication1.Service.Subjects
{
    public interface ISubjectService
    {
        List<Subject> List();
        void Create(Subject subject);
        Subject GetById(int id);
        void Update(int id, Subject subject);
        void Delete(int id);
    }
}
