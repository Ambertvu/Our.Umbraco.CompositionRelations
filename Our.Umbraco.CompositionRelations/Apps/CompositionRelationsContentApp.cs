using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.ContentEditing;
using Umbraco.Cms.Core.Models.Membership;
using Umbraco.Cms.Core.Services;

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
                    Alias = "compositionRelations",
                    Name = "Relations",
                    Icon = "icon-filter-arrows",
                    View = "/App_Plugins/CompositionRelations/compositionrelations.html",
                    Weight = 0
                };
                return compositionRelationsApp;
            }
            return null;
        }

    }
}
