using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace FH4A
{
    
    public class DataConfig
    {
        public static int size = Marshal.SizeOf(typeof(ForzaUDP));
    }
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct Vector3
    {
        float X, Y, Z;
        float Right { get => X; set => X = value; }
        float Up { get => Y; set => Y = value; }
        float Forward { get => Z; set => Z = value; }
    }

    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct Tire
    {
        public float FrontRight, FrontLeft, RearLeft, RearRight;
    }
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct TireInt
    {
        public int FrontRight, FrontLeft, RearLeft, RearRight;
    }

    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct ForzaUDP //322bytes
    {
        public int IsRaceOn;//0x1
        public uint TimestampMS;
        public float EngineMaxRpm; //f97f3b46  f9df2b46 f6fff945
        public float EngineIdleRpm;//f8ff4744
        public float CurrentEngineRpm;
        public Vector3 Acceleration, Speed, AngularVelocity;
        public float Yaw, Pitch, Roll;
        public Tire Suspension;//17
        public Tire SlipRatio; //21-24  Tire normalized slip ratio, = 0 means 100% grip and |ratio| > 1.0 means loss of grip.
        public Tire RotationSpeed;//25-28 radians/sec
        public TireInt RumbleStrip;//29-32  1 when wheel is on rumble strip, = 0 when off
        public Tire PuddleDepth;//33-36 0-1
        public Tire SurfaceRumble;//37-40  controller force feedback
        public Tire SlipAngle;//41-44 Tire normalized slip angle, = 0 means 100% grip and |angle| > 1.0 means loss of grip.
        public Tire CombinedSlip;//45-48 Tire normalized combined slip, = 0 means 100% grip and |slip| > 1.0 means loss 
        public Tire SuspensionTravelMeters; //49-52 Actual suspension travel in meters
        public int CarID;
        public int CarClass; // 0-7 D C B A S S2 X
        public int CarPoint; // 100 - 999
        public int DrivetrainType; //Corresponds to EDrivetrainType; 0 = FWD, 1 = RWD, 2 = AWD
        public int Cylinders;//57 Number of cylinders in the engine
        public int _58,_69,_60;// 58 59 60
        public Vector3 position; //meters 61
        public float MeterSpeed;//64
        public float Power;// watts
        public float Torque; // N/m
        public Tire Temprature; //67-70
        public float Boost, Fuel, DistanceTraveled; //71 72 73
        public float BestLap, LastLap, CurrentLap, CurrentRaceTime;// 74-77
        public UInt16 LapNumber;//312
        public byte RacePosition;//314
                  // 315     316     317       318     319
        public byte Accel, Breake, Clutch, HandBrake, Gear;
        public sbyte Steer, NormalizedDrivingLine, NormalizedAIBrakeDifference;

        public ForzaUDP FromBytes(byte[] data)
        {
            IntPtr buffer = Marshal.AllocHGlobal(DataConfig.size);
            Marshal.Copy(data, 0, buffer, data.Length);
            return (ForzaUDP)Marshal.PtrToStructure(buffer, typeof(ForzaUDP));
        }

    }
}
