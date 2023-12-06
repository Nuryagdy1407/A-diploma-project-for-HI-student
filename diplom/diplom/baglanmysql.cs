using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diplom
{
   public static class baglanmysql
    {
        public static string baglanmakucin()
        {
            string bag = "SERVER=localhost;DATABASE=diplom;Uid=root;Pwd=''";

            return bag;
        }
    }
}
