using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Project.ViewModel
{
    public class RoleViewModel : IDataErrorInfo
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public string this[string property]
        {
            get
            {
                var msg = new StringBuilder();
                switch (property)
                {
                    case "RoleId":
                        if (string.IsNullOrEmpty(RoleId)) msg.AppendLine("شماره نقش نمی تواند خالی باشد");
                        break;
                }

                return msg.ToString();
            }
        }
        public string Error
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                if (!string.IsNullOrEmpty(this["RoleId"]))
                    builder.AppendLine(this["RoleId"]);
                return builder.ToString();
            }
        }
    }
}
