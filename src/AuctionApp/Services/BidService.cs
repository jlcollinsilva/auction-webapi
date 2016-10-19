using AuctionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AuctionApp.Services
{
        
     public class BidService : IRepository
    {
        private IRepository _repo;

        public BidService(IRepository repo)
        {
            this._repo = repo;
        }

        public void BidAuction(BidAuctionItem bidauctionitem)
        {
            _repo.BidAuction(bidauctionitem);
        }

        public int CountBid(int auctionactionid)
        {
            return _repo.CountBid(auctionactionid);
        }

        public void CreateItemAuction(ItemAuction itemAuctionToCreate)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public ItemAuction FindItemAuction(int id)
        {
            throw new NotImplementedException();
        }

        public IList<ItemAuction> ListItemAuction()
        {
            throw new NotImplementedException();
        }

        public decimal MaxBid(int auctionitemid)
        {
            return _repo.MaxBid(auctionitemid);
        }

        public string validateBid(BidAuctionItem bidauctionitem)
        {

            var maxibid = _repo.MaxBid(bidauctionitem.ItemAuction.Id);
            var countbid = _repo.CountBid(bidauctionitem.ItemAuction.Id);

            //You should not be able to place a bid lower than the Minimum Bid.
            if (bidauctionitem.BidAmount < bidauctionitem.ItemAuction.MinimumBid)
            {
                return string.Format("Error: The minimum Bid accepted for this item is :{0:c}",
                                    bidauctionitem.ItemAuction.MinimumBid);
            }
            else if (countbid >= bidauctionitem.ItemAuction.NumberOfBid)
            { // An auction closes automatically after NumberOfBids is reached.
                return string.Format("Error: You are trying to Bid a closed auction , ID :{0}", bidauctionitem.ItemAuction.Id);
            }
            else if (maxibid >= bidauctionitem.BidAmount)
            {//You should not be able to place a bid lower than any previous bids.
                return string.Format("Error: You must Bid higher than {0:c}", maxibid);
            }

            return ("OK");

        }
    } 
    }