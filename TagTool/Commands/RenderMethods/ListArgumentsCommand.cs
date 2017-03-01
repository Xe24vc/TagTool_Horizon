using System;
using System.Collections.Generic;
using System.IO;
using BlamCore.Cache.HaloOnline;
using BlamCore.Common;
using BlamCore.Serialization;
using BlamCore.TagDefinitions;

namespace TagTool.Commands.RenderMethods
{
    class ListArgumentsCommand : Command
    {
        private GameCacheContext CacheContext { get; }
        private CachedTagInstance Tag { get; }
        private RenderMethod Definition { get; }

        public ListArgumentsCommand(GameCacheContext cacheContext, CachedTagInstance tag, RenderMethod definition)
            : base(CommandFlags.Inherit,

                 "ListArguments",
                 "Lists the arguments of the render_method.",

                 "ListArguments",

                 "Lists the arguments of the render_method.")
        {
            CacheContext = cacheContext;
            Tag = tag;
            Definition = definition;
        }

        public override bool Execute(List<string> args)
        {
            foreach (var property in Definition.ShaderProperties)
            {
                RenderMethodTemplate template = null;

                using (var cacheStream = CacheContext.TagCacheFile.Open(FileMode.Open, FileAccess.Read))
                {
                    var context = new TagSerializationContext(cacheStream, CacheContext, property.Template);
                    template = CacheContext.Deserializer.Deserialize<RenderMethodTemplate>(context);
                }

                for (var i = 0; i < template.Arguments.Count; i++)
                {
                    Console.WriteLine("");

                    var argumentName = CacheContext.GetString(template.Arguments[i].Name);
                    var argumentValue = new RealVector4d(
                        property.Arguments[i].Arg1,
                        property.Arguments[i].Arg2,
                        property.Arguments[i].Arg3,
                        property.Arguments[i].Arg4);

                    Console.Write(string.Format("{0}:", argumentName));

                    if (argumentName.EndsWith("_map"))
                    {
                        Console.Write(string.Format("{0} ", argumentValue.I));
                        Console.Write(string.Format("{0} ", argumentValue.J));
                        Console.Write(string.Format("{0} ", argumentValue.K));
                        Console.Write(string.Format("{0}", argumentValue.W));
                    }
                    else
                    {
                        Console.Write(string.Format("{0} ", argumentValue.I));
                        Console.Write(string.Format("{0} ", argumentValue.J));
                        Console.Write(string.Format("{0} ", argumentValue.K));
                        Console.Write(string.Format("{0}", argumentValue.W));
                    }
                }

                Console.WriteLine("");
                for (var i = 0; i < template.Arguments.Count; i++)
                {
                    var argumentName = CacheContext.GetString(template.Arguments[i].Name);
                    var argumentValue = new RealVector4d(
                        property.Arguments[i].Arg1,
                        property.Arguments[i].Arg2,
                        property.Arguments[i].Arg3,
                        property.Arguments[i].Arg4);

                    if (argumentName.EndsWith("_map"))
                    {
                        Console.WriteLine(string.Format("SetField Arguments.[{0:D2}].arg1 {1}", i, argumentValue.I));
                        Console.WriteLine(string.Format("SetField Arguments.[{0:D2}].arg2 {1}", i, argumentValue.J));
                        Console.WriteLine(string.Format("SetField Arguments.[{0:D2}].arg3 {1}", i, argumentValue.K));
                        Console.WriteLine(string.Format("SetField Arguments.[{0:D2}].arg4 {1}", i, argumentValue.W));
                    }
                    else
                    {
                        Console.WriteLine(string.Format("SetField Arguments.[{0:D2}].arg1 {1}", i, argumentValue.I));
                        Console.WriteLine(string.Format("SetField Arguments.[{0:D2}].arg2 {1}", i, argumentValue.J));
                        Console.WriteLine(string.Format("SetField Arguments.[{0:D2}].arg3 {1}", i, argumentValue.K));
                        Console.WriteLine(string.Format("SetField Arguments.[{0:D2}].arg4 {1}", i, argumentValue.W));
                    }
                }

            }

            return true;
        }
    }
}
