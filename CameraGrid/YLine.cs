using ColossalFramework.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace CameraGrid
{
    public class YLine : UIPanel
    {
        public override void Start()
        {
            base.Start();

            base.name = "LineWindow";
            base.backgroundSprite = "MenuPanel2";
            canFocus = false;
            isInteractive = true;

            base.height = (float)Screen.height;
            base.width = 1.0f;

            base.backgroundSprite = "SubcategoriesPanel";
            base.isVisible = true;
        }
    }
}
