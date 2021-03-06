﻿using System;

namespace BlamCore.Common
{
    public struct RealQuaternion
    {
        public float I { get; set; }
        public float J { get; set; }
        public float K { get; set; }
        public float W { get; set; }

        public float LengthSquared =>
            (I * I) + (J * J) + (K * K) + (W * W);

        public float Length =>
            (float)Math.Sqrt(LengthSquared);
        
        public RealQuaternion(float i)
            : this(i, 0.0f, 0.0f, 0.0f)
        {
        }

        public RealQuaternion(float i, float j)
            : this(i, j, 0.0f, 0.0f)
        {
        }

        public RealQuaternion(float i, float j, float k)
            : this(i, j, k, 0.0f)
        {
        }
        public RealQuaternion(float i, float j, float k, float w)
        {
            I = i;
            J = j;
            K = k;
            W = w;
        }
        
        public static RealQuaternion operator *(RealQuaternion q, float scalar)
        {
            return new RealQuaternion(q.I * scalar, q.J * scalar, q.K * scalar, q.W * scalar);
        }

        public static RealQuaternion operator *(float scalar, RealQuaternion q)
        {
            return (q * scalar);
        }

        public static RealQuaternion FromDHenN3(uint DHenN3)
        {
            uint[] SignExtendX = { 0x00000000, 0xFFFFFC00 };
            uint[] SignExtendYZ = { 0x00000000, 0xFFFFF800 };
            uint temp;

            temp = DHenN3 & 0x3FF;
            var a = (float)(short)(temp | SignExtendX[temp >> 9]) / (float)0x1FF;

            temp = (DHenN3 >> 10) & 0x7FF;
            var b = (float)(short)(temp | SignExtendYZ[temp >> 10]) / (float)0x3FF;

            temp = (DHenN3 >> 21) & 0x7FF;
            var c = (float)(short)(temp | SignExtendYZ[temp >> 10]) / (float)0x3FF;
            
            return new RealQuaternion(a, b, c, 1.0f);
        }

        public static RealQuaternion FromUDHenN3(uint UDHenN3)
        {
            var a = (float)(UDHenN3 & 0x3FF) / (float)0x3FF;
            var b = (float)((UDHenN3 >> 10) & 0x7FF) / (float)0x7FF;
            var c = (float)((UDHenN3 >> 21) & 0x7FF) / (float)0x7FF;

            return new RealQuaternion(a, b, c, 1.0f);
        }
        
        public static RealQuaternion FromHenDN3(uint HenDN3)
        {
            uint[] SignExtendXY = { 0x00000000, 0xFFFFF800 };
            uint[] SignExtendZ = { 0x00000000, 0xFFFFFC00 };
            uint temp;

            temp = HenDN3 & 0x7FF;
            var a = (float)(short)(temp | SignExtendXY[temp >> 10]) / (float)0x3FF;

            temp = (HenDN3 >> 11) & 0x7FF;
            var b = (float)(short)(temp | SignExtendXY[temp >> 10]) / (float)0x3FF;

            temp = (HenDN3 >> 22) & 0x3FF;
            var c = (float)(short)(temp | SignExtendZ[temp >> 9]) / (float)0x1FF;
            
            return new RealQuaternion(a, b, c, 1.0f);
        }

        public static RealQuaternion FromUHenDN3(uint UHenDN3)
        {
            var a = (float)(UHenDN3 & 0x7FF) / (float)0x7FF;
            var b = (float)((UHenDN3 >> 11) & 0x7FF) / (float)0x7FF;
            var c = (float)((UHenDN3 >> 22) & 0x3FF) / (float)0x3FF;

            return new RealQuaternion(a, b, c, 1.0f);
        }
        
        public static RealQuaternion FromDecN4(uint DecN4)
        {
            uint[] SignExtend = { 0x00000000, 0xFFFFFC00 };
            uint[] SignExtendW = { 0x00000000, 0xFFFFFFFC };
            uint temp;

            temp = DecN4 & 0x3FF;
            var a = (float)(short)(temp | SignExtend[temp >> 9]) / 511.0f;

            temp = (DecN4 >> 10) & 0x3FF;
            var b = (float)(short)(temp | SignExtend[temp >> 9]) / 511.0f;

            temp = (DecN4 >> 20) & 0x3FF;
            var c = (float)(short)(temp | SignExtend[temp >> 9]) / 511.0f;

            temp = DecN4 >> 30;
            var d = (float)(short)(temp | SignExtendW[temp >> 1]);

            return new RealQuaternion(a, b, c, d);
        }

        public static RealQuaternion FromUDecN4(uint UDecN4)
        {
            var a = (float)(UDecN4 & 0x3FF) / (float)0x3FF;
            var b = (float)((UDecN4 >> 10) & 0x3FF) / (float)0x3FF;
            var c = (float)((UDecN4 >> 20) & 0x3FF) / (float)0x3FF;
            var d = (float)(UDecN4 >> 30) / (float)0x003;
            
            return new RealQuaternion(a, b, c, d);
        }

        public static RealQuaternion FromUByte4(uint UByte4)
        {
            var d = (float)(UByte4 & 0xFF);
            var c = (float)((UByte4 >> 8) & 0xFF);
            var b = (float)((UByte4 >> 16) & 0xFF);
            var a = (float)(UByte4 >> 24);

            return new RealQuaternion(a, b, c, d);
        }

        public static RealQuaternion FromUByteN4(uint UByteN4)
        {
            var d = (float)(UByteN4 & 0xFF) / (float)0xFF;
            var c = (float)((UByteN4 >> 8) & 0xFF) / (float)0xFF;
            var b = (float)((UByteN4 >> 16) & 0xFF) / (float)0xFF;
            var a = (float)(UByteN4 >> 24) / (float)0xFF;

            return new RealQuaternion(a, b, c, d);
        }

        public void Point3DTransform(RealMatrix4x3 Transform)
        {
            if (Transform.IsIdentity) return;

            float newX = (I * Transform.m11 + J * Transform.m21 + K * Transform.m31 + Transform.m41);
            float newY = (I * Transform.m12 + J * Transform.m22 + K * Transform.m32 + Transform.m42);
            float newZ = (I * Transform.m13 + J * Transform.m23 + K * Transform.m33 + Transform.m43);

            I = newX;
            J = newY;
            K = newZ;
        }

        public void Vector3DTransform(RealMatrix4x3 Transform)
        {
            if (Transform.IsIdentity) return;

            float newX = I * Transform.m11 + J * Transform.m21 + K * Transform.m31;
            float newY = I * Transform.m12 + J * Transform.m22 + K * Transform.m32;
            float newZ = I * Transform.m13 + J * Transform.m23 + K * Transform.m33;

            I = newX;
            J = newY;
            K = newZ;
        }
    }
}
