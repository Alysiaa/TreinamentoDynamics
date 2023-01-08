using System;
using System.Net;
using Microsoft.Xrm.Tooling.Connector;

namespace Treinamento_Dynamics
{
    public class Conexao
    {
        private static CrmServiceClient crmServiceClientTrinamento;

        public CrmServiceClient ObterConexao()
        {
            var connectionStringCRM = @"AuthType=OAuth;
                             Username = TreinamentoDyn@dyn789.onmicrosoft.com;
                             Password = 61966196Carol; SkipDiscovery = True;
                             AppID= 51f81489-12ee-4a9e-aaae-a2591f45987d;
                             RedirectUri = app://58145B91-0C36-4500-8554-080854F2AC97;
                             Url = https://orgb80c66bc.crm2.dynamics.com/main.aspx;";

            if (crmServiceClientTrinamento== null) 
            {
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                crmServiceClientTrinamento= new CrmServiceClient(connectionStringCRM);
                    }
            return crmServiceClientTrinamento;
        }
    }
}
