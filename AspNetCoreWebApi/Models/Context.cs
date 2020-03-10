using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebApi.Models
{
    public static class Context
    {
        public static IList<Foo> Foos { get; set; }

        static Context()
        {
            Foos = new List<Foo>();
        }
    }
}
