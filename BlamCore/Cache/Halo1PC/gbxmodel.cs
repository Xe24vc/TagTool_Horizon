﻿using System;
using System.Collections.Generic;



using mode = BlamCore.Cache.render_model;
using BlamCore.Common;
using BlamCore.IO;
using BlamCore.Geometry;

namespace BlamCore.Cache.Halo1PC
{
    public class gbxmodel : mode
    {
        public float uScale;
        public float vScale;

        public gbxmodel(Base.CacheFile Cache, int Address)
        {
            cache = Cache;
            EndianReader Reader = Cache.Reader;
            Reader.SeekTo(Address);

            Name = "gbxmodel";
            Flags = new Bitmask(Reader.ReadInt16());

            Reader.SeekTo(Address + 0x30);
            uScale = Reader.ReadSingle();
            vScale = Reader.ReadSingle();


            #region MarkerGroups Block
            Reader.SeekTo(Address + 0xAC);
            int iCount = Reader.ReadInt32();
            int iOffset = Reader.ReadInt32() - Cache.Magic;
            for (int i = 0; i < iCount; i++)
                MarkerGroups.Add(new MarkerGroup(Cache, iOffset + 64 * i));
            #endregion

            #region Nodes Block
            Reader.SeekTo(Address + 0xB8);
            iCount = Reader.ReadInt32();
            iOffset = Reader.ReadInt32() - Cache.Magic;
            for (int i = 0; i < iCount; i++)
                Nodes.Add(new Node(Cache, iOffset + 156 * i));
            #endregion

            #region Regions Block
            Reader.SeekTo(Address + 0xC4);
            iCount = Reader.ReadInt32();
            iOffset = Reader.ReadInt32() - Cache.Magic;
            for (int i = 0; i < iCount; i++)
                Regions.Add(new Region(Cache, iOffset + 76 * i));
            #endregion

            #region ModelParts Block
            Reader.SeekTo(Address + 0xD0);
            iCount = Reader.ReadInt32();
            iOffset = Reader.ReadInt32() - Cache.Magic;
            for (int i = 0; i < iCount; i++)
                ModelSections.Add(new ModelSection(Cache, iOffset + 48 * i) { FacesIndex = i, VertsIndex = i, NodeIndex = 255 });
            #endregion

            #region Shaders Block
            Reader.SeekTo(Address + 0xDC);
            iCount = Reader.ReadInt32();
            iOffset = Reader.ReadInt32() - Cache.Magic;
            for (int i = 0; i < iCount; i++)
                Shaders.Add(new Shader(Cache, iOffset + 32 * i));
            #endregion

            #region BoundingBox Block
            BoundingBoxes.Add(new BoundingBox());
            #endregion
        }

