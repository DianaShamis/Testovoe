using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.GroupTable;

namespace WebApplication1.Service.Groups
{
    public interface IGroupService
    {
        List<Group> List();
        void Create(Group group);
        Group GetById(int id);
        void Update(int id, Models.GroupTable.Group group);
        void Delete(int id);
    }
}
