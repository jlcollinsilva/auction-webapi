using AuctionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionApp.Services
{
    public class AuctionItemService : IRepository

    {

        private IRepository _repo;

        public AuctionItemService(IRepository repo)
        {
            this._repo = repo;
        }

        public void BidAuction(BidAuctionItem bidauctionitem)
        {
            throw new NotImplementedException();
        }

        public int CountBid(int auctionactionid)
        {
            throw new NotImplementedException();
        }

        public void CreateItemAuction(ItemAuction itemAuctionToCreate)
        {
            _repo.CreateItemAuction(itemAuctionToCreate);
        }

        public void Dispose()
        {
            _repo.Dispose();
        }

        public ItemAuction FindItemAuction(int id)
        {
            return _repo.FindItemAuction(id);
        }

        public IList<ItemAuction> ListItemAuction()
        {
            return _repo.ListItemAuction();
        }

        public decimal MaxBid(int auctionitemid)
        {
            throw new NotImplementedException();
        }

    }
}
