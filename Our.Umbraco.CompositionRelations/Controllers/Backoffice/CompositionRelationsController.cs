using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Web.BackOffice.Controllers;
using Umbraco.Cms.Web.Common.Attributes;
using Our.Umbraco.CompositionRelations.Static;
using System.Runtime.Serialization;

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
        public List<DocType> GetRelationsForContentType(int nodeId)
        {
            var composedOf = _contentTypeService.GetComposedOf(nodeId);

            var usedIn = new List<DocType>();
            foreach (var o in composedOf)
            {
                usedIn.Add(new DocType
                { 
                Name = o.Name,
                Id =o.Id,
                Icon = o.Icon
                });
            }

            return usedIn;
        }
    }

    [DataContract(Name = "docType", Namespace = "")]
    public class DocType
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "icon")]
        public string Icon { get; set; }

    }
}
