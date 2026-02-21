using FreeSql.Internal.Model;
using System.ComponentModel;
using System.Xml.Linq;

namespace MaiziWPF.Services.Domain.Shared
{
    public class QueryPostInput :  BasePagingInfo
    {
        public String PostCode { get; set; }
        public String PostName { get; set; }
        public String Status { get; set; }
    }
}
