using BlamCore.Common;

namespace BlamCore.Geometry
{
    public class WorldVertex
    {
        public RealVector4d Position { get; set; }
        public RealVector2d Texcoord { get; set; }
        public RealVector3d Normal { get; set; }
        public RealVector4d Tangent { get; set; }
        public RealVector3d Binormal { get; set; }
    }

    public class RigidVertex
    {
        public RealVector4d Position { get; set; }
        public RealVector2d Texcoord { get; set; }
        public RealVector3d Normal { get; set; }
        public RealVector4d Tangent { get; set; }
        public RealVector3d Binormal { get; set; }
    }

    public class SkinnedVertex
    {
        public RealVector4d Position { get; set; }
        public RealVector2d Texcoord { get; set; }
        public RealVector3d Normal { get; set; }
        public RealVector4d Tangent { get; set; }
        public RealVector3d Binormal { get; set; }
        public byte[] BlendIndices { get; set; }
        public float[] BlendWeights { get; set; }
    }

    public class ParticleModelVertex
    {
        public RealVector3d Position { get; set; }
        public RealVector2d Texcoord { get; set; }
        public RealVector3d Normal { get; set; }
    }

    public class FlatWorldVertex
    {
        public RealVector4d Position { get; set; }
        public RealVector2d Texcoord { get; set; }
        public RealVector3d Normal { get; set; }
        public RealVector4d Tangent { get; set; }
        public RealVector3d Binormal { get; set; }
    }

    public class FlatRigidVertex
    {
        public RealVector4d Position { get; set; }
        public RealVector2d Texcoord { get; set; }
        public RealVector3d Normal { get; set; }
        public RealVector4d Tangent { get; set; }
        public RealVector3d Binormal { get; set; }
    }

    public class FlatSkinnedVertex
    {
        public RealVector4d Position { get; set; }
        public RealVector2d Texcoord { get; set; }
        public RealVector3d Normal { get; set; }
        public RealVector4d Tangent { get; set; }
        public RealVector3d Binormal { get; set; }
        public byte[] BlendIndices { get; set; }
        public float[] BlendWeights { get; set; }
    }

    public class ScreenVertex
    {
        public RealVector2d Position { get; set; }
        public RealVector2d Texcoord { get; set; }
        public uint Color { get; set; }
    }

    public class DebugVertex
    {
        public RealVector3d Position { get; set; }
        public uint Color { get; set; }
    }

    public class TransparentVertex
    {
        public RealVector3d Position { get; set; }
        public RealVector2d Texcoord { get; set; }
        public uint Color { get; set; }
    }

    public class ParticleVertex
    {
    }

    public class ContrailVertex
    {
        public RealVector4d Position { get; set; }
        public RealVector4d Position2 { get; set; }
        public RealVector4d Position3 { get; set; }
        public RealVector4d Texcoord { get; set; }
        public RealVector4d Texcoord2 { get; set; }
        public RealVector2d Texcoord3 { get; set; }
        public uint Color { get; set; }
        public uint Color2 { get; set; }
        public RealVector4d Position4 { get; set; }
    }

    public class LightVolumeVertex
    {
        public short[] Texcoord { get; set; }
    }

    public class ChudVertexSimple
    {
        public RealVector2d Position { get; set; }
        public RealVector2d Texcoord { get; set; }
    }

    public class ChudVertexFancy
    {
        public RealVector3d Position { get; set; }
        public uint Color { get; set; }
        public RealVector2d Texcoord { get; set; }
    }

    public class DecoratorVertex
    {
        public RealVector4d Position { get; set; }
        public RealVector2d Texcoord { get; set; }
        public RealVector4d Normal { get; set; }
        /*public short[] Texcoord2 { get; set; }
        public Vector4 Texcoord3 { get; set; }
        public Vector4 Texcoord4 { get; set; }*/
    }

    public class TinyPositionVertex
    {
        public RealVector4d Position { get; set; }
    }

    public class PatchyFogVertex
    {
        public RealVector4d Position { get; set; }
        public RealVector2d Texcoord { get; set; }
    }

    public class WaterVertex
    {
        public RealVector4d Position { get; set; }
        public RealVector4d Position2 { get; set; }
        public RealVector4d Position3 { get; set; }
        public RealVector4d Position4 { get; set; }
        public RealVector4d Position5 { get; set; }
        public RealVector4d Position6 { get; set; }
        public RealVector4d Position7 { get; set; }
        public RealVector4d Position8 { get; set; }
        public RealVector4d Texcoord { get; set; }
        public RealVector3d Texcoord2 { get; set; }
        public RealVector4d Normal { get; set; }
        public RealVector4d Normal2 { get; set; }
        public RealVector4d Normal3 { get; set; }
        public RealVector4d Normal4 { get; set; }
        public RealVector2d Normal5 { get; set; }
        public RealVector3d Texcoord3 { get; set; }
    }

    public class RippleVertex
    {
        public RealVector4d Position { get; set; }
        public RealVector4d Texcoord { get; set; }
        public RealVector4d Texcoord2 { get; set; }
        public RealVector4d Texcoord3 { get; set; }
        public RealVector4d Texcoord4 { get; set; }
        public RealVector4d Texcoord5 { get; set; }
        public RealVector4d Color { get; set; }
        public RealVector4d Color2 { get; set; }
        public short[] Texcoord6 { get; set; }
    }

    public class ImplicitVertex
    {
        public RealVector3d Position { get; set; }
        public RealVector2d Texcoord { get; set; }
    }

    public class BeamVertex
    {
        public RealVector4d Position { get; set; }
        public RealVector4d Texcoord { get; set; }
        public RealVector4d Texcoord2 { get; set; }
        public uint Color { get; set; }
        public RealVector3d Position2 { get; set; }
        public short[] Texcoord3 { get; set; }
    }

    public class DualQuatVertex
    {
        public RealVector4d Position { get; set; }
        public RealVector2d Texcoord { get; set; }
        public RealVector3d Normal { get; set; }
        public RealVector4d Tangent { get; set; }
        public RealVector3d Binormal { get; set; }
        public byte[] BlendIndices { get; set; }
        public float[] BlendWeights { get; set; }
    }

    public class StaticPerVertexColorData
    {
        public RealVector3d Color { get; set; }
    }

    public class StaticPerPixelData
    {
        public RealVector2d Texcoord { get; set; }
    }

    public class StaticPerVertexData
    {
        public RealVector4d Texcoord { get; set; }
        public RealVector4d Texcoord2 { get; set; }
        public RealVector4d Texcoord3 { get; set; }
        public RealVector4d Texcoord4 { get; set; }
        public RealVector4d Texcoord5 { get; set; }
    }

    public class AmbientPrtData
    {
        public float Brightness { get; set; }
    }

    public class LinearPrtData
    {
        public RealVector4d BlendWeight { get; set; }
    }

    public class QuadraticPrtData
    {
        public RealVector3d BlendWeight { get; set; }
        public RealVector3d BlendWeight2 { get; set; }
        public RealVector3d BlendWeight3 { get; set; }
    }
}
