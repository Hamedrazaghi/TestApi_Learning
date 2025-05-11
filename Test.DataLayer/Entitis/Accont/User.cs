using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.DataLayer.Entitis.Common;

namespace Test.DataLayer.Entitis.Accont
{
    public class User: BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }

    }
}
