using System;

namespace Intricon.PrescriptionEngine.Src.Model
{
    public class FittingResponse
    {
        public FittingResponse(string[] configuration)
        {
            Configuration = String.Join("", configuration);
        }

        public FittingResponse(byte[] configuration)
        {
            Configuration = Convert.ToBase64String(configuration);
        }

        public string Configuration { get; set; }
    }
}
