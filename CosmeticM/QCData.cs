using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticM
{
    public class QCData
    {
        public DateTime date { get; set; }
        public double? weight { get; set; }
        public double? water { get; set; }
        public double? material { get; set; }
        public double? HSO { get; set; }
        public double? pH { get; set; }
    }
}