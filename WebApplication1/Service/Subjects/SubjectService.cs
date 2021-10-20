using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Context;
using WebApplication1.Models.SubjectTable;

namespace WebApplication1.Service.Subjects
{
    public class SubjectService : ISubjectService
    {
        private DbCtx _context;

        public SubjectService(DbCtx context)
        {
            _context = context;
        }

        public List<Subject> List()
        {
            var list = _context.Subjects.ToList();
            return list;
        }
        public void Create(Subject subject)
        {
            //var newSubject = new Subject();

            //if (subject != null)
            //{
                //newSubject.Name = subject.Name;
                
                _context.Add(subject);
                _context.SaveChanges();
            //}
        }


        public void Update(int id, Models.SubjectTable.Subject subject)
        {
            if (id != 0 && subject != null)
            {
                var currentSubject = _context.Subjects.Where(_ => _.Id == id).FirstOrDefault();
                if (currentSubject == null)
                {
                    _context.Add(subject);
                    _context.SaveChanges();
                }
                else
                {
                    currentSubject.Name = subject.Name;

                    _context.Update(currentSubject);
                    _context.SaveChanges();
                }

            }
        }
        public void Delete(int id)
        {
            if (id != 0)
            {
                var subject = _context.Subjects.Where(_ => _.Id == id).FirstOrDefault();
                _context.Remove(subject);
                _context.SaveChanges();

            }
        }
        public Models.SubjectTable.Subject GetById(int id)
        {
            var subject = new Models.SubjectTable.Subject();
            if (id > 0)
            {
                subject = _context.Subjects.Where(_ => _.Id == id).FirstOrDefault();
            }
            else
            {
                return null;
            }
            return subject;
        }
    }
}
