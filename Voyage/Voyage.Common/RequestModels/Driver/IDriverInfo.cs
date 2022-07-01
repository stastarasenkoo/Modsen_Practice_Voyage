using Voyage.Common.Types;

namespace Voyage.Common.RequestModels.Driver;

public interface IDriverInfo
{
    public string FirstName { get; set; }

    public string SecondName { get; set; }

    public string? ThirdName { get; set; }

    public string PhoneNumber { get; set; }

    public string Email { get; set; }

    public int DrivingExperience { get; set; }

    public DriverCategoryType DriverCategory { get; set; }
}
