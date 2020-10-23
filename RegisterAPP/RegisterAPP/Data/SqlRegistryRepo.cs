using AutoMapper.Mappers;
using RegisterAPP.Interfaces;
using RegisterAPP.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace RegisterAPP.Data
{
    public class SqlRegistryRepo : IRegistry
    {
        //-------------------------
        private readonly RegistryContext _context;

        public SqlRegistryRepo(RegistryContext context)
        {
            _context = context;
        }

         //Gets all attendance reports recorded today
        public IEnumerable<Registry> GetAllTodaysAttendanceReports()
        {
            //return _context.AttendaceRegistry.ToList();
            
            DateTime Receiving_Date = DateTime.Now;
            return _context.AttendaceRegistry.Where(x => x.Date == Receiving_Date.Date).ToList();
        }

        public IEnumerable<Registry> GetCurrentTermAttendanceReport(string className)
        {
            //Compute the current term
            //if date falls between this dates then term is 1, 2,3 or 4
            DateTime today = DateTime.Now;
            DateTime startDay = new DateTime();
            DateTime endDay = new DateTime(); ;
            //
            DateTime term1Start = DateTime.ParseExact(today.Year.ToString() +"-01-01 23:00:00", "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            DateTime term1Ends = DateTime.ParseExact(today.Year.ToString() + "-03-31 23:00:00", "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

            DateTime term2Start = DateTime.ParseExact(today.Year.ToString() + "-04-01 23:00:00", "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            DateTime term2Ends = DateTime.ParseExact(today.Year.ToString() + "-06-30 23:00:00", "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

            DateTime term3Start = DateTime.ParseExact(today.Year.ToString() + "-07-01 23:00:00", "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            DateTime term3Ends = DateTime.ParseExact(today.Year.ToString() + "-09-30 23:00:00", "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

            DateTime term4Start = DateTime.ParseExact(today.Year.ToString() + "-10-01 23:00:00", "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            DateTime term4Ends = DateTime.ParseExact(today.Year.ToString() + "-12-31 23:00:00", "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);


            if (today.Date >= term1Start.Date && today.Date <= term1Ends.Date)   //if current term1 is term 1
            {
                startDay = term1Start;
                endDay = term1Ends;
            }
            if (today.Date >= term2Start.Date && today.Date <= term2Ends.Date)   //if current term1 is term 1
            {
                startDay = term2Start;
                endDay = term2Ends;
            }
            if (today.Date >= term3Start.Date && today.Date <= term3Ends.Date)   //if current term1 is term 1
            {
                startDay = term3Start;
                endDay = term3Ends;
            }
            if (today.Date >= term4Start.Date && today.Date <= term4Ends.Date)   //if current term1 is term 1
            {
                startDay = term4Start;
                endDay = term4Ends;
            }
            return _context.AttendaceRegistry.Where(r => r.Date >= startDay.Date && r.Date <= endDay.Date).ToList();
            

        }



        //Save Changes
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

       

    }
}
