using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LOGIC;

namespace drankshop.Models
{
    public class FavorietViewModel
    {
        public int drankid { get; set; }
        public int accountid { get; set; }
        public FavorietViewModel(Favoriet favoriet)
        {
            this.drankid = favoriet.Drank.Id;
            this.accountid = favoriet.Account.Id;
        }
    }
}
