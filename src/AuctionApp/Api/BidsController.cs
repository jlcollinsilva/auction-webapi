using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AuctionApp.Models;
using AuctionApp.Services;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AuctionApp.Api
{
    [Route("api/[controller]")]
    public class BidsController : Controller
    {
        
       private BidService _bidservice;

       public BidsController(BidService bidservice)
        {
            this._bidservice = bidservice;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ItemAuction Get(int id)
        {
            return _bidservice.FindItemAuction(id); // GET: api/values
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]BidAuctionItem bidauctionitem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var resultValidationBid = _bidservice.validateBid(bidauctionitem);

            if (resultValidationBid == "OK")

            {
                _bidservice.BidAuction(bidauctionitem);
                return Ok();
            }else
            {
                this.ModelState.AddModelError("400", resultValidationBid);
                return BadRequest(this.ModelState); 
                //return View(resultValidationBid);  //(bidauctionitem);
            }
            
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}