using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionApp.Models
{
    public class BidAuctionItem 
    {
        public int Id { get; set; }

        [Required]
        public string BidName { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal BidAmount { get; set; }
        public int ItemAuctionId { get; set; }
        [ForeignKey("ItemAuctionId")]
        public virtual ItemAuction ItemAuction { get; set; }

    }
}