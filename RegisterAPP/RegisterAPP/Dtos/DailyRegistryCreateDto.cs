﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterAPP.Dtos
{
    public class DailyRegistryCreateDto
    {
        [Required(ErrorMessage = "Class Name is required..")]
        [Display(Name = "ClassName")]
        public string ClassName { get; set; }

        [Required(ErrorMessage = "Grade is required..")]
        [Display(Name = "Grade")]
        public string Grade { get; set; }

        [Required(ErrorMessage = "Name of Student is required..")]
        [Display(Name = "StudentName")]
        public string StudentName { get; set; }

        [Required(ErrorMessage = "Enter Present or Abset..")]
        [Display(Name = "PresentORAbsent")]
        public bool IsPresent { get; set; }
    }
}
