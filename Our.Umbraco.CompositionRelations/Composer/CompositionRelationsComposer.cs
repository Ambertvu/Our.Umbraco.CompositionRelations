using Our.Umbraco.CompositionRelations.Apps;
using Our.Umbraco.ContentRelations.Notifications;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Notifications;

namespace Our.Umbraco.CompositionRelations.Composer
{
    public class CompositionRelationsComposer : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            builder.ContentApps().Append<CompositionRelationsContentApp>();
            builder.AddNotificationHandler<ServerVariablesParsingNotification, VariablesHandler>();


        }
    }
}
