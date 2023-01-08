using System;
using Microsoft.Xrm.Tooling.Connector;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Crm.Sdk.Messages;

namespace Treinamento_Dynamics
{
    public class Program
    {
        static void Main(string[] args)
        {
            var crmService = new Conexao().ObterConexao();
            FetchXML(crmService);
        }
        #region FetchXML1
        static void FetchXML(CrmServiceClient crmService)
        {
            string query = @"<fetch version= '1.0' output-format= 'xml-platform' mapping= 'logical' distinct= 'false'>
                             <entity name = 'account'>
                             <attribute name= 'name'/>
                             <attribute name='primarycontactid'/>
                             <attribute name='telephone1'/>
                             <attribute name='accountid'/>
                             <attribute name='createdon'/>
                             <order attribute = 'name' descending = 'false'/>
                             </entity>
                             </fetch>";

            EntityCollection colecao = crmService.RetrieveMultiple(new FetchExpression(query));
            foreach (var item in colecao.Entities)
            #endregion
            { }
        }
    }
   
}
