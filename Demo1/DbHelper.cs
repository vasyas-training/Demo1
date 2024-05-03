using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class DbHelper
    {
        private static Demo1Context instance;

        public static Demo1Context GetDemo1Context() { instance ??= new Demo1Context();
            instance.ChangeTracker.AutoDetectChangesEnabled = true;
            return instance;
        }
    }
}
