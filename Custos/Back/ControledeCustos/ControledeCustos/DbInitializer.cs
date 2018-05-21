using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControledeCustos
{
    public static class DbInitializer
    {

        public static void Initialize(CustosContexto context)
        {

            context.Database.EnsureCreated();

        }
    }
}
