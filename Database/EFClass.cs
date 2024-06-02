using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEMO.Database
{
    internal class EFClass
    {
        public static Demo2Entities Context { get; } = new Demo2Entities();
    }
}
