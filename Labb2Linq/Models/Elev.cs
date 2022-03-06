using System;
using System.Collections.Generic;
using System.Text;

namespace Labb2Linq
{
    public class Elev
    {
        public int Id { get; set; }
        public string förNamn { get; set; }
        public string efterNamn { get; set; }
        public Klass _Klass { get; set; }
    }
}
