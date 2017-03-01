using System.Collections.Generic;
using BlamCore.Cache;
using BlamCore.Cache.HaloOnline;
using BlamCore.Geometry;
using BlamCore.Serialization;

namespace BlamCore.TagResources
{
    /// <summary>
    /// Resource definition data for renderable geometry.
    /// </summary>
    [TagStructure(Name = "render_geometry_api_resource_definition", Size = 0x30)]
    public class RenderGeometryApiResourceDefinition
    {
        public int Unknown0;
        public int Unknown4;
        public int Unknown8;
        public int UnknownC;
        public int Unknown10;
        public int Unknown14;

        /// <summary>
        /// The vertex buffer definitions for the model data.
        /// </summary>
        public List<D3DPointer<VertexBufferDefinition>> VertexBuffers;

        /// <summary>
        /// The index buffer definitions for the model data.
        /// </summary>
        public List<D3DPointer<IndexBufferDefinition>> IndexBuffers;
    }

    /// <summary>
    /// Defines a vertex buffer in model data.
    /// </summary>
    [TagStructure(Size = 0x20)]
    public class VertexBufferDefinition
    {
        /// <summary>
        /// The number of vertices in the buffer.
        /// </summary>
        public int Count;

        /// <summary>
        /// The format of each vertex.
        /// </summary>
        public VertexBufferFormat Format;

        /// <summary>
        /// The size of each vertex in bytes.
        /// </summary>
        /// <remarks>
        /// This multiplied by <see cref="Count"/> should equal the total buffer size.
        /// </remarks>
        public short VertexSize;

        /// <summary>
        /// The reference to the the data for the vertex buffer.
        /// </summary>
        public ResourceDataReference Data;

        public int Unused1C;
    }

    /// <summary>
    /// Defines an index buffer in model data.
    /// </summary>
    [TagStructure(Size = 0x20)]
    public class IndexBufferDefinition
    {
        /// <summary>
        /// The primitive type to use for the index buffer.
        /// </summary>
        public PrimitiveType Type;

        /// <summary>
        /// The reference to the data for the index buffer.
        /// </summary>
        public ResourceDataReference Data;

        public int Unused18;
        public int Unused1C;
    }
}
