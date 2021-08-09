using Project.Business;
using Project.Repositories;
using Project.Repositories.Role;
using Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utility.Interfaces;

namespace BusinessLayer.Business.BaseUIView
{
    public class RoleUiView : IBaseUiView
    {
        private IRoleBusiness roleBusiness;
        int _roleId;
        //List<RoleViewModel> currentRole;
        public RoleUiView(IRoleBusiness roleBusiness, int roleId= 0)
        {
            this.roleBusiness = roleBusiness;
            _roleId = roleId;
            //currentRole = model;
        }
        public List<DataGridViewColumn> GetColumn()
        {
            return new List<DataGridViewColumn>() {
                    new DataGridViewTextBoxColumn() { Name = "RoleId", HeaderText = "شماره نقش", DataPropertyName = "RoleId" },
                    new DataGridViewTextBoxColumn() { Name = "RoleName", HeaderText = "عنوان", DataPropertyName = "RoleName" }
                    };
        }

        public DataTable GetData()
        {
            return roleBusiness.GetRoles(_roleId);
        }
    }
}
