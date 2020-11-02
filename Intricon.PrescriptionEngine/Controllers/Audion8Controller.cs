using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Intricon.PrescriptionEngine.Controllers
{
    // [ApiAuthorize]
    //public class Audion8Controller : ApiController
    //{
    //    /// <summary>
    //    /// string name = "L200B";                  // argument 1 Name as string i.e.(L200B)
    //    /// string serialNumber = string.Empty;     // argument 2 SN i.e.(1234567)
    //    /// int tubing = 0;                         // argument 3 tubing_Libby4 = 0, tubing_Libby3 = 1, tubing_Std13 = 2, tubing_ThinTube = 3, tubing_RIC = 4, tubing_None = 5
    //    /// int tip = 0;                            // argument 4 vent_Tight = 0, vent_Occluded = 1, vent_ClosedDome = 2, vent_diam1mm = 3, vent_diam2mm = 4, vent_diam3mm = 5, vent_OpenDome = 6
    //    /// int gender = 0;                         // argument 5 unknown = 0, male = 1, female = 2
    //    /// DateTime dateOfBirth = new DateTime();  // argument 6 Date of birth i.e.(1/1/1990)
    //    /// int noOfAids = 0;                       // argument 7 Unilateral = 0, Bilateral = 1
    //    /// string[] audiogramAC = new string[11];  // argument 8 dB @ each frequency (125, 250, 500, 750, 1000, 1500, 2000, 3000, 4000, 6000, 8000)
    //    ///                                        // argument 9 dB @ each frequency (125, 250, 500, 750, 1000, 1500, 2000, 3000, 4000, 6000, 8000)
    //    /// string[] otherSideAC = { "-999", "-999", "-999", "-999", "-999", "-999", "-999", "-999", "-999", "-999", "-999" };
    //    /// string manufacturerData = 0,1,2,3,4,5,6,7,8,9
    //    /// args from the console application example: L200B 17-123456 3 6 1 01-01-1990 0  50,50,50,50,50,50,50,50,50,50,50 0,1,2,3,4,5,6,7,8,9
    //    /// </summary>
    //    /// <param name="request"></param>
    //    /// <returns></returns>

    //    //[ApiAuthorize]
    //    public Audion8Response Post([FromBody] Audion8Request request)
    //    {
    //        if (request.DateOfBirth == DateTime.MinValue)
    //        {
    //            throw new ArgumentException("Invalid date", "dateOfBirth");
    //        }

    //        var configuration = Engine.GetConfiguration(
    //            request.Name,
    //            request.SerialNumber,
    //            request.Tubing,
    //            request.Tip,
    //            request.Gender,
    //            request.DateOfBirth,
    //            request.NumberOfAids,
    //            request.Audiogram,
    //            request.OtherAudiogram,
    //            request.ManufacturerData
    //        );

    //        return new Audion8Response(configuration);
    //    }

    public class Audion8Request
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
    }

    public class Audion8Response
    {
        public Audion8Response(byte[] configuration)
        {
            Configuration = Convert.ToBase64String(configuration);
        }

        public string Configuration { get; set; }
    }

    //}

    // [ApiAuthorize]
    public class Audion4Controller : ApiController
    {
        /// <summary>
        /// string name = "W7";                  // argument 1 Name as string i.e.(L200B)
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

        // [ApiAuthorize]
        public Audion4Response Post([FromBody] Audion8Request request)
        {
            if (request.DateOfBirth == DateTime.MinValue)
            {
                throw new ArgumentException("Invalid date", "dateOfBirth");
            }

            var configuration = Engine.GetA4Configuration(
                request.Name,
                request.SerialNumber,
                request.Tubing,
                request.Tip,
                request.Gender,
                request.DateOfBirth,
                request.NumberOfAids,
                request.Audiogram,
                request.OtherAudiogram,
                request.ManufacturerData
            );

            return new Audion4Response(configuration);
        }

        public class Audion4Request
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
        }
        public class Audion4Response
        {
            public Audion4Response(string[] A4configuration)
            {
                Configuration = "";  //Convert.ToBase64String A4configuration[];
            }

            public string Configuration { get; set; }
        }

    }

    public static class Engine
    {
        public static byte[] GetConfiguration(string name, string serialNumber, int tubing, int tip, int gender, DateTime dateOfBirth, int noOfAids, string[] audiogramAC, string[] otherSideAC, string manufacturerData)
        {
            try
            {
                // Set Model
                PrescriptionAND.Model model = new PrescriptionAND.Model()
                {
                    Name = name,
                    SerialNumber = serialNumber
                };

                // Set Auto Fit Inputs
                PrescriptionAND.AutofitInputs autofitInputs = new PrescriptionAND.AutofitInputs()
                {
                    Gender = (IPDT.gender_enum)gender,
                    DOB_Year = (short)dateOfBirth.Year,
                    DOB_Month = (short)dateOfBirth.Month,
                    DOB_Day = (short)dateOfBirth.Day,
                    NumberOfAids = (IPDT.noOfAids_enum)noOfAids,
                    TubingType = (IPDT.tubing_enum)tubing,
                    VentType = (IPDT.ventType_enum)tip
                };

                for (int i = 0; i < 11; i++)
                {
                    //autofitInputs.AudiogramAC[i] = float.Parse(audiogramAC[i]);
                    //autofitInputs.AudiogramACOtherSide[i] = float.Parse(otherSideAC[i]);
                    autofitInputs.AudiogramAC[i] = (byte)float.Parse(audiogramAC[i]);
                    autofitInputs.AudiogramACOtherSide[i] = (byte)0;
                }

                //Manufacturer Data
                if (!String.IsNullOrEmpty(manufacturerData))
                {
                    int[] data = new int[10];
                    int i = 0;
                    foreach (var s in manufacturerData.Split(','))
                    {
                        if (i > 9) break; // handle case when inputs have more than 10 MDA
                        int num;
                        if (int.TryParse(s, out num))
                        {
                            data[i] = num;
                        }
                        i++;
                    }
                    autofitInputs.Mda = data;
                }

                // Do the Auto fit
                GenericAudion8BLE.BleLoadData bleLoadData = PrescriptionAND.Autofit.AutoFitAllPrograms(model, autofitInputs);

                return bleLoadData.byteArray;
            }
            catch (Exception ex)
            {
                PrintMessage(ex.Message);
                throw;
            }
        }

        public static string[] GetA4Configuration(string name, string serialNumber, int tubing, int tip, int gender, DateTime dateOfBirth, int noOfAids, string[] audiogramAC, string[] otherSideAC, string manufacturerData)
        {
            try
            {
                // Set Model
                PrescriptionAND.Model model = new PrescriptionAND.Model()
                {
                    Name = name,
                    SerialNumber = serialNumber
                };

                // Set Auto Fit Inputs
                PrescriptionAND.AutofitInputs autofitInputs = new PrescriptionAND.AutofitInputs()
                {
                    Gender = (IPDT.gender_enum)gender,
                    DOB_Year = (short)dateOfBirth.Year,
                    DOB_Month = (short)dateOfBirth.Month,
                    DOB_Day = (short)dateOfBirth.Day,
                    NumberOfAids = (IPDT.noOfAids_enum)noOfAids,
                    TubingType = (IPDT.tubing_enum)tubing,
                    VentType = (IPDT.ventType_enum)tip
                };

                for (int i = 0; i < 11; i++)
                {
                    autofitInputs.AudiogramAC[i] = float.Parse(audiogramAC[i]);
                    autofitInputs.AudiogramACOtherSide[i] = float.Parse(otherSideAC[i]);
                }

                //Manufacturer Data
                if (!String.IsNullOrEmpty(manufacturerData))
                {
                    int[] data = new int[10];
                    int i = 0;
                    foreach (var s in manufacturerData.Split(','))
                    {
                        if (i > 9) break; // handle case when inputs have more than 10 MDA
                        int num;
                        if (int.TryParse(s, out num))
                        {
                            data[i] = num;
                        }
                        i++;
                    }
                    autofitInputs.Mda = data;
                }

                // Do the Auto fit
                // string[] A4Params = PrescriptionAND.Autofit.Audion4AutoFit(model, autofitInputs);

                // return A4Params;

                return new string[] { "Testo!" };
            }
            catch (Exception ex)
            {
                PrintMessage(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// Write to output stream
        /// </summary>
        /// <param name="message"></param>
        static void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}