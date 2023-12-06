using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sms
{
   public static class baglanmysql
    {
       public static string baglanmakucin() 
       {
          string bag = "SERVER=10.10.10.1;DATABASE=hmu;Uid=root;Pwd=''";

          return bag;
       }
    }
}
