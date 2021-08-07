using Project.Repositories.Role;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Project.Business
{
    public class RoleBusiness: IRoleBusiness
    {
        RoleRepository roleRepository;
        public RoleBusiness()
        {
            roleRepository = new RoleRepository();
        }
        public DataTable GetDataForChoose(params object[] parameters)
        {
            return roleRepository.GetDataToChoose(parameters);
        }
    }
}
