using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace danhba
{
    internal class Contact
    {
        public string Name { get; set; }
        public string Number { get; set; }
    }
    partial class Demo
    {
        static List<Contact> _contacts;
        static public List<Contact> Contacts
        {
            get
            {
                if (_contacts == null)
                {
                    _contacts = new List<Contact> {
                        new Contact { Name = "Thuc", Number = "12323"},
                        new Contact { Name = "Huy", Number = "12321213" },
                        new Contact { Name = "Linh", Number = "08762531" },
                        new Contact { Name = "Trang", Number ="1323245546" },
                    };
                }
                return _contacts;
            }
        }
    }
}
