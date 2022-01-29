
namespace Our.Umbraco.CompositionRelations.Static
{
    public static class Constants
    {
        public static class Package
        {
            public const string PluginName = "CompositionRelations";
            public const string Alias = "ourUmbracoCompositionRelations";
        }

        public static class Apps
        {
            public static class CompositionsRelationsApp
            {
                public const string Alias = "compositionRelations";
                public const string Name = "Relations";
                public const string Icon = "icon-filter-arrows";
                public const string View = "/App_Plugins/CompositionRelations/compositionrelations.html";
                public const int Weight = 0;

            }
        }
        public static class ApiPaths
        {
            public const string CompositionRelationsController = "compositionRelations";
        }
    }
}
