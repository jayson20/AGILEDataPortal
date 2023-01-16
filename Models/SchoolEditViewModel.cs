using System.ComponentModel.DataAnnotations;

namespace AGILEDataPortal.Models
{
    public class SchoolEditViewModel
    {
        [Key]
        public int Id { get; set; }
        public int SchoolId { get; set; }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string UniqueName { get; set; }

        [Required]
        [MaxLength(150)]
        public string Address { get; set; }

        [Required]
        [MaxLength(50)]
        public string LGA { get; set; }

        [Required]
        [MaxLength(30)]
        public string State { get; set; }

        [Required]
        [MaxLength(20)]
        public string Latitude { get; set; }

        [Required]
        [MaxLength(20)]
        public string Longitude { get; set; }

        [Required]
        [MaxLength(30)]
        public string SchoolType1 { get; set; }

        [Required]
        [MaxLength(30)]
        public string SchoolType2 { get; set; }

        [Required]
        [MaxLength(30)]
        public string SchoolType3 { get; set; }

        [Required]
        [MaxLength(30)]
        public string SchoolType4 { get; set; }

        [Required]
        public int TotalNumberOfStudents { get; set; }

        [Required]
        public int NumberOfBoysJss1 { get; set; }

        [Required]
        public int NumberOfBoysJss2 { get; set; }

        [Required]
        public int NumberOfBoysJss3 { get; set; }

        [Required]
        public int NumberOfBoysSss1 { get; set; }

        [Required]
        public int NumberOfBoysSss2 { get; set; }

        [Required]
        public int NumberOfBoysSss3 { get; set; }

        [Required]
        public int NumberOfGirlsJss1 { get; set; }

        [Required]
        public int NumberOfGirlsJss2 { get; set; }

        [Required]
        public int NumberOfGirlsJss3 { get; set; }

        [Required]
        public int NumberOfGirlsSss1 { get; set; }

        [Required]
        public int NumberOfGirlsSss2 { get; set; }

        [Required]
        public int NumberOfGirlsSss3 { get; set; }

        [Required]
        public int NumberOfICTTeachers { get; set; }

        [Required]
        [MaxLength(20)]
        public string PerimeterFence { get; set; }

        [Required]
        public int NumberOfLaptops { get; set; }

        [Required]
        public int NumberOfDesktops { get; set; }

        [Required]
        public int NumberOfCompLabs { get; set; }

        [Required]
        public int NumberOfComputersInLabs { get; set; }

        [Required]
        [MaxLength(20)]
        public string InternetAvailability { get; set; }

        [Required]
        [MaxLength(20)]
        public string InternetRating { get; set; }

        [Required]
        public int NumberOfColorPrinter { get; set; }

        [Required]
        public int NumberOfBlackAndWhitePrinter { get; set; }

        [Required]
        [MaxLength(50)]
        public string ScreenProjector { get; set; }

        [Required]
        [MaxLength(30)]
        public string PowerSource_Public { get; set; }

        [Required]
        [MaxLength(30)]
        public string PowerSource_Generator { get; set; }

        [Required]
        [MaxLength(30)]
        public string PowerSource_Iverter { get; set; }

        [Required]
        [MaxLength(30)]
        public string PowerSource_Solar { get; set; }

        [Required]
        [MaxLength(30)]
        public string NetwPerihpRouters { get; set; }

        [Required]
        [MaxLength(30)]
        public string NetwPerihpSwitches { get; set; }

        [Required]
        [MaxLength(30)]
        public string NetwPerihpCables { get; set; }

        [Required]
        [MaxLength(30)]
        public string TypeOfInternet { get; set; }

        [Required]
        [MaxLength(20)]
        public string LAN { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Software { get; set; }

        [Required]
        [MaxLength(30)]
        public string SecurityWindows { get; set; }

        [Required]
        [MaxLength(30)]
        public string SecurityDoors { get; set; }

        [Required]
        [MaxLength(30)]
        public string SecurityGateman { get; set; }

        [Required]
        [MaxLength(30)]
        public string SecurityNightGuard { get; set; }

        [Required]
        [MaxLength(30)]
        public string TelcoServicesMTN { get; set; }

        [Required]
        [MaxLength(30)]
        public string TelcoServicesAirtel { get; set; }

        [Required]
        [MaxLength(30)]
        public string TelcoServicesGlo { get; set; }

        [Required]
        [MaxLength(30)]
        public string TelcoServices9Mobile { get; set; }

        [Required]
        [MaxLength(20)]
        public string CCTV { get; set; }

        [Required]
        public bool IsTransfered { get; set; } = false;
    }
}
