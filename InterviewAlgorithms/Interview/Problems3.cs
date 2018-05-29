using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Interview
{
    class Problems3
    {
        // What is wrong with this code?
        //      The hWnd, wParam, and lParam parameters should be pointers, as documented by the Win32 C prototype:
        //
        //      typedef UINT_PTR WPARAM;
        //      typedef LONG_PTR LPARAM;
        //      LRESULT WINAPI SendMessage(HWND hWnd, UINT Msg, WPARAM wParam, LPARAM lParam);
        //          
        //      Therefore the updated code should be as follows:

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SendMessage(
              IntPtr hWnd,      // handle to destination window
              uint Msg,       // message
              UIntPtr wParam,  // first message parameter
              IntPtr lParam   // second message parameter
              );

        //[DllImport("user32.dll", SetLastError = true)]
        //public static extern IntPtr SendMessage(
        //      int hWnd,      // handle to destination window
        //      uint Msg,       // message
        //      int wParam,  // first message parameter
        //      int lParam   // second message parameter
        //      );
    }
}
