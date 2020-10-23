using RegisterAPP.Dtos;
using RegisterAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterAPP.Interfaces
{
    public interface IRegistry
    {
        bool SaveChanges();

        //Read Daily Register
        IEnumerable<Registry> GetAllTodaysAttendanceReports();  //Gets all today's attendance reports
        //Term
        IEnumerable<Registry> GetCurrentTermAttendanceReport(string className); //Gets attendance report for the current term 
        //Create Register
        void CreateRecord(Registry registry);
                
    }
}
