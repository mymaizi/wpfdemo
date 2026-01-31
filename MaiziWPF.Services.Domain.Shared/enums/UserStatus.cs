using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MaiziWPF.Services.Domain.Shared
{
    public enum UserStatus
    {
        [Description("正常")]
        OK=0,
        [Description("停用")]
        DISABLE =1,
        [Description("删除")]
        DELETED = 2
    }
}
