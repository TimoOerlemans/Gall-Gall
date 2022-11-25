using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace drankshop.Models
{
    public class Account_DrankViewmodel
    {
        public List<DrankViewModel> dranken { get; set; }

        public AccountViewModel Account { get; set; }
        public DrankViewModel dranks { get; set; }
        public Account_DrankViewmodel(DrankViewModel dranken, AccountViewModel account)
        {
            this.dranks = dranken;
            this.Account = account;
        }

        public Account_DrankViewmodel(List<DrankViewModel> dranken, AccountViewModel account)
        {
            this.dranken = dranken;
            this.Account = account;
        }
        public Account_DrankViewmodel()
        {

        }
    }
}
