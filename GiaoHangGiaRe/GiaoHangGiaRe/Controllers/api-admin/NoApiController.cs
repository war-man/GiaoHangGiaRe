using GiaoHangGiaRe.Models;
using GiaoHangGiaRe.Module;
using Models.EntityModel;
using System.Web.Http;

namespace GiaoHangGiaRe.Controllers
{
    [RoutePrefix("api/no")]
    [Authorize]

    public class NoApiController : ApiController
    {
        private NoServices _noServices;
        public NoApiController()
        {
            _noServices = new NoServices();
        }
        // GET: api/get-all
        [HttpGet]
        [Route("get-all")]
        public IHttpActionResult Get(NoSearchList noSearchList)
        {
            return Ok(new {
                data = _noServices.GetAll(noSearchList),
                total = _noServices.Count(),
                noSearchList.page,
                noSearchList.size
            }
            );
        }

        // GET: api/get-by-id
        [HttpGet]
        [Route("get-by-id")]
        public IHttpActionResult GetById(int id)
        {
            return Ok(_noServices.GetById(id));
        }

        // POST: api/
        [HttpPost]
        [Route("create")]
        public IHttpActionResult Create(No input)
        {
            _noServices.Create(input);
            return Ok(new
            {
                obj = input,
                message = "success"
            });
        }
        [HttpPut]
        [Route("update")]
        public IHttpActionResult Update(No input)
        {
            _noServices.Update(input);
            return Ok(new
            {
                obj = input,
                message = "success"
            });
        }
    }
}
