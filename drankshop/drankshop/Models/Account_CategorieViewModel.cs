using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace drankshop.Models
{
    public class Account_CategorieViewModel
    {
        public List<CategorieViewModel> categories { get; set; }

        public AccountViewModel Account { get; set; }

        public Account_CategorieViewModel(List<CategorieViewModel> categories, AccountViewModel account)
        { 
            this.categories = categories;
            this.Account = account;
        }
    }
}
