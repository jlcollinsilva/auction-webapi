using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuctionApp.Data;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Collections;
using AuctionApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using AuctionApp.Models;

namespace AuctionApp.Models
{
    public class EFRepository : IDisposable, IRepository
    {
        private ApplicationDbContext _db;

        public EFRepository(ApplicationDbContext db)
        {
            this._db = db;
        }

        public IList<ItemAuction> ListItemAuction()
        {

            return _db.ItemsAuction.Where(i => i.BidsAuctionItem.Count() <
                                               i.NumberOfBid).ToList();
            
        }

        public ItemAuction FindItemAuction(int id)
        {
            return _db.ItemsAuction.FirstOrDefault(i => i.Id == id);
        }

        public void CreateItemAuction(ItemAuction itemAuctionToCreate)
        {
            _db.ItemsAuction.Add(itemAuctionToCreate);
            _db.SaveChanges();

        }

        public void BidAuction(BidAuctionItem bidauctionitem)
        {
           
                bidauctionitem.ItemAuctionId = bidauctionitem.ItemAuction.Id;
                bidauctionitem.ItemAuction = null; //The item already exists....

                _db.BidsAuctionItem.Add(bidauctionitem);
                _db.SaveChanges();

        }


        public int CountBid(int auctionactionid)
        {
            return _db.BidsAuctionItem.Where(b => b.ItemAuctionId == auctionactionid).Count();

        }

        public decimal MaxBid(int auctionitemid)
        {

            return _db.BidsAuctionItem.Where(b => b.ItemAuctionId == auctionitemid).Max(b => b.BidAmount);

        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}