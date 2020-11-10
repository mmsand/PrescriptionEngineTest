using System;

namespace Intricon.PrescriptionEngine.Src.Model
{

    /// <summary>
    /// string name = "L200B";                  // argument 1 Name as string i.e.(L200B)
    /// string serialNumber = string.Empty;     // argument 2 SN i.e.(1234567)
    /// int tubing = 0;                         // argument 3 tubing_Libby4 = 0, tubing_Libby3 = 1, tubing_Std13 = 2, tubing_ThinTube = 3, tubing_RIC = 4, tubing_None = 5
    /// int tip = 0;                            // argument 4 vent_Tight = 0, vent_Occluded = 1, vent_ClosedDome = 2, vent_diam1mm = 3, vent_diam2mm = 4, vent_diam3mm = 5, vent_OpenDome = 6
    /// int gender = 0;                         // argument 5 unknown = 0, male = 1, female = 2
    /// DateTime dateOfBirth = new DateTime();  // argument 6 Date of birth i.e.(1/1/1990)
    /// int noOfAids = 0;                       // argument 7 Unilateral = 0, Bilateral = 1
    /// string[] audiogramAC = new string[11];  // argument 8 dB @ each frequency (125, 250, 500, 750, 1000, 1500, 2000, 3000, 4000, 6000, 8000)
    ///                                        // argument 9 dB @ each frequency (125, 250, 500, 750, 1000, 1500, 2000, 3000, 4000, 6000, 8000)
    /// string[] otherSideAC = { "-999", "-999", "-999", "-999", "-999", "-999", "-999", "-999", "-999", "-999", "-999" };
    /// string manufacturerData = 0,1,2,3,4,5,6,7,8,9
    /// args from the console application example: L200B 17-123456 3 6 1 01-01-1990 0  50,50,50,50,50,50,50,50,50,50,50 0,1,2,3,4,5,6,7,8,9
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public class FittingRequest
    {
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public int Tubing { get; set; }
        public int Tip { get; set; }
        public int Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int NumberOfAids { get; set; }
        public string[] Audiogram { get; set; }
        public string[] OtherAudiogram { get; set; }
        public string ManufacturerData { get; set; }

        public bool Validate()
        {
            return (DateOfBirth == DateTime.MinValue);
        }
    }
}
