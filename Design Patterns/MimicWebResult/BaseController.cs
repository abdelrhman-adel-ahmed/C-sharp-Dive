using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.MimicWebResult
{
    class BaseController
    {
        protected TOutput Execute<TOutput>(Func<Iprovider, TOutput> processDelegate,
                                                               string genericErrorMessage, bool isTransaction = false)
        {

            TOutput output = baseDSL.Execute(processDelegate, genericErrorMessage, isTransaction);
            return output;
        }
    }
}
