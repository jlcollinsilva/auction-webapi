using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AuctionApp.Data;
using AuctionApp.Models;
using AuctionApp.ViewModels;
using AuctionApp.Services;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AuctionApp.Api
{
    [Route("api/[controller]")]
    public class AuctionItemController : Controller
    {
        //private IRepository _repo;

        private AuctionItemService _auctionitemservice;

        /* public AuctionItemController (IRepository repo)

         {
             this._repo = repo;
         }
         */

        public AuctionItemController(AuctionItemService auctionitemservice)

        {
            this._auctionitemservice = auctionitemservice;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<ItemAuction> Get()
        {
            return _auctionitemservice.ListItemAuction();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var auction = _auctionitemservice.FindItemAuction(id);

            if (auction == null) {

                return NotFound();
            }
            return Ok(auction);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]ItemAuction itemauction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            if (itemauction.Id == 0)
            {
                _auctionitemservice.CreateItemAuction(itemauction);
            }

            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{name,amt}")]
        public IActionResult Put([FromBody]ItemAuction itemauction)
        {
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}