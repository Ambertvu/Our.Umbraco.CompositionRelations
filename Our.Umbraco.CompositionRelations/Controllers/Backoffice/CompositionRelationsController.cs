using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Web.BackOffice.Controllers;
using Umbraco.Cms.Web.Common.Attributes;
using Our.Umbraco.CompositionRelations.Static;

namespace Our.Umbraco.CompositionRelations.Controllers.Backoffice
{
    [PluginController(Constants.Package.PluginName)]
    public class CompositionRelationsController : UmbracoAuthorizedApiController
    {
        private readonly IContentTypeService _contentTypeService;

        public CompositionRelationsController(IContentTypeService contentTypeService)
        {
            _contentTypeService = contentTypeService;
        }

        [HttpGet]
        public Dictionary<string, int> GetRelationsForContentType(int nodeId)
        {
            var composedOf = _contentTypeService.GetComposedOf(nodeId);

            var usedIn = new Dictionary<string, int>();
            foreach (var o in composedOf)
            {
                usedIn.Add(o.Name, o.Id);
            }

            return usedIn;
        }
    }
}
