using System.Collections.Generic;
using Microsoft.AspNetCore.Routing;
using Our.Umbraco.CompositionRelations.Controllers.Backoffice;
using Our.Umbraco.CompositionRelations.Static;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Extensions;

namespace Our.Umbraco.ContentRelations.Notifications
{
    public class VariablesHandler : INotificationHandler<ServerVariablesParsingNotification>
    {
        private readonly LinkGenerator _linkGenerator;

        public VariablesHandler(LinkGenerator linkGenerator)
        {
            _linkGenerator = linkGenerator;
        }

        public void Handle(ServerVariablesParsingNotification notification)
        {
            notification.ServerVariables.Add(Constants.Package.Alias, new Dictionary<string, object>
            {
                { Constants.ApiPaths.CompositionRelationsController, _linkGenerator.GetUmbracoApiServiceBaseUrl<CompositionRelationsController>(controller => controller.GetRelationsForContentType(0))},
                
            });
        }
    }
}
