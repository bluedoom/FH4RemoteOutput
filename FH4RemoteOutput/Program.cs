using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FH4RemoteOutput
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    struct ForzaUDP //324bytes
    {
        int _0x0;//0x1
        uint PackageCount;
        uint CarID; //f97f3b46  f9df2b46 f6fff945
        uint ConstBytes;//f8ff4744
        float GforceY,GforceX, GforceZ;
        float _7;
        float _8, _9;
        float speed;
        float _11, _12, _13;
        uint _14,_15,_16;
        float SFL, SFR, SBL, SBR;//Spring17-20
        float WFL, WFR, WBL, WBR;//WheelFraction21-24
        float WSFL, WSFR, WSBL, WSBR;//wheelSpeed 25-28
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        uint[] Unkown; //29-36
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        int[] HitAbout1;//36-40 bool?
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        float[] WheelAbout;//41-44
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        float[] WheelFraction;//?45-48
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        float[] Unkown2;//?49-52
        int CarID2, CarLevel, CarLevelPoint, _56;//D-X 1-6
        int ConstCar1, ConstCar2, HitAbout2, HitAbout3;//57-60
        float X, Y, Z, Speed;//61-64
        float Power, Torsion;//65-66
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        float[] TireTemp;//67-70
        int _71, _72, _73_0,_74_0,_75,_76;
        float PlayTime;//seconds,hungeNumber
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        ushort[] Control;//Accelerator breaker...



    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
