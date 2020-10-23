using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            var reportItems = _registryContext.GetCurrentTermAttendanceReport(className);
            return View(_mapper.Map<IEnumerable<TermReportReadDto>>(reportItems));
        }
    }
}
