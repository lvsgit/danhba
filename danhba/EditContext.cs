using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace danhba
{
    public enum DataActions { Delete = -1, Update, Insert };
    public class EditContext
    {
        public DataActions Action { get; set; }
        public object Value { get; set; }
    }
}
