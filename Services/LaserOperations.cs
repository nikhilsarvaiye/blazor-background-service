namespace Services
{
    using System;
    using System.Collections.Generic;
    using System.IO.Ports;
    using System.Text;
    using System.Threading.Tasks;

    public class LaserOperations
    {
        public static SerialPort _serialPort;
        public static double cal_Pd_Ratio_3Yag;
        public static double calport_Pd_Ratio_3Y;
        public static double calport_Pd_Ratio_10Y;
        public static double calport_Pd_Ratio_50Y;
        public static double calport_Pd_Ratio_100Y;
        public static double calport_Pd_Ratio_300Y;
        public static double calport_Pm_Ratio_Y;
        public static double energyMin;
        public static double energyMinYAG;
        public static bool reCalibNum;
        public static bool commPortFlag;
        public static byte epromAccessFlag; // EepromAccessFlag
        public static string pulseWidthForLogging; // PULSE_WIDTH_FOR_LOGGING
        public const int IdleFlag = 0;
        public const int UIDateTimeSendFlag = 1;
        public static string FormMode;
        public string strMode = "Warm Up";
        // public static float EnergyScale;

        //private static int FailureCount = 0;
        //private static byte StoredCounter = 0;

        public static double TempBackup;

        private int WriteFrame0Data_FailureCount;
        private byte WriteFrame0Data_StoredCounter;

        private static byte Write4NVRam_offset;
        private static long Write4NVRam_adds;
        public static byte offset; public static long add;

        // RegistryConfiguration registryConfigurationObj = new RegistryConfiguration();




        //public LaserOperations()
        //{
        //    //try
        //    //{
        //        _serialPort = new SerialPort();
        //        _serialPort.PortName = SetPortName(_serialPort.PortName);
        //        _serialPort.BaudRate = _serialPort.BaudRate;
        //        _serialPort.Parity = _serialPort.Parity;
        //        _serialPort.DataBits = _serialPort.DataBits;
        //        _serialPort.StopBits = _serialPort.StopBits;
        //        _serialPort.Handshake = _serialPort.Handshake;
        //        _serialPort.ReadTimeout = 500;
        //        _serialPort.WriteTimeout = 500;
        //    //}
        //    //catch
        //    //{
        //    //    //Globals.IsLaserConnected = false;
        //    //}

        //}

        public const byte MaxBufferSize = 127;
        public const byte MaxInBufferSize = 255;
        public byte tempVar = 255;

        public const byte STX = 0x7E; //Start of packet
        public const byte DLE = 0x7D; //Escape character


        //[StructLayout(LayoutKind.Sequential)]
        //struct FrameStruct
        //{
        //    public byte FrameLength;
        //    [MarshalAs(UnmanagedType.ByValArray, SizeConst = MaxInBufferSize + 1)]
        //    public byte[] FrameItemValue;
        //};

        class FrameStruct
        {
            public byte FrameLength { get; set; }
            public byte[] FrameItemValue = new byte[256];
        }

        // private  List<FrameStruct> AllFrames = new List<FrameStruct>();
        List<FrameStruct>[] AllFrames = new List<FrameStruct>[256];
        FrameStruct frameStruct1 = new FrameStruct();
        // frameStruct1.FrameLength = FrameTempLength;

        public void PutPayloadToDataFrames(byte[] Buffer)
        {
            byte i = 0;
            byte j = 0;
            byte fraCt = 0;
            byte FrameID = 0;
            fraCt = GetPayloadFrames(Buffer);

            if (fraCt > 0)
            {
                for (i = 0; i < fraCt; i++)
                {
                    //FrameID = AllFrames[i].FrameItemValue[1];
                    AllFrames[i].ForEach(x =>
                    {
                        FrameID = x.FrameItemValue[1];
                    });
                    //Console.WriteLine(FrameID);
                    //TechMode_ConsoleAlex.Text2 = FrameID
                    switch (FrameID)
                    {
                        case 1:
                            //INSTANT C# NOTE: The ending condition of VB 'For' loops is tested only on entry to the loop. Instant C# has created a temporary variable in order to use the initial value of AllFrames[i].FrameLength for every iteration:
                            // byte tempVar = AllFrames[i].FrameLength;

                            //AllFrames[i].ForEach(x => {
                            //     tempVar = x.FrameLength;
                            //});
                            for (j = 0; j <= Frames.Frame1_length; j++)
                            {
                                //Frame1_Data[j] = AllFrames[i].FrameItemValue[j];
                                //Console.Write(j);
                                try
                                {
                                    AllFrames[i].ForEach(x =>
                                    {

                                        Frames.Frame1_Data[j] = x.FrameItemValue[j];


                                    });
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine($"[{DateTime.UtcNow.ToLocalTime()}] : {e.Message}");
                                    break;
                                }


                                //TechMode_ConsoleAlex.Text3(j) = Frame1(j)
                            }


                            break;
                        case 2:
                            //INSTANT C# NOTE: The ending condition of VB 'For' loops is tested only on entry to the loop. Instant C# has created a temporary variable in order to use the initial value of AllFrames[i].FrameLength for every iteration:
                            //byte tempVar2 = AllFrames[i].FrameLength;
                            //byte tempVar2 = 0;
                            //AllFrames[i].ForEach(x => {
                            //    tempVar = x.FrameLength;
                            //});
                            for (j = 0; j <= Frames.Frame2_length; j++)
                            {
                                //Console.Write(j);
                                //AllFrames[i].ForEach(x => {
                                //    try
                                //    {
                                //        Frames.Frame2_Data[j] = x.FrameItemValue[j];
                                //    }
                                //    catch { }

                                //});

                                try
                                {
                                    AllFrames[i].ForEach(x =>
                                    {

                                        Frames.Frame2_Data[j] = x.FrameItemValue[j];


                                    });
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine($"[{DateTime.UtcNow.ToLocalTime()}] : {e.Message}");
                                    break;
                                }

                                //Frame2_Data[j] = AllFrames[i].FrameItemValue[j];
                                //TechMode_ConsoleAlex.Text3(j + 64) = Frame2(j)
                            }

                            //Case 3
                            //For j = 0 To AllFrames[i].FrameLength
                            //Frame3(j) = AllFrames[i].FrameItemValue[j]
                            //TechMode_ConsoleAlex.Text3(j + 128) = Frame3(j)
                            //Next j
                            break;
                        case 4:
                            //INSTANT C# NOTE: The ending condition of VB 'For' loops is tested only on entry to the loop. Instant C# has created a temporary variable in order to use the initial value of AllFrames[i].FrameLength for every iteration:
                            //byte tempVar3 = AllFrames[i].FrameLength;
                            //byte tempVar3 = 0;
                            //AllFrames[i].ForEach(x => {
                            //    tempVar = x.FrameLength;
                            //});
                            //tempVar = 255;
                            for (j = 0; j <= Frames.Frame4_length; j++)
                            {
                                //Console.Write(j);
                                //AllFrames[i].ForEach(x => {
                                //    try
                                //    {
                                //        Frames.Frame4_Data[j] = x.FrameItemValue[j];
                                //    }
                                //    catch
                                //    {

                                //    }

                                //});

                                try
                                {
                                    AllFrames[i].ForEach(x =>
                                    {

                                        Frames.Frame4_Data[j] = x.FrameItemValue[j];


                                    });
                                }
                                catch (Exception e) { break; }

                                // Frame4_Data[j] = AllFrames[i].FrameItemValue[j];
                                //TechMode_ConsoleAlex.Text3(j + 128) = Frame4(j)
                            }
                            break;
                        case 5:
                            //INSTANT C# NOTE: The ending condition of VB 'For' loops is tested only on entry to the loop. Instant C# has created a temporary variable in order to use the initial value of AllFrames[i].FrameLength for every iteration:
                            // byte tempVar4 = AllFrames[i].FrameLength;
                            //byte tempVar = 0;
                            //AllFrames[i].ForEach(x => {
                            //    tempVar = x.FrameLength;
                            //});
                            for (j = 0; j <= Frames.Frame5_length; j++)
                            {
                                //Console.Write(j);
                                //AllFrames[i].ForEach(x => {
                                //    try
                                //    {
                                //        Frames.Frame5_Data[j] = x.FrameItemValue[j];
                                //    }
                                //    catch { }

                                //});

                                try
                                {
                                    AllFrames[i].ForEach(x =>
                                    {

                                        Frames.Frame5_Data[j] = x.FrameItemValue[j];


                                    });
                                }
                                catch (Exception e) { break; }

                                // Frame5_Data[j] = AllFrames[i].FrameItemValue[j];
                                //TechMode_ConsoleAlex.Text3(j + 192) = Frame5(j)
                            }
                            break;
                        case 7:
                            //INSTANT C# NOTE: The ending condition of VB 'For' loops is tested only on entry to the loop. Instant C# has created a temporary variable in order to use the initial value of AllFrames[i].FrameLength for every iteration:

                            // byte tempVar5 = AllFrames[i].FrameLength;
                            //byte tempVar5 = 0;
                            //AllFrames[i].ForEach(x => {
                            //    tempVar = x.FrameLength;
                            //});
                            for (j = 0; j <= Frames.Frame7_length; j++)
                            {
                                //Console.Write(j);
                                //AllFrames[i].ForEach(x => {
                                //    try
                                //    {
                                //        Frames.Frame7_Data[j] = x.FrameItemValue[j];
                                //    }
                                //    catch { }

                                //});
                                try
                                {
                                    AllFrames[i].ForEach(x =>
                                    {

                                        Frames.Frame7_Data[j] = x.FrameItemValue[j];


                                    });
                                }
                                catch (Exception e)
                                { break; }
                                // Frame7_Data[j] = AllFrames[i].FrameItemValue[j];
                            }
                            break;
                    }
                }
            }


        }

        public byte GetPayloadFrames(byte[] Buffer)
        {

            byte i = 0;
            //Dim Y As Byte
            byte fraCt = GetStuffedFrames(Buffer);
            if (fraCt > 0)
            {
                for (i = 0; i < fraCt; i++)
                {
                    byte[] frameValue = new byte[256];
                    byte frameLength = 0;
                    AllFrames[i].ForEach(x =>
                    {
                        frameValue = x.FrameItemValue;
                        frameLength = x.FrameLength;
                    });
                    Unstuff(frameValue, frameLength);
                }
            }
            return fraCt;
        }

        public byte GetStuffedFrames(byte[] Buffer)
        {
            int i = 0;
            int j = 0;
            int k = 0;
            int length = 0;
            byte FrameCt = 0;
            byte[] FrameBuffer = new byte[214748359];
            byte FrameTempLength = 0;
            byte StartOfFrameCt = 0;
            //byte defaultByte = 0;
            length = Buffer.GetUpperBound(0);

            for (i = 0; i <= length; i++) //Find how many frames in the StuffedReceiveBuffer
            {
                if (Buffer[i] == 0x7E)
                {
                    FrameCt = (byte)(FrameCt + 1);
                }
            }
            if (FrameCt > 0) //We have these much frames if StartOf FrameCt>0
            {
                //INSTANT C# TODO TASK: The following 'ReDim' could not be resolved. A possible reason may be that the object of the ReDim was not declared as an array:
                //AllFrames = new FrameStruct[FrameCt - 1];

                //List<FrameStruct> AllFrames = new List<FrameStruct>(FrameCt-1);
                // List<FrameStruct>[] AllFrames = new List<FrameStruct>[256];
                frameStruct1.FrameLength = FrameTempLength;
                for (int m = 0; m < 256; m++)
                {
                    //if (m != FrameCt - 1) { 
                    AllFrames[m] = new List<FrameStruct>();
                    //}
                }

                //AllFrames[FrameCt - 1] = new List<FrameStruct>();

                for (i = 0; i <= length; i++)
                {
                    if (Buffer[i] == 0x7E && StartOfFrameCt == 0)
                    {
                        FrameTempLength = 0;
                        //FrameTempLength = FrameTempLength + 1
                        FrameBuffer[k] = Buffer[i]; //need do implement
                        StartOfFrameCt = (byte)(StartOfFrameCt + 1);
                        k = k + 1;

                    }
                    else if (Buffer[i] != 0x7E && StartOfFrameCt > 0 && StartOfFrameCt < FrameCt)
                    {
                        FrameTempLength = (byte)(FrameTempLength + 1);
                        FrameBuffer[k] = Buffer[i];
                        k = k + 1;

                    }
                    else if (Buffer[i] == 0x7E && StartOfFrameCt > 0 && StartOfFrameCt < FrameCt)
                    {

                        //FrameStruct frameStruct1 = new FrameStruct();
                        //frameStruct1.FrameLength = FrameTempLength;
                        for (j = 0; j <= FrameTempLength; j++)
                        {

                            frameStruct1.FrameItemValue[j] = FrameBuffer[j];

                            AllFrames[j].Add(frameStruct1);
                            // AllFrames[StartOfFrameCt - 1].FrameItemValue[j] = FrameBuffer[j];
                        }
                        // AllFrames[StartOfFrameCt - 1].FrameLength = FrameTempLength;
                        FrameTempLength = 0;
                        //FrameTempLength = FrameTempLength + 1
                        k = 0;
                        FrameBuffer[k] = Buffer[i]; //need do implement
                        StartOfFrameCt = (byte)(StartOfFrameCt + 1);
                        k = k + 1;



                    }
                    else if (Buffer[i] != 0x7E && StartOfFrameCt == FrameCt)
                    {
                        FrameTempLength = (byte)(FrameTempLength + 1);
                        FrameBuffer[k] = Buffer[i];
                        k = k + 1;

                    }

                }
                //FrameStruct frameStruct = new FrameStruct();
                //frameStruct.FrameLength = FrameTempLength;
                for (j = 0; j <= FrameTempLength; j++)
                {
                    frameStruct1.FrameItemValue[j] = FrameBuffer[j];

                    AllFrames[j].Add(frameStruct1);
                }
                //AllFrames[StartOfFrameCt - 1].FrameLength = FrameTempLength;
                //frameStruct1.FrameLength = FrameTempLength;

            }

            return FrameCt;

        }

        public void Unstuff(byte[] DataBuffer, byte length)
        {
            byte[] localBuffer = new byte[MaxInBufferSize + 1];
            byte i = 0;
            byte j = 0;
            byte d = 0;
            for (i = 0; i <= length; i++)
            {
                d = DataBuffer[i];
                if (d == DLE)
                {
                    i = (byte)(i + 1);
                    localBuffer[j] = (byte)(DataBuffer[i] ^ 0x20);
                }
                else
                {
                    localBuffer[j] = DataBuffer[i];
                }
                j = (byte)(j + 1);
            }
            for (i = 0; i <= length; i++)
            {
                DataBuffer[i] = 0;
            }
            length = (byte)(j - 1);
            for (i = 0; i <= length; i++)
            {
                DataBuffer[i] = localBuffer[i];
            }

        }

        public void BuildOutMessage(byte[] FrameBuff, byte SendBufferLength)
        {
            byte i = 0;
            byte j = 0;
            for (i = 0; i <= SendBufferLength; i++)
            {
                Frames.SendBuffer[i] = FrameBuff[i];
            }

            AddCRC(Frames.SendBuffer, SendBufferLength);
            j = Stuffit(Frames.SendBuffer, SendBufferLength); //get output message bytes count

            Frames.OutMessage = new byte[j + 1];
            for (i = 0; i <= j; i++)
            {
                Frames.OutMessage[i] = Frames.StuffedSendBuffer[i];
            }

        }
        public byte Stuffit(byte[] SendBuf, byte length)
        {
            int i = 0;
            int j = 0;
            int d = 0;
            Frames.StuffedSendBuffer[0] = STX;
            j = 1;
            for (i = 1; i <= length; i++)
            {
                d = SendBuf[i];
                if (d == STX || d == DLE) //Value need to be stuffed
                {
                    Frames.StuffedSendBuffer[j] = DLE; //Insert a escape character
                    j++; // j = j + 1;
                    Frames.StuffedSendBuffer[j] = (byte)(d ^ 0x20); //Insert byte xor with &h20
                    j++; // j = j + 1;
                }
                else
                {
                    Frames.StuffedSendBuffer[j] = (byte)d;
                    j++; // j = j + 1;
                }
            }
            return (byte)(j - 1);
        }

        public void AddCRC(byte[] PayloadData, byte length)
        {
            long crc = 0;
            string CRCHex = null;
            int lengthCRCHex = 0;
            //Dim strLB As String
            string strHB = null;
            byte LB = 0; //CRC lb
            byte HB = 0; //CRC hb
            crc = CalcCrc16(PayloadData, (byte)(length - 2));

            CRCHex = Convert.ToString(crc, 16).ToUpper();
            LB = (byte)(crc & 0xFF);

            lengthCRCHex = CRCHex.Length; //length if HB string
            if (lengthCRCHex > 2)
            {
                strHB = CRCHex.Substring(0, lengthCRCHex - 2);
                try
                {
                    HB = byte.Parse("0x" + strHB);
                }
                catch { }
            }
            else
            {
                HB = 0;
            }
            PayloadData[length - 1] = HB;
            PayloadData[length] = LB;
        }

        public long CalcCrc16(byte[] buf, byte length)
        {
            long crc = 0;
            int t = 0;
            crc = 0xFFFF;
            for (t = 0; t <= length; t++)
            {
                crc = CRC16(crc, buf[t]);
            }
            return crc;
        }

        private long CRC16(long crc, byte d)
        {
            long carry = 0;
            long i = 1;
            do
            {
                carry = (crc & 1) ^ (((d & i) != 0) ? 1 : 0);
                crc = ((crc & 0xFFFFL) / 2);
                if (carry != 0)
                {
                    crc = crc ^ 0x8408;
                }
                i = i * 2;
            } while (!(i == 256));
            return crc;
        }

        public static void Post_Data(byte address, byte Data)
        {
            Frames.Frame0_Data[address] = Data;
        }

        /// <summary>
        /// To call Read() use :
        /// Thread readThread = new Thread(Read);
        /// readThread.Start();
        /// readThread.Join();
        /// </summary>
        public void Read()
        {
            //_serialPort = new SerialPort();
            //_serialPort.PortName = SetPortName();
            //_serialPort.Open();
            try
            {
                //if (!_serialPort.IsOpen)
                //{
                //    _serialPort.Open();
                //}

                byte[] message = Encoding.ASCII.GetBytes(_serialPort.ReadLine());
                //if (_serialPort.IsOpen)
                //{
                //    _serialPort.Close();
                //}

                PutPayloadToDataFrames(message);
                //Globals.PrimaryCause = Frames.Frame1_Data[43];
                // if (Globals.PrimaryCause != 0 && Globals.IsShowInterLock)
                // {
                //     ShowInterlockScreen(Globals.PrimaryCause, strMode);
                //     //Globals.UserInterlockFlag = true;
                //     //Globals.ShowInterlock = true;
                // }
            }
            catch (Exception e)
            {
                Console.WriteLine($"[{DateTime.UtcNow.ToLocalTime()}] : {e.Message}");
                Globals.IsLaserConnected = false;
                Console.WriteLine("From read method");
                if (_serialPort.IsOpen == false)
                {
                    _serialPort.Open();
                }
            }
            //_serialPort.Close();
            //Thread.Sleep(10);
        }



        public void WriteFrame0Data()
        {
            //_serialPort = new SerialPort();
            //_serialPort.PortName = SetPortName();
            //_serialPort.Open();

            //if (registryConfigurationObj.GetSetting("EnergyMonitor") == "OFF")
            //{
            //    this.OverrideEnergyMonitering();
            //}
            if (Frames.Frame0_Data[5] != (byte)STATE_COMMAND.STATE_COMMAND_READY && Globals.ReadyModeTimeout > 0)
            {
                Globals.ReadyModeTimeout = 0;
            }
            if (Frames.Frame0_Data[3] < 255)
            {
                Frames.Frame0_Data[3]++;
            }
            else
            {
                Frames.Frame0_Data[3] = 0;
            }

            if (Frames.Frame1_Data[3] != WriteFrame0Data_FailureCount)
            {
                WriteFrame0Data_StoredCounter = Frames.Frame1_Data[3];
                WriteFrame0Data_FailureCount = 0;
            }
            else
            {
                WriteFrame0Data_FailureCount = WriteFrame0Data_FailureCount + 1;
                if (WriteFrame0Data_FailureCount > 30)
                {
                    WriteFrame0Data_FailureCount = 0;
                    //_serialPort.Close(); // TODO: need to work on this logic.
                    return; // TODO: Add 3 lines from frmMain.TimerSendOutput_Timer()
                }
            }
            BuildOutMessage(Frames.Frame0_Data, Frames.Frame0_length);
            try
            {
                //if(!_serialPort.IsOpen)
                //{
                //    _serialPort.Open();
                //}

                _serialPort.Write(Frames.OutMessage, 0, Frames.OutMessage.Length);
                //if (_serialPort.IsOpen)
                //{
                //    _serialPort.Close();
                //}
            }
            catch (Exception e)
            {
                Console.WriteLine($"[{DateTime.UtcNow.ToLocalTime()}] : {e.Message}");
                Globals.IsLaserConnected = false;
                Console.WriteLine("From write method");

                if (_serialPort.IsOpen == false)
                {
                    _serialPort.Open();
                }
            }
            //_serialPort.Close();
            //Thread.Sleep(50); /// 
            //Thread.Sleep(10);
        }

        private void OverrideEnergyMonitering()
        {
            try
            {
                byte interlockStatus = 0;
                interlockStatus = Frames.Frame0_Data[24];
                interlockStatus = (byte)(interlockStatus | (byte)(Math.Pow(2, (INTERLOCK.INTERLOCK_ENERGY_MONITORING - INTERLOCK.INTERLOCK_CALIBRATION_PORT_HANDPIECE_SENSE))));
                Frames.Frame0_Data[24] = interlockStatus;
            }
            catch { }
        }

        public static string SetPortName()
        {
            string portName = "";
            try
            {
                foreach (string s in SerialPort.GetPortNames())
                {
                    portName = s;
                }
            }
            catch
            {
                portName = "";
            }
            return portName;
        }

        public bool CheckComPortStatus()
        {
            string portName;
            try
            {
                foreach (string s in SerialPort.GetPortNames())
                {
                    portName = s;
                }
                if (!_serialPort.IsOpen)
                {
                    _serialPort.Open();
                }
                if (_serialPort.IsOpen)
                {
                    _serialPort.Close();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void SetPulseRate(float PulseRate)
        {
            int RealRate = 0;
            byte lsb_Reprate = 0;
            byte msb_Reprate = 0;

            RealRate = Int32.Parse(Math.Round(1000 / PulseRate).ToString()); //reprate 1000 as 1hz
            //msb_Reprate = Convert.ToByte(Math.Floor(RealRate / 256.0)); // was 0
            msb_Reprate = (byte)(RealRate / 256);                         // HotFix: Exception - Value either too small or too large. 
            lsb_Reprate = (byte)(RealRate - (256 * msb_Reprate)); // was 100
            Post_Data(12, lsb_Reprate);
            Post_Data(13, msb_Reprate);

        }
        public static void SetPFNvoltage(int voltage)
        {
            byte HiByte = 0;
            byte LoByte = 0;

            HiByte = (byte)(voltage / 256); // was 3
            LoByte = (byte)(voltage - (HiByte * 256)); // was 232

            Post_Data(6, LoByte);
            Post_Data(7, HiByte);
        }

        public static void SendPulseWidth(int PulseWidth)
        {
            byte delay1 = 0;
            byte delay2 = 0;
            byte delay3 = 0;
            byte Remainder = 0;
            pulseWidthForLogging = PulseWidth.ToString();
            switch (PulseWidth)
            {
                case 1: //S mode
                    Post_Data(17, 80); //inhibit
                    Post_Data(18, 1); //trigger 1 enable

                    break;
                case 0: //3ms
                    Post_Data(17, 100); //inhibit
                    Post_Data(14, 0); //delay 1 set to 0
                    Post_Data(15, 4); //delay 2 set to 3
                    Post_Data(16, 0); //delay 3 set to 0
                    Post_Data(18, 15); //all 4 triggers enable
                    break;
                default: //regular pulsewidth>=10
                    Remainder = (byte)(PulseWidth % 3); // was 1
                    delay3 = (byte)(PulseWidth / 3); // was 3
                    Console.WriteLine($"PulseWidth({PulseWidth}) : " + delay3);
                    if (Remainder == 0)
                    {
                        delay1 = delay3;
                        delay2 = delay3;
                    }
                    else if (Remainder == 1)
                    {
                        delay1 = (byte)(delay3 + 1); // was 4
                        delay2 = delay3; // was 3
                    }
                    else //if remainder is 2
                    {
                        delay1 = (byte)(delay3 + 1);
                        delay2 = (byte)(delay3 + 1);
                    }

                    Post_Data(17, 100); //inhibit
                    Post_Data(14, delay1); //delay 1 set to 0
                    Post_Data(15, delay2); //delay 2 set to 3
                    Post_Data(16, delay3); //delay 3 set to 0
                    Post_Data(18, 15); //all 4 triggers enable

                    Console.WriteLine($"Pulse Width set to {PulseWidth}");
                    break;
            }
        }

        public static void SendEnergyMax(double EnergySet, double PdRatio)
        {
            //int PdLoByte = 0;
            //int PdHiByte = 0;
            //Console.WriteLine("Line 1");
            //Console.WriteLine($"(EnergySet * 1.35) / (EnergyScale * PdRatio) : {(EnergySet * 1.35) / (CommonFunctions.EnergyScale * PdRatio)}");
            //double EnergyMax = Math.Floor((EnergySet * 1.35) / (CommonFunctions.EnergyScale * PdRatio));
            //Console.WriteLine("Line 2");
            //Console.WriteLine($"EnergyMax / 256 : {EnergyMax / 256}");
            //PdHiByte = (byte)(EnergyMax / 256);
            //Console.WriteLine("Line 3");
            //Console.WriteLine($"(EnergyMax - (PdHiByte * 256)) : {(EnergyMax - (PdHiByte * 256))}");
            //PdLoByte = (byte)(EnergyMax - (PdHiByte * 256));
            //Console.WriteLine($"PdLoByte : {PdLoByte}");
            //Post_Data(30, (byte)PdLoByte);
            //Console.WriteLine($"PdHiByte {PdHiByte}");
            //Post_Data(31, (byte)PdHiByte);
        }

        public static double GetTempValue()
        {
            long tempDigit = 0;
            double C_temp = 0;
            //tempDigit = Frame4_Data(24) + 256 * Frame4_Data(25)
            tempDigit = Frames.Frame4_Data[27] + 256 * Frames.Frame4_Data[28];
            C_temp = Math.Round(0.03174 * tempDigit, 1); //display temp in centi degree
            if (!(C_temp > 41))
            {
                Globals.TempCT = String.Format("{0:0.0}", C_temp.ToString());
            }
            if (C_temp <= 5)
            {
                Globals.TempCT = TempBackup.ToString();
            }
            if (C_temp >= 41)
            {
                if (C_temp < 50)
                {
                    Globals.TempCT = 40.ToString();
                }
            }
            TempBackup = Convert.ToDouble(Globals.TempCT);
            return TempBackup;
        }

        public static async Task WriteNVRam(byte AddressLow, byte AddressHigh, byte Data)
        {
            int flag = 1;
            Frames.Frame0_Data[32] = AddressLow; //low address
            Frames.Frame0_Data[33] = AddressHigh; //high address
            Frames.Frame0_Data[34] = Data; //data to be written
            Frames.Frame0_Data[(34 + 1)] = 0;
            Frames.Frame0_Data[(34 + 2)] = 0;
            Frames.Frame0_Data[(34 + 3)] = 0;
            Frames.Frame0_Data[38] = (byte)flag;

            do
            {
                //await Task.Yield();
                await Task.Delay(1);
            } while (!(Frames.Frame4_Data[14] == 2)); //data ready for host

            flag = 0; //go back to idle
            Frames.Frame0_Data[38] = (byte)flag;
            do
            {
                //await Task.Yield();
                await Task.Delay(1);
            } while (!(Frames.Frame4_Data[14] == 0));

        }

        public static void WriteNVRamMod(byte AddressLow, byte AddressHigh, byte Data)
        {
            int flag = 1;
            Frames.Frame0_Data[32] = AddressLow; //low address
            Frames.Frame0_Data[33] = AddressHigh; //high address
            Frames.Frame0_Data[34] = Data; //data to be written
            Frames.Frame0_Data[(34 + 1)] = 0;
            Frames.Frame0_Data[(34 + 2)] = 0;
            Frames.Frame0_Data[(34 + 3)] = 0;
            Frames.Frame0_Data[38] = (byte)flag;

            do
            {
                //await Task.Yield();
                Console.Write("");
            } while (!(Frames.Frame4_Data[14] == 2)); //data ready for host

            flag = 0; //go back to idle
            Frames.Frame0_Data[38] = (byte)flag;
            do
            {
                //await Task.Yield();
                Console.Write("");
            } while (!(Frames.Frame4_Data[14] == 0));

        }

        public static async Task SendDateTime(DateTime SendDate, long MinutesInDay, byte AddressLow, byte AddressHigh)
        {
            byte i = 0;
            byte[] SendDateData = new byte[4];
            byte FirstByteDate = 0;
            byte SecondByteDate = 0;
            byte ThirdByteDate = 0;
            byte ForthByteDate = 0;
            byte MonthData = 0;
            byte DayData = 0;
            long MinuteData = 0;

            MonthData = (byte)SendDate.Month; //month
            DayData = (byte)SendDate.Day; //days of Month
            MinuteData = MinutesInDay; //minutes in Day

            FirstByteDate = (byte)(MinuteData & 0xFF); //LSB 8 bit of 12 bit Minute in Day
            SecondByteDate = Convert.ToByte((DayData & 0xF) * 16 + Math.Floor(MinuteData / 256.0)); //4 bit LSB of Day(as 4 bit MSB) and 4 bit MSB of 12 bit minute in day (as 4 bit LSB)
            ThirdByteDate = Convert.ToByte((MonthData * 16) + Math.Floor(DayData / 16.0)); // High 4 bits is month and low 4 bits is first 4bits of daydata
            ForthByteDate = (byte)(SendDate.Year - 2000); //8 bits for year, the set year-2000(years)

            SendDateData[0] = FirstByteDate;
            SendDateData[1] = SecondByteDate;
            SendDateData[2] = ThirdByteDate;
            SendDateData[3] = ForthByteDate;


            for (i = 0; i <= 3; i++)
            {
                //Call WriteNVRam(AddressLow, AddressHigh, SendDateData(i)) 'write  date/Time to NVRam (4 bytes)
                Write4NVRam(AddressLow, AddressHigh, SendDateData[i]); //write date/Time to NVRam (4 bytes)
                AddressLow = (byte)(AddressLow + 1);
            }

        }



        public static void Write4NVRam(byte AddressLow, byte AddressHigh, byte Data)
        {
            int flag = 0;
            long IOadd = 0;
            long cadds = 0;
            long AddH = 0;
            long AddL = 0;
            long fraH = 0;
            long fraL = 0;
            AddH = AddressHigh;
            AddL = AddressLow;
            flag = 4; //flag (0=Idle, 1=Write request, 2=Read request, 3=Acknowledged)

            cadds = (256 * AddH) + AddL;

            if (cadds < Write4NVRam_adds)
            {
                Write4NVRam_offset = 0;
                Write4NVRam_adds = 0;
            }
            if (4 + Write4NVRam_adds < cadds)
            {
                Write4NVRam_offset = 0;
                Write4NVRam_adds = 0;
            }
            //MsgBox add & " " & cadd & " " & offset

            if (Write4NVRam_offset == 0 && Write4NVRam_adds == 0) //Frame4_Data(14) = 0 Then
            {
                Write4NVRam_adds = cadds;
                //cadd = IOadd
                //offset = 1
            }
            //Frame0_Data(38) = flag
            switch (Write4NVRam_offset)
            {
                case 0:
                    //MsgBox "ADD" & add
                    Frames.Frame0_Data[32] = AddressLow; //low address
                    Frames.Frame0_Data[33] = AddressHigh; //high address
                    Frames.Frame0_Data[(34 + Write4NVRam_offset)] = Data;
                    Frames.Frame0_Data[(34 + 1)] = 0;
                    Frames.Frame0_Data[(34 + 2)] = 0;
                    Frames.Frame0_Data[(34 + 3)] = 0;
                    //Read request
                    //MsgBox cadd
                    break;
                case 1:
                    Frames.Frame0_Data[(34 + Write4NVRam_offset)] = Data;
                    break;
                case 2:
                    //MsgBox "OFF" & offset
                    Frames.Frame0_Data[(34 + Write4NVRam_offset)] = Data;
                    break;
                case 3:
                    //MsgBox "OFF to idle" & offset
                    Frames.Frame0_Data[(34 + Write4NVRam_offset)] = Data;
                    Frames.Frame0_Data[38] = (byte)flag;
                    do
                    {
                        //await Task.Yield();
                        //await Task.Delay(1);
                        Console.Write("");
                        //If (Frame4_Data(13) < 128) Then
                        fraH = Frames.Frame4_Data[13];
                        fraL = Frames.Frame4_Data[12];
                        IOadd = ((256 * fraH) + fraL);
                        //End If
                        //MsgBox IOadd
                    } while (!((Frames.Frame4_Data[14] == 2) && IOadd == Write4NVRam_adds)); //data Ack
                    flag = 0; //go back to idle
                    Frames.Frame0_Data[38] = (byte)flag;
                    do
                    {
                        //await Task.Yield();
                        //await Task.Delay(1);
                        Console.Write("");
                    } while (!(Frames.Frame4_Data[14] == 0));
                    Write4NVRam_adds = 0;
                    break;
            }
            Write4NVRam_offset = (byte)((Write4NVRam_offset + 1) % 4);

        }

        public static double GetCalport(double Calib_Ratio)
        {
            //getCalport = (((Frame4_Data(29) And &HF) * &H100) Or Frame4_Data(28)) * 0.018315 * Calib_Ratio
            double p_meter;
            p_meter = (((Frames.Frame4_Data[32] & 0xF) * 0x100) | Frames.Frame4_Data[31]) * 0.018315 * Calib_Ratio;
            p_meter = Convert.ToDouble(String.Format("{0:0.00}", p_meter));
            return p_meter;
            //getCalport = ((Frame4_Data(29) * &H100) Or Frame4_Data(28))
        }


        public static void ShowInterlockScreen(byte PrimaryCause, string mode)
        {
            //_serialPort = new SerialPort();
            //if (_serialPort.IsOpen == false)
            //{
            //    return;
            //}

            if (PrimaryCause != 0)
            {
                try
                {
                    // Show interlocks popup on this line 
                    Globals.UserInterlockFlag = true;
                    FormMode = mode;
                    if (PrimaryCause >= 15)
                    {
                        Post_Data(5, 1);

                    }
                    else if (PrimaryCause < 15)
                    {
                        Post_Data(5, 0);
                    }
                }
                catch
                {

                }
            }
            else
            {
                Post_Data(25, 0); //interlock normal
            }
        }


        public static void ReadWriteThreadsInit()
        {
            LaserOperations laserOperations = new LaserOperations();
            try
            {
                // Settings for Serial Port // Do not change values 
                _serialPort = new SerialPort();
                _serialPort.PortName = SetPortName();
                _serialPort.Handshake = Handshake.None;
                _serialPort.ReadBufferSize = 1024;
                _serialPort.WriteBufferSize = 512;
                _serialPort.DtrEnable = true;
                _serialPort.RtsEnable = false;
                _serialPort.BaudRate = 9600;
                _serialPort.Parity = Parity.None;
                _serialPort.DataBits = 8;
                _serialPort.StopBits = StopBits.One;
                _serialPort.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine($"[{DateTime.UtcNow.ToLocalTime()}] : {e.Message}");
                return;
            }

            //var timer = new Timer(async (object stateInfo) =>
            //{
            //    laserOperations.Read();
            //    Console.WriteLine($"[{DateTime.UtcNow.ToLocalTime()}] : Running Read()");
            //}, null, 0, 0);

            //var writeTimer = new Timer(new TimerCallback(_ =>
            //{
            //    laserOperations.WriteFrame0Data();
            //    Console.WriteLine($"[{DateTime.UtcNow.ToLocalTime()}] : Running WriteFrame0Data()");
            //}), null, 0, 50);

            //var readTimer = new Timer(new TimerCallback(_ =>
            //{
            //    laserOperations.Read();
            //}), new AutoResetEvent(false), 0, 10);


            Task.Factory.StartNew(() => {
                while (true)
                {
                    //Console.WriteLine($"[{DateTime.UtcNow.ToLocalTime()}] : Running WriteFrame0Data()");
                    //Console.WriteLine(" ");
                    Console.Write("");
                    laserOperations.WriteFrame0Data();
                    //Task.Run(() => Task.Delay(10));
                    Task.Delay(10); // use 15+  
                    //Thread.Sleep(10);
                }
            }, TaskCreationOptions.LongRunning);

            Task.Factory.StartNew(() => {
                while (true)
                {
                    //Console.WriteLine($"[{DateTime.UtcNow.ToLocalTime()}] : Running Read()");
                    //Console.WriteLine(" ");
                    Console.Write("");
                    laserOperations.Read();
                }

            }, TaskCreationOptions.LongRunning);

            //new Thread(() =>
            //{
            //    Thread.CurrentThread.IsBackground = true;
            //    while (true)
            //    {
            //        Console.WriteLine($"[{DateTime.UtcNow.ToLocalTime()}] : Running WriteFrame0Data()");
            //        laserOperations.WriteFrame0Data();
            //        Task.Run(()=> Task.Delay(10));
            //        //Thread.Sleep(10);
            //    }
            //}).Start();


            //new Thread(() =>
            //{
            //    Thread.CurrentThread.IsBackground = true;
            //    while (true)
            //    {
            //        Console.WriteLine($"[{DateTime.UtcNow.ToLocalTime()}] : Running Read()");
            //        laserOperations.Read();
            //    }
            //}).Start();
        }







        public static byte ReadNVRam(byte AddressLow, byte AddressHigh)
        {
            //function must be read sequentially cannot  1,2, 3, 4 cannot read 1,4,2,3 etc
            int flag = 0;
            long IOadd = 0;
            byte DataValue = 0;
            long cadd = 0;
            long fraH = 0;
            long fraL = 0;
            long AddH = 0;
            long AddL = 0;

            AddH = AddressHigh;
            AddL = AddressLow;
            flag = 2; //flag (0=Idle, 1=Write request, 2=Read request, 3=Acknowledged)
            cadd = 256 * AddH + AddL;

            if (cadd < add)
            {
                offset = 0;
                add = 0;
            }
            if (4 + add < cadd)
            {
                offset = 0;
                add = 0;
            }
            if (offset == 0 && add == 0) //Frame4_Data(14) = 0 Then
            {
                add = cadd;
            }

            switch (offset)
            {

                case 0:
                    //MsgBox "ADD" & add
                    Frames.Frame0_Data[32] = AddressLow; //low address
                    Frames.Frame0_Data[33] = AddressHigh; //high address
                    Frames.Frame0_Data[38] = Convert.ToByte(flag); //Read request
                    do
                    {
                        //DoEvents;
                        fraH = Frames.Frame4_Data[13];
                        fraL = Frames.Frame4_Data[12];

                        IOadd = (256 * fraH) + fraL;
                        //End If
                        //MsgBox IOadd

                    } while (!((Frames.Frame4_Data[14] == 2) && IOadd == cadd)); //data Ack

                    DataValue = Frames.Frame4_Data[15];

                    break;
                case 1:
                    DataValue = Frames.Frame4_Data[16];
                    break;
                case 2:
                    //MsgBox "OFF" & offset
                    DataValue = Frames.Frame4_Data[17];
                    break;
                case 3:
                    //MsgBox "OFF to idle" & offset
                    DataValue = Frames.Frame4_Data[18];

                    break;
            }

            offset = (byte)((offset + 1) % 4);


            flag = 0; //go back to idle
            Frames.Frame0_Data[38] = Convert.ToByte(flag);

            do
            {
                //DoEvents;
            } while (!(Frames.Frame4_Data[14] == 0));

            return DataValue;

        }

    }
}

