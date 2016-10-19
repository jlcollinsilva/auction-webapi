using AuctionApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AuctionApp.Models
{
    public interface IRepository
    {
        void CreateItemAuction(ItemAuction itemAuctionToCreate);
        void Dispose();
        ItemAuction FindItemAuction(int id);
        IList<ItemAuction> ListItemAuction();
        void BidAuction(BidAuctionItem bidauctionitem);
        int CountBid(int auctionactionid);
        decimal MaxBid(int auctionitemid);
    }
}