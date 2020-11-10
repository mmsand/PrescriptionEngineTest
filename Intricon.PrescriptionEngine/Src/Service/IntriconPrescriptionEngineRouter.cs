using System;
using System.Collections.Generic;
using Intricon.PrescriptionEngine.Src.Model;

namespace Intricon.PrescriptionEngine.Src.Service
{
    public class IntriconPrescriptionEngineRouter
    {
        public static List<string> AudionAidTypes = new List<string>
        {
            "L200B", "W7"
        };

        public static bool IsAudionBasedAid(FittingRequest request)
        {
            return AudionAidTypes.Contains(request.Name);
        }

        public static FittingResponse Fit(FittingRequest request)
        {
            PrescriptionAND.Model model = new PrescriptionAND.Model()
            {
                Name = request.Name,
                SerialNumber = request.SerialNumber
            };

            PrescriptionAND.AutofitInputs autofitInputs =
                new PrescriptionAND.AutofitInputs()
                {
                    Gender = (IPDT.gender_enum)request.Gender,
                    DOB_Year = (short)request.DateOfBirth.Year,
                    DOB_Month = (short)request.DateOfBirth.Month,
                    DOB_Day = (short)request.DateOfBirth.Day,
                    NumberOfAids = (IPDT.noOfAids_enum)request.NumberOfAids,
                    TubingType = (IPDT.tubing_enum)request.Tubing,
                    VentType = (IPDT.ventType_enum)request.Tip
                };

            for (int i = 0; i < 11; i++)
            {
                autofitInputs.AudiogramAC[i] =
                    float.Parse(request.Audiogram[i]);

                autofitInputs.AudiogramACOtherSide[i] =
                    float.Parse(request.OtherAudiogram[i]);
            }

            if (!String.IsNullOrEmpty(request.ManufacturerData))
            {
                int[] data = new int[10];
                int i = 0;

                foreach (var s in request.ManufacturerData.Split(','))
                {
                    // handle case when inputs have more than 10 MDA
                    if (i > 9) break;

                    int num;

                    if (int.TryParse(s, out num))
                    {
                        data[i] = num;
                    }
                    i++;
                }
                autofitInputs.Mda = data;
            }

            switch (request.Name)
            {
                case "L200B":
                    return new FittingResponse(
                        PrescriptionAND.Autofit.AutoFitAllPrograms(
                            model, autofitInputs).byteArray
                        );
                case "W7":
                    return new FittingResponse(
                        PrescriptionAND.Autofit.Audion4AutoFit(
                            model, autofitInputs)
                    );
            }

            throw new Exception("Unknown Intricon aid type " + request.Name);
        }
    }
}
