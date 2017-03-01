using System;

namespace BlamCore.Cache
{
    public static class DefinitionsManager
    {
        private static string errorMessage = "Supplied definition set does not support \"----\" tags.";

        //---, ---, H3R, ODST, HRB, HRR, H4R
        public static cache_file_resource_layout_table play(Base.CacheFile Cache, Base.CacheFile.IndexItem Tag)
        {
            switch (Cache.Version)
            {
                case CacheVersion.Halo3Retail:
                case CacheVersion.Halo3ODST:
                case CacheVersion.HaloReachBeta:
                case CacheVersion.HaloReachRetail:
                    return new Halo3Retail.cache_file_resource_layout_table(Cache, Tag.Offset);

                case CacheVersion.Halo4Beta:
                case CacheVersion.Halo4Retail:
                    return new Halo4Beta.cache_file_resource_layout_table(Cache, Tag.Offset);

                default:
                    return null; //this tag is required for map loading, so return null if not supported
            }
        }

        //---, H3B, H3R, ODST, HRB, HRR, H4R
        public static cache_file_resource_gestalt zone(Base.CacheFile Cache, Base.CacheFile.IndexItem Tag)
        {
            switch (Cache.Version)
            {
                case CacheVersion.Halo3Beta:
                    return new Halo3Beta.cache_file_resource_gestalt(Cache, Tag.Offset);

                case CacheVersion.Halo3Retail:
                case CacheVersion.Halo3ODST:
                case CacheVersion.HaloReachBeta:
                case CacheVersion.HaloReachRetail:
                    return new Halo3Retail.cache_file_resource_gestalt(Cache, Tag.Offset);

                case CacheVersion.Halo4Beta:
                    return new Halo4Beta.cache_file_resource_gestalt(Cache, Tag.Offset);

                case CacheVersion.Halo4Retail:
                    return new Halo4Retail.cache_file_resource_gestalt(Cache, Tag.Offset);

                default:
                    return null; //this tag is required for map loading, so return null if not supported
            }
        }

        //---, ---, H3R, ODST, HRB, HRR, ---
        public static sound_cache_file_gestalt ugh_(Base.CacheFile Cache, Base.CacheFile.IndexItem Tag)
        {
            switch (Cache.Version)
            {
                case CacheVersion.Halo3Retail:
                    return new Halo3Retail.sound_cache_file_gestalt(Cache, Tag.Offset);

                case CacheVersion.Halo3ODST:
                    return new Halo3ODST.sound_cache_file_gestalt(Cache, Tag.Offset);

                case CacheVersion.HaloReachBeta:
                    return new ReachBeta.sound_cache_file_gestalt(Cache, Tag.Offset);

                case CacheVersion.HaloReachRetail:
                    return new ReachRetail.sound_cache_file_gestalt(Cache, Tag.Offset);

                default:
                    return null; //this tag is required for map loading, so return null if not supported
            }
        }

        //H2X, H3B, H3R, ODST, HRB, HRR, H4R
        public static bitmap bitm(Base.CacheFile Cache, Base.CacheFile.IndexItem Tag)
        {
            switch (Cache.Version)
            {
                case CacheVersion.Halo1PC:
                    return new Halo1PC.bitmap(Cache, Tag.Offset);

                case CacheVersion.Halo1CE:
                    return new Halo1CE.bitmap(Cache, Tag.Offset);

                case CacheVersion.Halo2Xbox:
                    return new Halo2Xbox.bitmap(Cache, Tag.Offset);

                case CacheVersion.Halo3Beta:
                case CacheVersion.Halo3Retail:
                case CacheVersion.Halo3ODST:
                    return new Halo3Beta.bitmap(Cache, Tag.Offset);

                case CacheVersion.HaloReachBeta:
                    return new ReachBeta.bitmap(Cache, Tag.Offset);

                case CacheVersion.HaloReachRetail:
                case CacheVersion.Halo4Beta:
                case CacheVersion.Halo4Retail:
                    return new ReachRetail.bitmap(Cache, Tag.Offset);

                default:
                    throw new NotSupportedException(errorMessage.Replace("----", "bitm"));
            }
        }

        //H2X, H3B, H3R, ODST, HRB, HRR, H4R
        public static render_model mode(Base.CacheFile Cache, Base.CacheFile.IndexItem Tag)
        {
            switch (Cache.Version)
            {
                case CacheVersion.Halo1PC:
                case CacheVersion.Halo1CE:
                    return new Halo1PC.gbxmodel(Cache, Tag.Offset);

                case CacheVersion.Halo2Xbox:
                    return new Halo2Xbox.render_model(Cache, Tag.Offset);

                case CacheVersion.Halo3Beta:
                case CacheVersion.Halo3Retail:
                    return new Halo3Beta.render_model(Cache, Tag.Offset);

                case CacheVersion.Halo3ODST:
                    return new Halo3ODST.render_model(Cache, Tag.Offset);

                case CacheVersion.HaloReachBeta:
                    return new ReachBeta.render_model(Cache, Tag.Offset);

                case CacheVersion.HaloReachRetail:
                    return new ReachRetail.render_model(Cache, Tag.Offset);

                case CacheVersion.Halo4Beta:
                    return new Halo4Beta.render_model(Cache, Tag.Offset);

                case CacheVersion.Halo4Retail:
                    return new Halo4Retail.render_model(Cache, Tag.Offset);

                default:
                    throw new NotSupportedException(errorMessage.Replace("----", "mode"));
            }
        }

