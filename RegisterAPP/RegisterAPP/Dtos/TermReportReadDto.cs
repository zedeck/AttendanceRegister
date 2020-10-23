using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterAPP.Dtos
{
    public class TermReportReadDto
    {
        public string ClassName { get; set; }
        public string Grade { get; set; }
        public string StudentName { get; set; }
        public int ClassesAttended { get; set; }
        public int ClassesMissed { get; set; }
    }
}
