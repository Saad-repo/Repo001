using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProviderRegister.Models
{
    public class Repository
    {
        private static List<ProviderInfo> providers = new List<ProviderInfo>();

        public static IEnumerable<ProviderInfo> Providers => providers;

        public static void AddProvider(ProviderInfo providerInfo)
        {
            providers.Add(providerInfo);
        }
    }
}
