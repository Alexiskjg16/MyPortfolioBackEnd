using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlogPortfolioAPI.Models;

namespace BlogPortfolioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RSSController : ControllerBase
    {

        private RSSFeedContext db { get; set; }

        public RSSController(RSSFeedContext _db)
        {
            this.db = _db;
        }
        public class ResponseObject
        {
            public bool WasSuccessful { get; set; }
            public object Results { get; set; }
        }


        [HttpGet]
        [Route("content")]
        public ActionResult<ResponseObject> GetAllContent()
        {
            var _emails = this.db.RSSFeed.OrderByDescending(o => o.Date);

            var _rv = new ResponseObject
            {
                WasSuccessful = true,
                Results = _emails
            };

            return _rv;
        }


        [HttpPost]
        [Route("content/add")]
        public ActionResult<ResponseObject> PostContent([FromBody] RSSFeed Content)
        {
            var _content = new RSSFeed
            {
                Name = Content.Name,
                Email = Content.Email,
                Date = DateTime.Now,
            };

            this.db.RSSFeed.Add(_content);

            this.db.SaveChanges();

            var _rv = new ResponseObject
            {
                WasSuccessful = true,
                Results = _content
            };

            return _rv;
        }
    }
}