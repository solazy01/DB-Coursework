using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Function
{
    public  static class FunctionOther
    {
        public static int GetNumber(string text)
        {
            int result;
            Int32.TryParse(text.Substring(0, text.IndexOf('.')), out result);
            return result;
        }
    }
}
