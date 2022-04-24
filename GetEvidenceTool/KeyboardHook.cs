using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static GetEvidenceTool.KeyboardHook;

namespace GetEvidenceTool
{
    [Flags]
    public enum KbLLHookFlags : uint
    {
        Extended = 0x01,
        Injected = 0x10,
        AltDown = 0x20,
        Up = 0x80
    }

    public class KeyboardHook
    {
        protected const int WH_KEYBOARD_LL = 0x000D;
        protected const int WM_KEYDOWN = 0x0100;
        protected const int WM_KEYUP = 0x0101;
        protected const int WM_SYSKEYDOWN = 0x0104;
        protected const int WM_SYSKEYUP = 0x0105;

        [StructLayout(LayoutKind.Sequential)]
        public class KBDLLHOOKSTRUCT
        {
            public uint vkCode;
            public uint scanCode;
            public KBDLLHOOKSTRUCTFlags flags;
            public uint time;
            public UIntPtr dwExtraInfo;

        }

        [Flags]
        public enum KBDLLHOOKSTRUCTFlags : uint
        {
            KEYEVENTF_EXTENDEDKEY = 0x0001,
            KEYEVENTF_KEYUP = 0x0002,
            KEYEVENTF_SCANCODE = 0x0008,
            KEYEVENTF_UNICODE = 0x0004,
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, KeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        private delegate IntPtr KeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        private IntPtr hookId = IntPtr.Zero;

        public void Hook()
        {
            if (hookId == IntPtr.Zero)
            {
                KeyboardProc proc = HookProcedure;
                using (var curProcess = Process.GetCurrentProcess())
                {
                    using (ProcessModule? curModule = curProcess.MainModule)
                    {
                        if (curModule != null)
                        {
                            hookId = SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName ?? ""), 0);
                        }
                    }
                }
            }
        }

        public void UnHook()
        {
            UnhookWindowsHookEx(hookId);
            hookId = IntPtr.Zero;
        }

        public IntPtr HookProcedure(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && (wParam == (IntPtr)WM_KEYDOWN || wParam == (IntPtr)WM_SYSKEYDOWN))
            {
                KBDLLHOOKSTRUCT? kbinfo = (KBDLLHOOKSTRUCT?)Marshal.PtrToStructure(lParam, typeof(KBDLLHOOKSTRUCT));
                OnKeyDownEvent(kbinfo);
            }
            else if (nCode >= 0 && (wParam == (IntPtr)WM_KEYUP || wParam == (IntPtr)WM_SYSKEYUP))
            {
                KBDLLHOOKSTRUCT? kbinfo = (KBDLLHOOKSTRUCT?)Marshal.PtrToStructure(lParam, typeof(KBDLLHOOKSTRUCT));
                OnKeyUpEvent(kbinfo);
            }
            return CallNextHookEx(hookId, nCode, wParam, lParam);
        }

        public delegate void KeyEventHandler(object sender, LowLevelKeyEventArgs e);
        public event KeyEventHandler? KeyDownEvent;
        public event KeyEventHandler? KeyUpEvent;

        protected void OnKeyDownEvent(KBDLLHOOKSTRUCT? data)
        {
            if (data != null)
            {
                KeyDownEvent?.Invoke(this, new LowLevelKeyEventArgs(data));
            }
            
        }
        protected void OnKeyUpEvent(KBDLLHOOKSTRUCT? data)
        {
            if (data != null)
            {
                KeyUpEvent?.Invoke(this, new LowLevelKeyEventArgs(data));
            }
        }
    }

    public class LowLevelKeyEventArgs : EventArgs
    {
        public int Code { get; set; }


        public LowLevelKeyEventArgs(KBDLLHOOKSTRUCT data)
        {
            Code = (int)data.vkCode;
        }
    }
}
