using ProOffice.ValidationLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProOffice.Tests.ValidationLogic
{
    public class ValidateTests
    {
        [Fact]
        public void ShouldReturnTrueIfThereArentBookedTimeSlots()
        {
            // Arrange
            var requestedStartDate = new DateTime(2023,05,09);
            var requestedEndDate = new DateTime(2023,06,09);
            var alreadyBookedTimeSlots = new List<TimeSlot>();
            Validate validate = new();

            // Act
            bool isTimeRangeAvailable = validate.isRequestedTimeRangeAvailable(requestedStartDate, requestedEndDate, alreadyBookedTimeSlots);

            // Assert
            Assert.True(isTimeRangeAvailable);
        }

        [Fact]
        public void ShouldReturnTrueIfRequestedTimeSlotIsNotOverlapping()
        {
            // Arrange
            var requestedStartDate = new DateTime(2023, 05, 07);
            var requestedEndDate = new DateTime(2023, 05, 15);
            var alreadyBookedTimeSlots = new List<TimeSlot>
            {
                new TimeSlot { DateFrom = new DateTime(2023, 06, 09),  DateTo = new DateTime(2023, 06, 10), }
            };

            Validate validate = new();

            // Act
            bool isTimeRangeAvailable = validate.isRequestedTimeRangeAvailable(requestedStartDate, requestedEndDate, alreadyBookedTimeSlots);

            // Assert
            Assert.True(isTimeRangeAvailable);
        }

        [Fact]
        public void ShouldReturnFalseIfRequestedStartDateIsAtBookedTimeSlot()
        {
            // Arrange
            var requestedStartDate = new DateTime(2023, 05, 11);
            var requestedEndDate = new DateTime(2023, 06, 15);
            var alreadyBookedTimeSlots = new List<TimeSlot>
            {
                new TimeSlot { DateFrom = new DateTime(2023, 05, 10),  DateTo = new DateTime(2023, 06, 10), }
            };

            Validate validate = new();

            // Act
            bool isTimeRangeAvailable = validate.isRequestedTimeRangeAvailable(requestedStartDate, requestedEndDate, alreadyBookedTimeSlots);

            // Assert
            Assert.False(isTimeRangeAvailable);
        }

        [Fact]
        public void ShouldReturnFalseIfRequestedTimeSlotIsNotValid()
        {
            // Arrange
            var requestedStartDate = new DateTime(2023, 05, 07);
            var requestedEndDate = new DateTime(2023, 05, 06);
            var alreadyBookedTimeSlots = new List<TimeSlot>
            {
                new TimeSlot { DateFrom = new DateTime(2023, 06, 09),  DateTo = new DateTime(2023, 06, 10), }
            };

            Validate validate = new();

            // Act
            bool isTimeRangeAvailable = validate.isRequestedTimeRangeAvailable(requestedStartDate, requestedEndDate, alreadyBookedTimeSlots);

            // Assert
            Assert.False(isTimeRangeAvailable);
        }

        [Fact]
        public void ShouldReturnFalseIfRequestedEndDateIsAtBookedTimeSlot()
        {
            // Arrange
            var requestedStartDate = new DateTime(2023, 05, 07);
            var requestedEndDate = new DateTime(2023, 05, 15);
            var alreadyBookedTimeSlots = new List<TimeSlot>
            {
                new TimeSlot { DateFrom = new DateTime(2023, 05, 10),  DateTo = new DateTime(2023, 06, 10), }
            };

            Validate validate = new();

            // Act
            bool isTimeRangeAvailable = validate.isRequestedTimeRangeAvailable(requestedStartDate, requestedEndDate, alreadyBookedTimeSlots);

            // Assert
            Assert.False(isTimeRangeAvailable);
        }

        [Fact]
        public void ShouldReturnFalseIfBookedTimeSlotIsBitweenRequestedTimeSlot()
        {
            // Arrange
            var requestedStartDate = new DateTime(2023, 05, 07);
            var requestedEndDate = new DateTime(2023, 05, 15);
            var alreadyBookedTimeSlots = new List<TimeSlot>
            {
                new TimeSlot { DateFrom = new DateTime(2023, 05, 09),  DateTo = new DateTime(2023, 05, 10), }
            };

            Validate validate = new();

            // Act
            bool isTimeRangeAvailable = validate.isRequestedTimeRangeAvailable(requestedStartDate, requestedEndDate, alreadyBookedTimeSlots);

            // Assert
            Assert.False(isTimeRangeAvailable);
        }
    }
}
