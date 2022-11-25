using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Drank
{
    public interface IDrankContainer
    {
        public bool DrankBewerken(DrankDTO drankDTO);
        public bool BeschikbaarCheck(DrankDTO drankDTO);
        public List<DrankDTO> AlleDranken();
        public bool DrankAanmaken(DrankDTO drankDTO);
        public bool DrankVerwijderen(int id);
        public List<DrankDTO> DrankPerCategorie(int categorieId);
        public DrankDTO DrankPerId(int id);
    }
}
