namespace ProOffice.ValidationLogic
{
    public class Validate: IValidate
    {
        public bool isRequestedTimeRangeAvailable(DateTime requestedStartDate, DateTime requestedEndDate, List<TimeSlot> alreadyBookedTimeSlots)
        {
            if (requestedStartDate.Date > requestedEndDate.Date)
            {
                return false;
            }
            foreach (var timeSlot in alreadyBookedTimeSlots)
            {
                if (requestedStartDate.Date >= timeSlot.DateFrom.Date && requestedStartDate.Date <= timeSlot.DateTo.Date)
                {
                    return false;
                }

                if (requestedEndDate.Date >= timeSlot.DateFrom.Date && requestedEndDate.Date <= timeSlot.DateTo.Date)
                {
                    return false;
                }

                if (requestedStartDate.Date <= timeSlot.DateFrom.Date && requestedEndDate.Date >= timeSlot.DateTo.Date)
                {
                    return false;
                }

            }
            return true;
        }
    }
}