        public override void LoadRaw()
        {
            if (RawLoaded) return;

            var bb = BoundingBoxes[0];
            var IH = (Halo1PC.CacheFile.CacheIndexHeader)cache.IndexHeader;
            var reader = cache.Reader;

            for (int i = 0; i < ModelSections.Count; i++)
            {
                var section = ModelSections[i];
                
                List<int> tIndices = new List<int>();
                List<Vertex> tVertices = new List<Vertex>();

                for (int j = 0; j < section.Submeshes.Count; j++)
                {
                    var submesh = (Halo1PC.gbxmodel.ModelSection.Submesh)section.Submeshes[j];

                    #region Read Indices
                    submesh.FaceIndex = tIndices.Count;
                    var strip = new List<int>();

                    reader.SeekTo(submesh.FaceOffset + IH.vertDataOffset + IH.indexDataOffset);
                    for (int k = 0; k < submesh.FaceCount; k++)
                        strip.Add(reader.ReadUInt16() + tVertices.Count);

                    strip = MeshUtils.GetTriangleList(strip.ToArray(), 0, strip.Count, 5);
                    strip.Reverse();
                    submesh.FaceCount = strip.Count;
                    tIndices.AddRange(strip); 
                    #endregion

                    #region Read Vertices
                    reader.SeekTo(submesh.VertOffset + IH.vertDataOffset);
                    for (int k = 0; k < submesh.VertexCount; k++)
                    {
                        var v = new Vertex() { FormatName = "Halo1PC_Skinned" };
                        var position = new RealQuaternion(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
                        var normal = new RealQuaternion(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
                        var binormal = new RealQuaternion(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
                        var tangent = new RealQuaternion(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
                        var texcoord = new RealQuaternion(reader.ReadSingle() * uScale, 1f - reader.ReadSingle() * vScale);
                        var nodes = (Flags.Values[1]) ? 
                            new RealQuaternion(submesh.LocalNodes[reader.ReadInt16()], submesh.LocalNodes[reader.ReadInt16()], 0, 0) : 
                            new RealQuaternion(reader.ReadInt16(), reader.ReadInt16(), 0, 0);
                        var weights = new RealQuaternion(reader.ReadSingle(), reader.ReadSingle(), 0, 0);

                        v.Values.Add(new VertexValue(position, VertexValue.ValueType.Float32_3, "position", 0));
                        v.Values.Add(new VertexValue(normal, VertexValue.ValueType.Float32_3, "normal", 0));
                        v.Values.Add(new VertexValue(binormal, VertexValue.ValueType.Float32_3, "binormal", 0));
                        v.Values.Add(new VertexValue(tangent, VertexValue.ValueType.Float32_3, "tangent", 0));
                        v.Values.Add(new VertexValue(texcoord, VertexValue.ValueType.Float32_2, "texcoords", 0));
                        v.Values.Add(new VertexValue(nodes, VertexValue.ValueType.Int16_N2, "blendindices", 0));
                        v.Values.Add(new VertexValue(weights, VertexValue.ValueType.Float32_2, "blendweight", 0));

                        tVertices.Add(v);

                        bb.XBounds.Lower = Math.Min(bb.XBounds.Lower, position.I);
                        bb.XBounds.Upper = Math.Max(bb.XBounds.Upper, position.I);
                        bb.YBounds.Lower = Math.Min(bb.YBounds.Lower, position.J);
                        bb.YBounds.Upper = Math.Max(bb.YBounds.Upper, position.J);
                        bb.ZBounds.Lower = Math.Min(bb.ZBounds.Lower, position.K);
                        bb.ZBounds.Upper = Math.Max(bb.ZBounds.Upper, position.K);
                    } 
                    #endregion
                }

                section.Indices = tIndices.ToArray();
                section.Vertices = tVertices.ToArray();

                IndexInfoList.Add(new IndexBufferInfo() { FaceFormat = 3 });
                VertInfoList.Add(new VertexBufferInfo() { VertexCount = section.TotalVertexCount });
            }

            RawLoaded = true;
        }

        new public class Region : mode.Region
        {
            public Region(Base.CacheFile Cache, int Address)
            {
                EndianReader Reader = Cache.Reader;
                Reader.SeekTo(Address);

                Name = Reader.ReadNullTerminatedString(32);
                Reader.ReadInt16();
                Reader.ReadInt32();

                Reader.SeekTo(Address + 0x40);

                int iCount = Reader.ReadInt32();
                int iOffset = Reader.ReadInt32() - Cache.Magic;
                for (int i = 0; i < iCount; i++)
                    Permutations.Add(new Permutation(Cache, iOffset + 88 * i));
            }

            new public class Permutation : mode.Region.Permutation
            {
                public Permutation(Base.CacheFile Cache, int Address)
                {
                    EndianReader Reader = Cache.Reader;
                    Reader.SeekTo(Address);

                    Name = Reader.ReadNullTerminatedString(32);
                    Reader.ReadInt16();

                    Reader.SeekTo(Address + 0x40);
                    Reader.ReadInt16(); //super low
                    Reader.ReadInt16(); //low
                    Reader.ReadInt16(); //medium
                    Reader.ReadInt16(); //high
                    PieceIndex = Reader.ReadInt16(); //super high
                    PieceCount = 1;

                    //more markers here
                }
            }
        }

        new public class Node : mode.Node
        {
            public Node(Base.CacheFile Cache, int Address)
            {
                EndianReader Reader = Cache.Reader;
                Reader.SeekTo(Address);

                Name = Reader.ReadNullTerminatedString(32);
                NextSiblingIndex = Reader.ReadInt16();
                FirstChildIndex = Reader.ReadInt16();
                ParentIndex = Reader.ReadInt16();
                Reader.ReadInt16();
                Position = new RealQuaternion(
                    Reader.ReadSingle(), 
                    Reader.ReadSingle(),
                    Reader.ReadSingle());
                Rotation = new RealQuaternion(
                    -Reader.ReadSingle(),
                    -Reader.ReadSingle(),
                    -Reader.ReadSingle(),
                    Reader.ReadSingle());

                DistanceFromParent = Reader.ReadSingle();
            }
        }

        new public class MarkerGroup : mode.MarkerGroup
        {
            public MarkerGroup(Base.CacheFile Cache, int Address)
            {
                EndianReader Reader = Cache.Reader;
                Reader.SeekTo(Address);

                Name = Reader.ReadNullTerminatedString(32);
                Reader.ReadInt16();

                Reader.SeekTo(Address + 0x34);

                int iCount = Reader.ReadInt32();
                int iOffset = Reader.ReadInt32() - Cache.Magic;
                for (int i = 0; i < iCount; i++)
                    Markers.Add(new Marker(Cache, iOffset + 32 * i));
            }

            new public class Marker : mode.MarkerGroup.Marker
            {
                public Marker(Base.CacheFile Cache, int Address)
                {
                    EndianReader Reader = Cache.Reader;
                    Reader.SeekTo(Address);

                    RegionIndex = Reader.ReadByte();
                    PermutationIndex = Reader.ReadByte();
                    NodeIndex = Reader.ReadByte();
                    Reader.ReadByte();
                    Position = new RealQuaternion(
                        Reader.ReadSingle(),
                        Reader.ReadSingle(),
                        Reader.ReadSingle());
                    Rotation = new RealQuaternion(
                        -Reader.ReadSingle(),
                        -Reader.ReadSingle(),
                        -Reader.ReadSingle(),
                        Reader.ReadSingle());
                }
            }
        }

        new public class Shader : mode.Shader
        {
            public Shader(Base.CacheFile Cache, int Address)
            {
                EndianReader Reader = Cache.Reader;
                Reader.SeekTo(Address);

                Reader.Skip(12);

                tagID = Reader.ReadInt32();
            }
        }

        new public class ModelSection : mode.ModelSection
        {
            public ModelSection(Base.CacheFile Cache, int Address)
            {
                EndianReader Reader = Cache.Reader;
                Reader.SeekTo(Address);

                NodeIndex = 255;

                Reader.SeekTo(Address + 0x24);
                int iCount = Reader.ReadInt32();
                int iOffset = Reader.ReadInt32() - Cache.Magic;                   
                for (int i = 0; i < iCount; i++)
                    Submeshes.Add(new Submesh(Cache, iOffset + 132 * i));
            }

            new public class Submesh : mode.ModelSection.Submesh
            {
                public int FaceOffset;
                public int VertOffset;
                public List<byte> LocalNodes = new List<byte>();

                public Submesh(Base.CacheFile Cache, int Address)
                {
                    EndianReader Reader = Cache.Reader;
                    Reader.SeekTo(Address);

                    Reader.ReadInt32();
                    ShaderIndex = Reader.ReadInt16();

                    Reader.SeekTo(Address + 0x48);
                    FaceCount = Reader.ReadInt32() + 2;
                    FaceOffset = Reader.ReadInt32();

                    Reader.SeekTo(Address + 0x58);
                    VertexCount = Reader.ReadInt32();
                    Reader.ReadInt32();
                    Reader.ReadInt32();
                    VertOffset = Reader.ReadInt32();

                    Reader.Skip(3);
                    int iCount = Reader.ReadByte();
                    for (int i = 0; i < iCount; i++)
                        LocalNodes.Add(Reader.ReadByte());
                }
            }
        }

        new public class BoundingBox : mode.BoundingBox
        {
            public BoundingBox()
            {
                XBounds = YBounds = ZBounds = new Bounds<float>(float.PositiveInfinity, float.NegativeInfinity);
                UBounds = VBounds = new Bounds<float>(0, 1);
            }
        }
    }
}
