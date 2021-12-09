using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns
{
    class BaseDSL
    {

        public TOutput Execute<TOutput>(Func<Iprovider, TOutput> processDelegate,
                                                         string genericErrorMessage, bool isTransaction = false)
        {
            //1- get connection type 
            //2- initialize connection factory 
            //3- get connection object eaither oracle or sql using the connection factory we created 

            //TOutput output = "aa"; --> error why ?!!!>
            TOutput output = default(TOutput);
            return output;
        }

    }
}
