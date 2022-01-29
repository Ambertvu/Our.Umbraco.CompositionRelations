angular.module('umbraco.services').factory('compositionRelationsApiResource',
    function ($q, $http, umbRequestHelper) {
        console.log(Umbraco.Sys.ServerVariables);
        console.log(Umbraco.Sys.ServerVariables.ourUmbracoCompositionRelations);

        var baseUrl = Umbraco.Sys.ServerVariables.ourUmbracoCompositionRelations.compositionRelations;
        

        return {
            getRelationsForContentType: function (nodeId) {
                return umbRequestHelper.resourcePromise(
                    $http.get(baseUrl + "GetRelationsForContentType?nodeId=" + nodeId));
            }
        };
    }
);
    