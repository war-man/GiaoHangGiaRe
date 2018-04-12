using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GiaoHangGiaRe.Controllers
{
    [RoutePrefix("api/image")]
    public class ImageAPIController : ApiController
    {
        [Route("upload")]
        [HttpPost]
        public IHttpActionResult upload(string base64)
        {
            return Ok();
        }
    }
}
