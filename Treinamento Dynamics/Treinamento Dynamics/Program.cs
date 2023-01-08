using System;
using Microsoft.Xrm.Tooling.Connector;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;


namespace Treinamento_Dynamics
{
    public class Program
    {
        static void Main(string[] args)
        {
            var crmService = new Conexao().ObterConexao();
            QueryExpression(crmService);
            // CriacaoLinq(crmService);
            // FetchXML(crmService);
            
        }
        #region CriacaoLinq
        //CriacaoLinq(crmService)
        static void CriacaoLinq(CrmServiceClient crmService)
        {
            OrganizationServiceContext context = new OrganizationServiceContext(crmService);
            for (int i = 0; i < 10; i++)
            {
                Entity account = new Entity("account");
                account["name"] = "Conta Linq" + i + " - " + DateTime.Now.ToString();
                context.AddObject(account);
                Console.WriteLine("Conta criada: - Conta Linq " + i + " - " + DateTime.Now.ToString());
            }
            context.SaveChanges();
            Console.ReadLine();
        }
        #endregion
        
        //1ºTeste - Criando o método Fetch XML
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
           
            {
                Console.WriteLine(item["name"]);
                if (item.Attributes.Contains("telephone1"))
                {
                    Console.WriteLine(item["telephone1"]);
                }
            }
            Console.ReadLine();
        }
        #endregion

        #region QueryExpression
        static EntityCollection QueryExpression(CrmServiceClient crmService)
        {
        QueryExpression queryExpression= new QueryExpression("account");

            queryExpression.Criteria.AddCondition("name", ConditionOperator.Like, "%Linq%");
            queryExpression.ColumnSet = new ColumnSet("name");

            EntityCollection colecaoEntidades = crmService.RetrieveMultiple(queryExpression);
            foreach (var item in colecaoEntidades.Entities)
            {
                Console.WriteLine(item["name"]);
            }
            Console.ReadKey();
            return colecaoEntidades;    
        }
        #endregion
    }
}
