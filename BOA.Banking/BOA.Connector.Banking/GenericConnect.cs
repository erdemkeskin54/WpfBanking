using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOA.Types.Banking;
using System.Reflection;

namespace BOA.Connector.Banking
{
    public class GenericConnect<T> where T : ResponseBase
    {

        public T Execute(RequestBase request)
        {
            var response = new ResponseBase();

            string nameSpace = request.GetType().GetTypeInfo().FullName;

            //verify
            string[] temp = nameSpace.Split('.');
            if (temp.Length < 2)
            {
                response.ErrorMessage = "Namespace hatalı";
                return (T)response;
            }
            if (!nameSpace.Contains("BOA.Types.Banking"))
            {
                response.ErrorMessage = "Root Namespace hatalı";
                return (T)response;
            }

            string newNameSpace = "BOA.Process.Banking";

            Assembly assembly = Assembly.Load(newNameSpace);

            //var pr = new BOA.Process.Banking.Customer();
            var instance = assembly.CreateInstance(newNameSpace + "." + temp[3].Replace("Request", ""));

            //response = pr.CustomerAll((CustomerRequest)request);
            var tempResponse = (T)instance.GetType().GetMethod(request.MethodName).Invoke(instance, new object[] { request });
            
            return tempResponse;
        }
    }
}
