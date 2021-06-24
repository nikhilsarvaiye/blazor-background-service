namespace Services
{
    public static class Frames
    {
        public static byte Frame0_length = 40; //37
        public static byte Frame1_length = 53;
        public static byte Frame2_length = 56;
        public static byte Frame3_length = 21; //24 '21
        public static byte Frame4_length = 46; //45 '42
        public static byte Frame5_length = 62;
        public static byte Frame7_length = 6;
        public static byte[] Frame0_Data = new byte[Frame0_length + 1];
        public static byte[] Frame1_Data = new byte[Frame1_length + 1];
        public static byte[] Frame2_Data = new byte[Frame2_length + 1];
        public static byte[] Frame3_Data = new byte[Frame3_length + 1];
        public static byte[] Frame4_Data = new byte[Frame4_length + 1];
        public static byte[] Frame5_Data = new byte[Frame5_length + 1];
        public static byte[] Frame7_Data = new byte[Frame7_length + 1];

        public static byte[] OutMessage;
        public static int[] crcMapA = new int[16];
        public static int[] crcMapB = new int[16];

        public static byte[] SendBuffer = new byte[127]; // MaxBufferSize = 127
        public static byte[] ReceiveBuffer = new byte[255]; // MaxInBufferSize = 255
        public static byte[] StuffedSendBuffer = new byte[255]; // MaxInBufferSize = 255
    }
}
