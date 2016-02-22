using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Hike
{
    public class ResultsWindow : Window
    {
        public Image picRenderer;

        public Sprite losePic;
        public Sprite winPic;

        public void SetupResults(bool win)
        {
            picRenderer.sprite = win ? winPic : losePic;
        }
    }
}
