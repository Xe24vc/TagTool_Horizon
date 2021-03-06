﻿using System;
using System.IO;

namespace BlamCore.Geometry
{
    /// <summary>
    /// Reads and writes index buffer data.
    /// </summary>
    public class IndexBufferStream
    {
        private readonly Stream _stream;
        private readonly BinaryReader _reader;
        private readonly BinaryWriter _writer;
        private readonly IndexBufferFormat _format;
        private readonly long _baseOffset;
        private readonly uint _indexSize;

        /// <summary>
        /// Creates an index buffer stream.
        /// </summary>
        /// <param name="stream">The base stream to use. It must point to the beginning of the index buffer.</param>
        /// <param name="format">The format of each index in the buffer.</param>
        public IndexBufferStream(Stream stream, IndexBufferFormat format)
        {
            _stream = stream;
            _reader = new BinaryReader(_stream);
            _writer = new BinaryWriter(_stream);
            _format = format;
            _baseOffset = _stream.Position;
            _indexSize = (format == IndexBufferFormat.UInt16) ? 2U : 4U;
        }

        /// <summary>
        /// The position of the stream in units of indices.
        /// </summary>
        public uint Position
        {
            get { return (uint)(_stream.Position - _baseOffset) / _indexSize; }
            set { _stream.Position = _baseOffset + value * _indexSize; }
        }

        /// <summary>
        /// Reads an index and advances the stream.
        /// </summary>
        /// <returns>The index that was read.</returns>
        public uint ReadIndex()
        {
            return _format == IndexBufferFormat.UInt16 ? _reader.ReadUInt16() : _reader.ReadUInt32();
        }

        /// <summary>
        /// Writes an index and advances the stream.
        /// </summary>
        /// <param name="index">The index to write.</param>
        public void WriteIndex(uint index)
        {
            if (_format == IndexBufferFormat.UInt16)
                _writer.Write((ushort)index);
            else
                _writer.Write(index);
        }

        /// <summary>
        /// Reads indices into an array and advances the stream.
        /// </summary>
        /// <param name="buffer">The buffer to read into.</param>
        /// <param name="offset">The offset into the buffer to start storing at.</param>
        /// <param name="count">The number of indices to read.</param>
        public void ReadIndices(uint[] buffer, uint offset, uint count)
        {
            for (uint i = 0; i < count; i++)
                buffer[i + offset] = ReadIndex();
        }

        /// <summary>
        /// Reads an array of indices.
        /// </summary>
        /// <param name="count">The number of indices to read.</param>
        /// <returns>The indices that were read.</returns>
        public uint[] ReadIndices(uint count)
        {
            var result = new uint[count];
            ReadIndices(result, 0, count);
            return result;
        }

        /// <summary>
        /// Writes indices from an array and advances the stream.
        /// </summary>
        /// <param name="buffer">The buffer of indices to write.</param>
        /// <param name="offset">The offset into the buffer to start writing at.</param>
        /// <param name="count">The number of indices to write.</param>
        public void WriteIndices(uint[] buffer, uint offset, uint count)
        {
            for (uint i = 0; i < count; i++)
                WriteIndex(buffer[i + offset]);
        }

        /// <summary>
        /// Writes indices from an array and advances the stream.
        /// </summary>
        /// <param name="buffer">The indices to write.</param>
        public void WriteIndices(uint[] buffer)
        {
            WriteIndices(buffer, 0, (uint)buffer.LongLength);
        }

        /// <summary>
        /// Reads a triangle strip and converts it into a triangle list.
        /// Degenerate triangles will be included and must be discarded manually.
        /// </summary>
        /// <param name="indexCount">The number of indices in the strip. Cannot be 1 or 2.</param>
        /// <returns>The triangle strip converted into a triangle list.</returns>
        public uint[] ReadTriangleStrip(uint indexCount)
        {
            if (indexCount == 0)
                return new uint[0];
            if (indexCount < 3)
                throw new InvalidOperationException("Invalid triangle strip index buffer");

            var triangleCount = indexCount - 2;
            var result = new uint[triangleCount * 3];
            var previous = ReadIndices(2);
            for (var i = 0; i < triangleCount; i++)
            {
                var index = ReadIndex();

                // Swap the order of the first two indices every other triangle
                // in order to preserve the winding order
                if (i % 2 == 0)
                {
                    result[i * 3] = previous[0];
                    result[i * 3 + 1] = previous[1];
                }
                else
                {
                    result[i * 3] = previous[1];
                    result[i * 3 + 1] = previous[0];
                }

                result[i * 3 + 2] = index;
                previous[0] = previous[1];
                previous[1] = index;
            }
            return result;
        }
    }

    /// <summary>
    /// Index buffer formats.
    /// </summary>
    public enum IndexBufferFormat
    {
        /// <summary>
        /// Each index is an unsigned 16-bit integer.
        /// </summary>
        UInt16,

        /// <summary>
        /// Each index is an unsigned 32-bit integer.
        /// </summary>
        UInt32
    }
}
