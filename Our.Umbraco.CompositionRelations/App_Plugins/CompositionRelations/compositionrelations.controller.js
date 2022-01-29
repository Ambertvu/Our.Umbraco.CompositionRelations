angular.module("umbraco")
    .controller("CompositionRelationApp", function ($scope, editorState, compositionRelationsApiResource) {

        var vm = this;
        vm.composedOf = [];
 
        function init() {
            compositionRelationsApiResource.getRelationsForContentType(editorState.current.id).then(function (response) {
                vm.composedOf = response;
            });
        }
         
        init();

    });