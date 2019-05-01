using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        [DllImport(@"C:\Program Files (x86)\Corelis\ScanExpress Runner v6\ScanExpressRunner.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr InitHardware();

        [DllImport(@"C:\Program Files (x86)\Corelis\ScanExpress Runner v6\ScanExpressRunner.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr LoadTestPlan(string TestPlan, string Controller);

        [DllImport(@"C:\Program Files (x86)\Corelis\ScanExpress Runner v6\ScanExpressRunner.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr AsyncRunTestPlan();
        static void Main(string[] args)
        {
            try
            {
                var x = InitHardware();
                Console.WriteLine(PtrToStringUtf8(x));
                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
        private static string PtrToStringUtf8(IntPtr ptr) // aPtr is nul-terminated
        {
            if (ptr == IntPtr.Zero)
                return "";
            int len = 0;
            while (System.Runtime.InteropServices.Marshal.ReadByte(ptr, len) != 0)
                len++;
            if (len == 0)
                return "";
            byte[] array = new byte[len];
            System.Runtime.InteropServices.Marshal.Copy(ptr, array, 0, len);
            return System.Text.Encoding.UTF8.GetString(array);
        }
    }
}

