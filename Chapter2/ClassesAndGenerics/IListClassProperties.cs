using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesAndGenerics
{
    interface IListClassProperties<T>
    {
        List<string> GetPropertyList();
    }
}
