﻿using System;

namespace Szofttech_WPF.DataPackage
{
    [Serializable]
    public class ConnectionData : Data
    {
        public ConnectionData() : base() { }
        public ConnectionData(int clientID) : base(clientID) { }
    }
}
