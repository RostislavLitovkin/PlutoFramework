﻿using Microsoft.Extensions.DependencyInjection;
using UniqueryPlus.OpalSubquery;
using StrawberryShake.Serialization;
using UniqueryPlus.Speck;
using UniqueryPlus.Stick;
using UniqueryPlus.UniqueSubquery;

namespace UniqueryPlus
{
    public static class Indexers
    {
        public static ISpeck GetSpeckClient()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection
                .AddSpeck()
                .ConfigureHttpClient(client => client.BaseAddress = new Uri("https://kodadot.squids.live/speck:prod/api/graphql"));

            IServiceProvider services = serviceCollection.BuildServiceProvider();

            return services.GetRequiredService<ISpeck>();
        }

        public static IStick GetStickClient()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection
                .AddStick()
                .ConfigureHttpClient(client => client.BaseAddress = new Uri("https://kodadot.squids.live/stick:prod/api/graphql"));

            IServiceProvider services = serviceCollection.BuildServiceProvider();

            return services.GetRequiredService<IStick>();
        }

        public static IUniqueSubquery GetUniqueSubqueryClient()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection
                .AddUniqueSubquery()
                .ConfigureHttpClient(client => client.BaseAddress = new Uri("https://api-unique.uniquescan.io/v1/graphql"));

            serviceCollection.AddSerializer(new JsonSerializer("JSON"));

            IServiceProvider services = serviceCollection.BuildServiceProvider();

            return services.GetRequiredService<IUniqueSubquery>();
        }

        public static IOpalSubquery GetOpalSubqueryClient()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection
                .AddOpalSubquery()
                .ConfigureHttpClient(client => client.BaseAddress = new Uri("https://api-opal.uniquescan.io/v1/graphql"));

            serviceCollection.AddSerializer(new JsonSerializer("JSON"));

            IServiceProvider services = serviceCollection.BuildServiceProvider();

            return services.GetRequiredService<IOpalSubquery>();
        }
    }
}
