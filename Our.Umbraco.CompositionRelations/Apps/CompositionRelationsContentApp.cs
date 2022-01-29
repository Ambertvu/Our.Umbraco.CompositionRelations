using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.ContentEditing;
using Umbraco.Cms.Core.Models.Membership;
using Umbraco.Cms.Core.Services;
using Our.Umbraco.CompositionRelations.Static;

namespace Our.Umbraco.CompositionRelations.Apps
{
    public class CompositionRelationsContentApp : IContentAppFactory
    {
        private readonly IContentTypeService _contentTypeService;

        public CompositionRelationsContentApp(IContentTypeService contentTypeService)
        {
            _contentTypeService = contentTypeService;
        }

        public ContentApp GetContentAppFor(object source, IEnumerable<IReadOnlyUserGroup> userGroups)
        {
            if (source is IContentType contentType)
            {
                var composedOf = _contentTypeService.GetComposedOf(contentType.Id);
                if (composedOf == null || composedOf.Count() == 0)
                {
                    return null;
                }

                var compositionRelationsApp = new ContentApp
                {
                    Alias = Constants.Apps.CompositionsRelationsApp.Alias,
                    Name = Constants.Apps.CompositionsRelationsApp.Name,
                    Icon = Constants.Apps.CompositionsRelationsApp.Icon,
                    View = Constants.Apps.CompositionsRelationsApp.View,
                    Weight = Constants.Apps.CompositionsRelationsApp.Weight
                };
                return compositionRelationsApp;
            }
            return null;
        }

    }
}