        //H2X, H3B, H3R, ODST, HRB, HRR, H4R
        public static scenario_structure_bsp sbsp(Base.CacheFile Cache, Base.CacheFile.IndexItem Tag)
        {
            switch (Cache.Version)
            {
                case CacheVersion.Halo1PC:
                case CacheVersion.Halo1CE:
                    return new Halo1PC.scenario_structure_bsp(Cache, Tag);

                case CacheVersion.Halo2Xbox:
                    return new Halo2Xbox.scenario_structure_bsp(Cache, Tag);

                case CacheVersion.Halo3Beta:
                    return new Halo3Beta.scenario_structure_bsp(Cache, Tag.Offset);

                case CacheVersion.Halo3Retail:
                    return new Halo3Retail.scenario_structure_bsp(Cache, Tag.Offset);

                case CacheVersion.Halo3ODST:
                    return new Halo3ODST.scenario_structure_bsp(Cache, Tag.Offset);

                case CacheVersion.HaloReachBeta:
                    return new ReachBeta.scenario_structure_bsp(Cache, Tag.Offset);

                case CacheVersion.HaloReachRetail:
                    return new ReachRetail.scenario_structure_bsp(Cache, Tag.Offset);

                case CacheVersion.Halo4Retail:
                    return new Halo4Retail.scenario_structure_bsp(Cache, Tag.Offset);

                default:
                    throw new NotSupportedException(errorMessage.Replace("----", "sbsp"));
            }
        }

        //---, H3B, H3R, ODST, HRB, HRR, ---
        public static render_method_template rmt2(Base.CacheFile Cache, Base.CacheFile.IndexItem Tag)
        {
            switch (Cache.Version)
            {
                case CacheVersion.Halo3Beta:
                case CacheVersion.Halo3Retail:
                case CacheVersion.Halo3ODST:
                case CacheVersion.HaloReachBeta:
                case CacheVersion.HaloReachRetail:
                    return new Halo3Beta.render_method_template(Cache, Tag.Offset);

                default:
                    throw new NotSupportedException(errorMessage.Replace("----", "rmt2"));
            }
        }

        //H2X, H3B, H3R, ODST, HRB, HRR, H4R
        public static shader rmsh(Base.CacheFile Cache, Base.CacheFile.IndexItem Tag)
        {
            switch (Cache.Version)
            {
                case CacheVersion.Halo1PC:
                case CacheVersion.Halo1CE:
                    return new Halo1PC.shader_model(Cache, Tag);

                case CacheVersion.Halo2Xbox:
                    return new Halo2Xbox.shader(Cache, Tag.Offset);

                case CacheVersion.Halo3Beta:
                case CacheVersion.Halo3Retail:
                case CacheVersion.Halo3ODST:
                    return new Halo3Beta.shader(Cache, Tag.Offset);

                case CacheVersion.HaloReachBeta:
                case CacheVersion.HaloReachRetail:
                    return new ReachBeta.shader(Cache, Tag.Offset);

                case CacheVersion.Halo4Beta:
                    return new Halo4Beta.material(Cache, Tag.Offset);

                case CacheVersion.Halo4Retail:
                    return new Halo4Retail.material(Cache, Tag.Offset);

                default:
                    throw new NotSupportedException(errorMessage.Replace("----", "mode"));
            }
        }

        //---, ---, H3R, ODST, HRB, HRR, H4R
        public static sound snd_(Base.CacheFile Cache, Base.CacheFile.IndexItem Tag)
        {
            switch (Cache.Version)
            {
                case CacheVersion.Halo3Retail:
                case CacheVersion.Halo3ODST:
                    return new Halo3Retail.sound(Cache, Tag.Offset);

                case CacheVersion.HaloReachBeta:
                case CacheVersion.HaloReachRetail:
                    return new ReachBeta.sound(Cache, Tag.Offset);

                case CacheVersion.Halo4Retail:
                    return new Halo4Retail.sound(Cache, Tag.Offset);

                default:
                    throw new NotSupportedException(errorMessage.Replace("----", "snd!"));
            }
        }

        //---, ---, ---, ----, ---, ---, H4R
        public static bink bink(Base.CacheFile Cache, Base.CacheFile.IndexItem Tag)
        {
            switch (Cache.Version)
            {
                case CacheVersion.Halo4Retail:
                    return new Halo4Retail.bink(Cache, Tag.Offset);

                default:
                    throw new NotSupportedException(errorMessage.Replace("----", "bink"));
            }
        }

        //---, H3B, H3R, ODST, HRB, HRR, H4R
        public static multilingual_unicode_string_list unic(Base.CacheFile Cache, Base.CacheFile.IndexItem Tag)
        {
            switch (Cache.Version)
            {
                case CacheVersion.Halo3Beta:
                case CacheVersion.Halo3Retail:
                case CacheVersion.Halo3ODST:
                    return new Halo3Beta.multilingual_unicode_string_list(Cache, Tag.Offset);

                case CacheVersion.HaloReachBeta:
                case CacheVersion.HaloReachRetail:
                case CacheVersion.Halo4Beta:
                case CacheVersion.Halo4Retail:
                    return new ReachBeta.multilingual_unicode_string_list(Cache, Tag.Offset);

                default:
                    throw new NotSupportedException(errorMessage.Replace("----", "unic"));
            }
        }
    }
}
