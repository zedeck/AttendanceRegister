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

            var reportStudents = _registryContext.GetCurrentTermAttendanceReport(className); 
            var reportItems = _registryContext.GetCurrentTermAttendanceReport(className);
            int presentCount = 0;
            int absentCount = 0;
            var tReport = new List<TermReportReadDto>();


            foreach (var items in reportStudents)  // Godwil 
            {

                foreach (var innetItems in reportItems)   //Godwill
                {
                    //var reportStudents = _registryContext.GetCurrentStudents(innetItems.StudentName);
                    if (items.StudentName == innetItems.StudentName)
                    {
                        if (innetItems.IsPresent)
                        {
                            presentCount++;

                        }
                        else
                        {
                            absentCount++;
                        }


                    }
                    tReport.Add(new TermReportReadDto { ClassName = items.ClassName, Grade = items.Grade,StudentName= items.StudentName, ClassesAttended = presentCount, ClassesMissed = absentCount});
                }

            }

            return View(tReport);
            //return View(_mapper.Map<IEnumerable<TermReportReadDto>>(reportItems));
        }
    }
}
