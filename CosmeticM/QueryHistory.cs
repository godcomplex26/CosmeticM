using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticM
{
    internal class QueryHistory
    {
        private static QueryHistory instance = null;
        public List<Query> queries = new List<Query>();

        public static QueryHistory getInstance()
        {
            if (instance == null)
                instance = new QueryHistory();
            return instance;
        }

        public static QueryHistory _getInstance
        {
            get
            {
                if (instance == null)
                    instance = new QueryHistory();
                return instance;
            }
        }

        private QueryHistory() { }
    }
}
