using System;
using Intricon.PrescriptionEngine.Src.Model;
using Intricon.PrescriptionEngine.Src.Service;

namespace Intricon.PrescriptionEngine.Controllers
{
    public class PrescriptionEngineRoutingService
    {

        public static FittingResponse Fit(FittingRequest request)
        {
            return RouteFit(request);     
        }        

        private static FittingResponse RouteFit(FittingRequest request)
        {
            if (IntriconPrescriptionEngineRouter.IsAudionBasedAid(request)) {
                return IntriconPrescriptionEngineRouter.Fit(request);
            }

            throw new Exception("Could not route aid type " + request.Name);
        }
    }
}