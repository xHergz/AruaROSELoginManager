//
// FILE     : DataEventArgs.cs
// PROJECT  : AruaROSE Login Manager
// AUTHOR   : xHergz
// DATE     : 2021-02-19
// 

using System;

namespace AruaRoseLoginManager.Data
{
    public class DataEventArgs<T> : EventArgs
    {
        /// <summary>
        /// The data to pass through the events
        /// </summary>
        public T Data;
    }
}
