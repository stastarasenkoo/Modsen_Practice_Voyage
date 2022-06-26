using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voyage.Common.Enums;

namespace Voyage.Common.ResponseModels
{
    public class DriverDetailsResponse
    {
        public int UserId { get; set; }

        public string UserFirstName { get; set; } = null!;

        public string UserSecondName { get; set; } = null!;

        public string UserThirdName { get; set; } = null!;

        public string UserPhoneNumber { get; set; } = null!;

        public string UserEmail { get; set; } = null!;

        public int DrivingExperience { get; set; }

        public DriverCategoryType DriverCategory { get; set; }
    }
}
