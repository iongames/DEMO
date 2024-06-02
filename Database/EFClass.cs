using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEMO.Database
{
    internal class EFClass
    {
        public static Entities Context { get; } = new Entities();
    }
}
