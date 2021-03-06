﻿using BlamCore.Cache.HaloOnline;
using BlamCore.TagDefinitions;

namespace TagTool.Commands.ScenarioStructureBSPs
{
    static class BSPContextFactory
    {
        public static CommandContext Create(CommandContext parent, GameCacheContext info, CachedTagInstance tag, ScenarioStructureBsp bsp)
        {
            var groupName = info.GetString(tag.Group.Name);

            var context = new CommandContext(parent,
                string.Format("{0:X8}.{1}", tag.Index, groupName));

            Populate(context, info, tag, bsp);

            return context;
        }

        public static void Populate(CommandContext context, GameCacheContext info, CachedTagInstance tag, ScenarioStructureBsp bsp)
        {
            context.AddCommand(new CollisionTestCommand(info, tag, bsp));
        }
    }
}

