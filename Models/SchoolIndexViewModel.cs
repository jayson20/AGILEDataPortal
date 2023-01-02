using System.ComponentModel.DataAnnotations;

namespace AGILEDataPortal.Models
{
    public class SchoolIndexViewModel
    {
        [Key]
        public int Id { get; set; }
        public int SchoolId { get; set; }
        [MaxLength(250)]
        public string Name { get; set; }
        [MaxLength(250)]
        public string UniqueName { get; set; }
        [MaxLength(150)]
        public string Address { get; set; }
        [MaxLength(50)]
        public string LGA { get; set; }
        [MaxLength(30)]
        public string State { get; set; }
        [MaxLength(20)]
        public string Latitude { get; set; }
        [MaxLength(20)]
        public string Longitude { get; set; }
        [MaxLength(30)]
        public string SchoolType1 { get; set; }
        [MaxLength(30)]
        public string SchoolType2 { get; set; }
        [MaxLength(30)]
        public string SchoolType3 { get; set; }
        [MaxLength(30)]
        public string SchoolType4 { get; set; }
        public int TotalNumberOfStudents { get; set; }
        public int NumberOfBoysJss1 { get; set; }
        public int NumberOfBoysJss2 { get; set; }
        public int NumberOfBoysJss3 { get; set; }
        public int NumberOfBoysSss1 { get; set; }
        public int NumberOfBoysSss2 { get; set; }
        public int NumberOfBoysSss3 { get; set; }
        public int NumberOfGirlsJss1 { get; set; }
        public int NumberOfGirlsJss2 { get; set; }
        public int NumberOfGirlsJss3 { get; set; }
        public int NumberOfGirlsSss1 { get; set; }
        public int NumberOfGirlsSss2 { get; set; }
        public int NumberOfGirlsSss3 { get; set; }
        public int NumberOfICTTeachers { get; set; }
        [MaxLength(20)]
        public string PerimeterFence { get; set; }
        public int NumberOfLaptops { get; set; }
        public int NumberOfDesktops { get; set; }
        public int NumberOfCompLabs { get; set; }
        public int NumberOfComputersInLabs { get; set; }
        [MaxLength(20)]
        public string InternetAvailability { get; set; }
        [MaxLength(20)]
        public string InternetRating { get; set; }
        public int NumberOfColorPrinter { get; set; }
        public int NumberOfBlackAndWhitePrinter { get; set; }
        [MaxLength(50)]
        public string ScreenProjector { get; set; }
        [MaxLength(30)]
        public string PowerSource_Public { get; set; }
        [MaxLength(30)]
        public string PowerSource_Generator { get; set; }
        [MaxLength(30)]
        public string PowerSource_Iverter { get; set; }
        [MaxLength(30)]
        public string PowerSource_Solar { get; set; }
        [MaxLength(30)]
        public string NetwPerihpRouters { get; set; }
        [MaxLength(30)]
        public string NetwPerihpSwitches { get; set; }
        [MaxLength(30)]
        public string NetwPerihpCables { get; set; }
        [MaxLength(30)]
        public string TypeOfInternet { get; set; }
        [MaxLength(20)]
        public string LAN { get; set; }
        [MaxLength(1000)]
        public string Software { get; set; }
        [MaxLength(30)]
        public string SecurityWindows { get; set; }
        [MaxLength(30)]
        public string SecurityDoors { get; set; }
        [MaxLength(30)]
        public string SecurityGateman { get; set; }
        [MaxLength(30)]
        public string SecurityNightGuard { get; set; }
        [MaxLength(30)]
        public string TelcoServicesMTN { get; set; }
        [MaxLength(30)]
        public string TelcoServicesAirtel { get; set; }
        [MaxLength(30)]
        public string TelcoServicesGlo { get; set; }
        [MaxLength(30)]
        public string TelcoServices9Mobile { get; set; }

        [MaxLength(20)]
        public string CCTV { get; set; }

        public bool IsTransfered { get; set; } = false;
    }
}
