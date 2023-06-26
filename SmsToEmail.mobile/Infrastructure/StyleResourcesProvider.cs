namespace SmsToEmail.mobile.Infrastructure
{
    public static class StyleResourcesProvider
    {

        private static ResourceDictionary GetResourceDictionary(string dictionaryName)
        {
            var resourceDictionary = Application.Current.Resources.MergedDictionaries.FirstOrDefault(x =>
                x.Source.OriginalString.Split(';').First().Split('/').Last().Split('.').First() == dictionaryName);
            return resourceDictionary;
        }

        public static object GetStyleResource(string resourceName)
        {
            var styleDictionary = GetResourceDictionary("styles");
            styleDictionary.TryGetValue(resourceName, out var style);
            return style;
        }

        public static object GetColorResource(string resourceName)
        {
            var styleDictionary = GetResourceDictionary("Colors");
            styleDictionary.TryGetValue(resourceName, out var color);
            return color;
        }

    }
}
