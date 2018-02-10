using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesAndGenerics
{
    public class InspectClass<T> : IListClassProperties<T> where T : AcmeObject
    {
        private T classToInspect;

        public InspectClass(T classToInspect) => this.classToInspect = classToInspect;

        public List<string> GetPropertyList() => classToInspect.GetType().GetProperties().Select(p => p.Name).ToList();
    }
}
