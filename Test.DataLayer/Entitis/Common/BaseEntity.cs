using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.DataLayer.Entitis.Common
{
    public class BaseEntity
    {

        public long Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreateDate {  get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
