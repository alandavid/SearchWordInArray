using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
   public class Audit
    {
        public int Id { get; set; }
        public string Result { get; set; }
        public DateTime? InitialDate { get; set; }
        public string Usuario { get; set; }
        public string Word { get; set; }
    }
}
