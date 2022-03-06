using System;
using System.Collections.Generic;
using System.Text;

namespace Labb2Linq
{
    public class Kurs
    {
        public int Id { get; set; }
        public string kursNamn { get; set; }
        public Lärare _Lärare { get; set; }
        public Klass _Klass { get; set; }
    }
}
