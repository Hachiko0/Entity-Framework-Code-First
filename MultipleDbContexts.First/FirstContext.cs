using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleDbContexts.First
{
    public class FirstContext : DbContext
    {
        public FirstContext()
            :base("MultipleContexts")
        {

        }

        public virtual IDbSet<FirstEntity> FirstEntity { get; set; }
    }

    public class FirstEntity
    {
        public string Id { get; set; }

        public string FirstProperty { get; set; }
    }
}
