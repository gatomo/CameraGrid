using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CameraGrid
{
    [ConfigurationPath("CameraGrid.xml")]
    public class CameraGridConfig
    {
        public int ToggleKeyCode { get; set; } = 0;

        public bool ShowDebugPanel { get; set; } = false;
    }
}
