using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProOffice.ValidationLogic
{
    public interface IValidate
    {
        public bool isRequestedTimeRangeAvailable(DateTime requestedStartDate, DateTime requestedEndDate, List<TimeSlot> alreadyBookedTimeSlots);
    }
}
