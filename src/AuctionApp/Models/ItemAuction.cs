using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionApp.Models
{
    public class ItemAuction
    {
        public int Id { get; set; }

        [Required (ErrorMessage ="Item Name is Required")]
        [MinLength(5)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Item Description is Required")]
        [MinLength(10)]
        public string Description { get; set; }

        [Required (ErrorMessage = "Minimum Amount for Bid is Required")]
        [Range(1,10000000, ErrorMessage = "Value for Minimun Bid must be between 1 and 10,000,000")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal MinimumBid { get; set; }

        [Required (ErrorMessage = "The minimun quantity of bids must be between 1 and 100")]
        [Range(1,100)]
        public int NumberOfBid { get; set; }

        public ICollection<BidAuctionItem> BidsAuctionItem { get; set; }
    }
}
