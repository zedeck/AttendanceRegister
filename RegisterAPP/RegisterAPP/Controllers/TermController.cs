using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RegisterAPP.Data;
using RegisterAPP.Dtos;
using RegisterAPP.Interfaces;

namespace RegisterAPP.Controllers
{
    [Route("api/term")]
    [ApiController]
    public class TermController : Controller
    {
        private readonly IRegistry _registryContext;
        private readonly IMapper _mapper;

        public TermController(IRegistry registryContext, IMapper mapper)
        {
            _registryContext = registryContext;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TermReportReadDto>> GetCurrentTermsReports(string className)
        {

            var reg = _registryContext.GetCurrentTermAttendanceReport(className);
            List<string> students = reg.Select(o => o.StudentName).Distinct().ToList();
            var termReportReadDto = new List<TermReportReadDto>();
            int presentCount = 0;
            int absentCount = 0;

            string nameOfClass = "";
            string nameOfGrade = "";
            
            
            foreach (var currStudent in students)
            {
                foreach (var listOfItems in reg)
                {
                    if(currStudent == listOfItems.StudentName)
                    {
                        if (listOfItems.IsPresent)
                            presentCount++;
                        else
                            absentCount++;

                        nameOfClass = listOfItems.ClassName;
                        nameOfGrade = listOfItems.Grade;

                    }
                }
                termReportReadDto.Add(new TermReportReadDto { ClassName = nameOfClass, Grade = nameOfGrade, StudentName = currStudent, ClassesAttended = presentCount, ClassesMissed = absentCount });
                //Reset values
                presentCount = 0;
                absentCount = 0;
                nameOfClass = "";
                nameOfGrade = "";
            }

            return View(termReportReadDto);
        }
    }
}
