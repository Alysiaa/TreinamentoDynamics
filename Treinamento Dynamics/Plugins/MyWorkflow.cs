using System;
using System.Activities;
using System.Runtime.CompilerServices;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;

namespace Plugins
{
    public class MyWorkflow : CodeActivity
    {
        [RequiredArgument]
        [Input("String input")]

        public InArgument<string> duracaoInput { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            decimal duracao = Convert.ToDecimal(duracaoInput.Get(context));

            if (duracao == 0)
            {
                throw new InvalidPluginExecutionException("Campo Duração não pode ser Zero");
            }
        }
    }
}
