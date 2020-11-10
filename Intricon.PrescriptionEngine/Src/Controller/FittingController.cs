using System;
using System.Web.Http;
using Intricon.PrescriptionEngine.Src.Model;

namespace Intricon.PrescriptionEngine.Controllers
{
    public class FittingController : ApiController
    {

        //todo: [ApiAuthorize]
        public FittingResponse Post([FromBody] FittingRequest request)
        {
            if (!request.Validate())
            {
                throw new ArgumentException(
                    "Invalid date", "dateOfBirth");
            }

            return PrescriptionEngineRoutingService.Fit(
                    request
            );
        }
    }
}