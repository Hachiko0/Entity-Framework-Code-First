using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleDbContexts.Second
{
    public class SecondContext : DbContext
    {
        public SecondContext()
            :base("MultipleContexts")
        {

        }

        public virtual IDbSet<SecondEntity> SecondEntity { get; set; }
    }

    public class SecondEntity
    {
        public string Id { get; set; }

        public string FirstProperty { get; set; }
    }
}
