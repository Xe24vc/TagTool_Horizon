using BlamCore.Cache.Base;
using BlamCore.Cache.HaloOnline;

namespace TagTool.Commands.Porting
{
    static class PortingContextFactory
    {
        public static CommandContext Create(CommandContextStack contextStack, GameCacheContext cacheContext, CacheFile blamCache)
        {
            var context = new CommandContext(contextStack.Context, blamCache.Header.scenarioName);

            Populate(context, cacheContext, blamCache);

            return context;
        }

        public static void Populate(CommandContext context, GameCacheContext cacheContext, CacheFile blamCache)
        {
            context.AddCommand(new ListBitmapsCommand(cacheContext, blamCache));
            context.AddCommand(new PortRenderModelCommand(cacheContext, blamCache));
            context.AddCommand(new PortCollisionModelCommand(cacheContext, blamCache));
            context.AddCommand(new PortPhysicsModelCommand(cacheContext, blamCache));
            context.AddCommand(new PortModelAnimationGraphCommand(cacheContext, blamCache));
            context.AddCommand(new PortFullModelCommand(cacheContext, blamCache));
            context.AddCommand(new ReadTagCommand(cacheContext, blamCache));
        }
    }
}
