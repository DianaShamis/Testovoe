using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Context;
using WebApplication1.Models.GroupTable;

namespace WebApplication1.Service.Groups
{
    public class GroupService : IGroupService
    {
        private DbCtx _context;

        public GroupService(DbCtx context)
        {
            _context = context;
        }

        public List<Group> List()
        {
            var list = _context.Groups.ToList();
            return list;
        }
        public void Create(Group group)
        {
            var newGroup = new Group();

            if (group != null)
            {
                newGroup.Name = group.Name;
                newGroup.Speciality = group.Speciality;
                newGroup.Year = group.Year;
                _context.Add(newGroup);
                _context.SaveChanges();
            }
        }

        
        public void Update(int id, Models.GroupTable.Group group)
        {
            if (id != 0 && group !=null)
            {
                var currentGroup = _context.Groups.Where(_ => _.Id == id).FirstOrDefault();
                if(currentGroup == null)
                {
                    _context.Add(group);
                    _context.SaveChanges();
                }
                else
                {
                    currentGroup.Name = group.Name;
                    currentGroup.Speciality = group.Speciality;
                    currentGroup.Year = group.Year;
                   
                    _context.Update(currentGroup);
                    _context.SaveChanges();
                }
                
            }
        }
        public void Delete(int id)
        {
            if (id != 0)
            {
                var group = _context.Groups.Where(_ => _.Id == id).FirstOrDefault();
                _context.Remove(group);
                _context.SaveChanges();

            }
        }
        public Models.GroupTable.Group GetById(int id)
        {
            var group =new Models.GroupTable.Group();
            if(id > 0)
            {
                group = _context.Groups.Where(_ => _.Id == id).FirstOrDefault();
            }
            else
            {
                return null;
            }
            return group;
        } 
        
    }
}
