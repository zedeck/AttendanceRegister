using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RegisterAPP.Data;
using RegisterAPP.Dtos;
using RegisterAPP.Interfaces;
using RegisterAPP.Models;

namespace RegisterAPP.Controllers
{
    //api/commands
    [Route("api/registry")]
    [ApiController]
    public class RegistryController : Controller
    {
        private readonly IRegistry _reg;
        private readonly IMapper _mapper;

        public RegistryController(IRegistry reg, IMapper mapper)
        {
            _reg = reg;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DailyRegistryReadDto>> GetAllTodaysAttendanceReports()
        {
            var registryItems = _reg.GetAllTodaysAttendanceReports();
            return View(_mapper.Map<IEnumerable<DailyRegistryReadDto>>(registryItems));
        }

        
    }
}
