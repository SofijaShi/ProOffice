namespace ProOffice.ValidationLogic
{
    public class Validate: IValidate
    {
        public bool isRequestedTimeRangeAvailable(DateTime requestedStartDate, DateTime requestedEndDate, List<TimeSlot> alreadyBookedTimeSlots)
        {
            foreach (var timeSlot in alreadyBookedTimeSlots)
            {
                if (requestedStartDate >= timeSlot.DateFrom && requestedStartDate <= timeSlot.DateTo)
                {
                    return false;
                }

                if (requestedEndDate >= timeSlot.DateFrom && requestedEndDate <= timeSlot.DateTo)
                {
                    return false;
                }

                if (requestedStartDate <= timeSlot.DateFrom && requestedEndDate >= timeSlot.DateTo)
                {
                    return false;
                }

            }
            return true;
        }
    }
}