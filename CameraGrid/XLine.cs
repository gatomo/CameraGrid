using ColossalFramework.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace CameraGrid
{
    public class XLine : UIPanel
    {
        public override void Start()
        {
            base.Start();

            base.name = "LineWindow";
            base.backgroundSprite = "MenuPanel2";
            canFocus = false;
            isInteractive = true;

            base.height = 1.0f;
            base.width = (float)Screen.width;

            base.backgroundSprite = "SubcategoriesPanel";
            base.isVisible = true;
        }
    }
}
