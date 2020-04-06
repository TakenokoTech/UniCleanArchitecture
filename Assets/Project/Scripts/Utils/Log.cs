using System;
using System.Threading;
using UnityEngine;

namespace Project.Scripts.Utils
{
    public static class Log
    {
        public static void D(string tag, string msg, params object[] args)
        {
            var thread = Thread.CurrentThread;
            Debug.LogFormat("({0})[{1}] {2}", tag, thread.ManagedThreadId, string.Format(msg, args));
        }
    }
}