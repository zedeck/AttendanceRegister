using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterAPP.Dtos
{
    public class DailyRegistryReadDto
    {
        public string ClassName { get; set; }
        public string Grade { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public Nullable<System.TimeSpan> Time { get; set; }
        public string StudentName { get; set; }
        public bool IsPresent { get; set; }

     }
}
