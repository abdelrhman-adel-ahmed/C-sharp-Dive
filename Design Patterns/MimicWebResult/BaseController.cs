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
            Iprovider provider = new Provider1();
            TOutput output = default(TOutput);
            output =processDelegate(provider);
            return output;
        }


    }
}
