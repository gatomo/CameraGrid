using ICities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace CameraGrid
{
    public class CameraGrid : LoadingExtensionBase, IUserMod
    {

        public string Version => "0.1.1";
        public string Name => "CameraGrid";
        public string Description => $"[{Version}]Display the grid to help taking a photo.";

        public static CameraGridConfig Config;

        private static GameObject cameraGridDirector;

        public override void OnCreated(ILoading loading)
        {
        }

        public override void OnLevelLoaded(LoadMode mode)
        {
            base.OnLevelLoaded(mode);
            // Panel表示用オブジェクト
            cameraGridDirector = new GameObject("CameraGrid");
            cameraGridDirector.AddComponent<CameraGridDirector>();
        }

        public void OnEnabled()
        {

            Config = Configuration<CameraGridConfig>.Load();
        }
        public void OnDisabled()
        {
            Config = null;
        }


        public void OnSettingsUI(UIHelperBase helper) => CameraGridSetting.OnSettingsUI(helper);
    }

    public class KeyInputThreading : ThreadingExtensionBase
    {
        public static bool enabledByKeyToggle = true;

        public override void OnUpdate(float realTimeDelta, float simulationTimeDelta)
        {
            if (ToggleKeyCode())
            {
                enabledByKeyToggle = !enabledByKeyToggle;
                CameraGridDirector.instance.UpdateMode();
            }
        }

        private bool ToggleKeyCode()
        {
            switch (CameraGrid.Config.ToggleKeyCode)
            {
                case 0:
                    //Ctrl + J
                    return (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) && Input.GetKeyUp(KeyCode.J);
                case 1:
                    //Shift + J
                    return (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) && Input.GetKeyUp(KeyCode.J);
                case 2:
                    //Alt + J
                    return (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt)) && Input.GetKeyUp(KeyCode.J);
                case 3:
                    //Ctrl + O
                    return (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) && Input.GetKeyUp(KeyCode.O);
                case 4:
                    //Shift + O
                    return (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) && Input.GetKeyUp(KeyCode.O);
                case 5:
                    //Alt + O
                    return (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt)) && Input.GetKeyUp(KeyCode.O);
                default:
                    return false;
            }
        }

    }
}
