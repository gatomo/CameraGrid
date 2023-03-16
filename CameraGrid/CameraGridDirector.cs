using ColossalFramework.Plugins;
using ColossalFramework.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace CameraGrid
{
    public class CameraGridDirector : MonoBehaviour
    {
        public static List<XLine> xLines = new List<XLine>();
        public static List<YLine> yLines = new List<YLine>();

        // 0.118% of height is game console. The console part will be disappear when player use camera mod.
        public const float defRatio = 1.118f;
        public const float defLine = 8.5f;

        public static CameraGridDirector instance;

        private GridMode mode = GridMode.Disable;

        private void Start()
        {
            instance = this;
        }

        public void UpdateMode()
        {
            // 既存のグリッドを削除する
            xLines.ForEach(e => Destroy(e));
            xLines.Clear();
            yLines.ForEach(e => Destroy(e));
            yLines.Clear();

            switch (mode)
            {
                case GridMode.Disable:
//                    UnityEngine.Debug.Log($"[Camera Grid] Disabled Grid.");
                    mode = GridMode.Divide2;
                    break;
                case GridMode.Divide2:
//                    UnityEngine.Debug.Log($"[Camera Grid] Draw Grid 2.");
                    mode = GridMode.Divide3;
                    DrawGrid(2);
                    break;
                case GridMode.Divide3:
//                    UnityEngine.Debug.Log($"[Camera Grid] Draw Grid 3.");
                    mode = GridMode.Disable;
                    DrawGrid(3);
                    break;
                default:
                    break;
            }
        }

        public void DrawGrid(int divide)
        {

            // Get screen resolution
            // 
            float gameWidth = (float)Screen.width;
            float gameHeight = (float)Screen.height;
            string log = $"[Camera Grid] GameWidth={gameWidth}, GameHeight={gameHeight}, \r\nScreen.CurrentResolution Width={Screen.currentResolution.width}, Height={Screen.currentResolution.height}\r\n";

            // calculate distance between grid line
            float yUnit = gameHeight / defRatio / (float)divide;
            float xUnit = divide == 2 ? gameWidth / (float)divide : gameWidth / defRatio / (float)divide;
            log += $"Horizontal distance={xUnit}, Vertical distance={yUnit}\r\n";

            float xPadding = divide == 2 ? 0.0f : gameWidth * 0.059f;

            UIView uIView = UIView.GetAView();

            for (int i = 1; i < divide; i++)
            {
                var xLine = (uIView.AddUIComponent(typeof(XLine)) as XLine);
                xLine.absolutePosition = new Vector3(0.0f, yUnit * i - defLine);
                xLines.Add(xLine);

                var yLine = (uIView.AddUIComponent(typeof(YLine)) as YLine);
                yLine.absolutePosition = new Vector3(xUnit * i + xPadding - defLine, 0.0f);
                yLines.Add(yLine);

                log += $"Horizontal line[{i}]: Vector(0.0f, {yUnit * i - defLine})\r\n";
                log += $"Vertical line[{i}]: Vector({xUnit * i + xPadding - defLine}, 0.0f)\r\n";
            }

            if (CameraGrid.Config.ShowDebugPanel)
            {
                UnityEngine.Debug.Log($"{log}");
                DebugOutputPanel.AddMessage(PluginManager.MessageType.Message, log);
            }
        }
    }
}
