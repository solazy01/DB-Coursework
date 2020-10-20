using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.AbstractClass
{
    public abstract class AbstractClassColumn1
    {
        public string Name {get; }


        public AbstractClassColumn1(string name)
        {
            Name = name;
        }

        public AbstractClassColumn1()
        {

        }
    }
}
