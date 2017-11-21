using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Swashbuckle.Swagger.Annotations;

namespace fullutterance.Controllers
{
    public class AlexaController : ApiController
    {
        [Route("")]
        [HttpGet]
        [HttpHead]
        public IHttpActionResult root()
        {
            return this.Ok("Im Alive");
        }

        // POST api/values
        //[RequireHttps]
        [Route("")]
        [HttpPost]
        public HttpResponseMessage Post()
        {
            var speechlet = new SampleSessionSpeechlet();
            return speechlet.GetResponse(this.Request);
        }

    }
}
