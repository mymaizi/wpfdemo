using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaiziWPF.Services.Domain
{
    public class BaseEntity
    {
        /** 创建者 */
        public String CreateBy { get; set; }
        /** 创建时间 */
        public DateTime CreateTime { get; set; }
        /** 更新者 */
        public String UpdateBy { get; set; }
        /** 更新时间 */
        public DateTime UpdateTime { get; set; }
        /** 删除标志（0代表存在 2代表删除） */
        public String DelFlag { get; set; }
  
    }
}
