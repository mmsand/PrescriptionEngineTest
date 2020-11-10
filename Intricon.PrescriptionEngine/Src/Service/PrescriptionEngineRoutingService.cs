using System;
using Intricon.PrescriptionEngine.Src.Model;
using Intricon.PrescriptionEngine.Src.Service;

namespace Intricon.PrescriptionEngine.Controllers
{
    public class PrescriptionEngineRoutingService
    {

        public static FittingResponse Fit(FittingRequest request)
        {
            try
            {
                RouteFit(request);             
            }
            catch (Exception ex)
            {
                PrintMessage(ex.Message);

                throw;
            }

            throw new Exception("Unknown aid type of" + request.Name);
        }        

        private static FittingResponse RouteFit(FittingRequest request)
        {
            if (IntriconPrescriptionEngineRouter.IsAudionBasedAid(request)) {
                return IntriconPrescriptionEngineRouter.Fit(request);
            }

            throw new Exception("Could not route aid type " + request.Name);
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
