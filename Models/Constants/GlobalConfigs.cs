using System.Collections.Immutable;
using Models.ViewModels.Config;

namespace Models.Constants
{
    public static class GlobalConfigs
    {
        public static ImmutableHashSet<int> StartedStreams { get; set; } = ImmutableHashSet<int>.Empty;

        public static void UpdateGlobalConfigs(GlobalConfigViewModel globalConfigViewModel)
        {
        }

        public static GlobalConfigViewModel ToViewModel()
        {
            return new GlobalConfigViewModel
            {

            };
        }
    }
}