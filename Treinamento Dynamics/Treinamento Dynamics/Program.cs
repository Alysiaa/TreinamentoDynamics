using System;
using Microsoft.Xrm.Tooling.Connector;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;

namespace Treinamento_Dynamics
{
    public class Program
    {
        static void Main(string[] args)
        {
            var crmService = new Conexao().ObterConexao();

            //1ºTeste
            /*FetchXML(crmService);
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
            }*/
            CriacaoLinq(crmService);
        }

        static void CriacaoLinq(CrmServiceClient crmService)
            {
            OrganizationServiceContext context = new OrganizationServiceContext(crmService);
            for (int i = 0; i < 10; i++) 
            {
                Entity account = new Entity("account");
                account["name"] = "Conta Linq" + i + " - "+ DateTime.Now.ToString();
                context.AddObject(account);
                Console.WriteLine("Conta criada: - Conta Linq " + i + " - " + DateTime.Now.ToString());
            }
            context.SaveChanges();
            }

        }
    }
