using ICities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CameraGrid
{
    public class CameraGridSetting
    {

        public static void OnSettingsUI(UIHelperBase helper)
        {
            // Load the configuration
            CameraGridConfig config = Configuration<CameraGridConfig>.Load();

            var group = helper.AddGroup("Camera Grid Settings");

            group.AddDropdown("Toggle Key Code", new string[] { "Ctrl + J", "Shift + J", "Alt + J", "Ctrl + O", "Shift + O", "Alt + O"}, 0, sel =>
            {
                // change config value and save config
                config.ToggleKeyCode = sel;
                Configuration<CameraGridConfig>.Save();
            });

            group.AddCheckbox("Show Debug Panel", false, sel =>
            {
                UnityEngine.Debug.Log($"sel={sel}");
                // change config value and save config
                config.ShowDebugPanel = sel;
                Configuration<CameraGridConfig>.Save();
            });
        }

        private static int GetSelectedOptionIndex(int value, int[] optionValues)
        {
            int index = Array.IndexOf(optionValues, value);
            if (index < 0) index = 0;

            return index;
        }
    }
}
