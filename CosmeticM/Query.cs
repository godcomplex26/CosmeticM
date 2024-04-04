using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CosmeticM.Form4;
using static ScottPlot.Generate;

namespace CosmeticM
{
    public class Query
    {
        public List<string> columns = new List<string>();
        private List<string> queries = new List<string>();

        public Query(List<string> columns)
        {
            this.columns = columns;
        }

        public Query(string data)
        {
            if (data.ToLower().Equals("pdata"))
            {
                string[] pdata = new string[] { "datetime", "ReactA_Temp", "ReactB_Temp", "ReactC_Temp", "ReactD_Temp", "ReactE_Temp", "ReactF_Temp", "ReactF_PH", "Power", "CurrentA", "CurrentB", "CurrentC" };
                foreach (string s in pdata)
                {
                    this.columns.Add(s);
                }
            }
            else if (data.ToLower().Equals("qdata"))
            {
                string[] qdata = new string[] { "date", "weight", "water", "material", "HSO", "pH" };
                foreach (string s in qdata)
                {
                    this.columns.Add(s);
                }
            }
        }

        public string equals(string column, int a)
        {
            return $"{column} = {a}";
        }

        public string biggerThen(string column, int a)
        {
            return $"{column} > {a}";
        }
        public string lessThen(string column, int a)
        {
            return $"{column} > {a}";
        }
        public string between(string column, int a, int b)
        {
            return $"{column} BETWEEN {a} AND {b}";
        }

        public void reset()
        {
            this.queries.Clear();
        }

        public void add(string q)
        {
            this.queries.Add(q);
        }
    }
}
