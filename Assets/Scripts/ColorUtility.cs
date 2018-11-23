using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Tool {
    public static class ColorUtility {
        public static Palette GetPalette(int power) {
            Palette palette = new Palette();
            string textRgb = "#ffffff";
            string backgroundRgb = "#000000";
            switch (power) {
                case 1:
                case 2:
                    backgroundRgb = "#E0E0E0";
                    textRgb = "000000";
                    break;
                case 3:
                    backgroundRgb = "#BDBDBD";
                    textRgb = "000000";
                    break;
                case 4:
                    backgroundRgb = "#9E9E9E";
                    textRgb = "000000";
                    break;
                case 5:
                    backgroundRgb = "#757575";
                    textRgb = "#ffffff";
                    break;
            }
            if (5 < power && power <= 8) {
                backgroundRgb = "#616161";
                textRgb = "#ffffff";
            }
            if (8 < power && power <= 12) {
                backgroundRgb = "#424242";
                textRgb = "#ffffff";
            }
            if (12 < power) {
                backgroundRgb = "#212121";
                textRgb = "#ffffff";
            }
            palette.background = ToColor(backgroundRgb);
            palette.text = ToColor(textRgb);
            return palette;
        }

        public static Color ToColor(string argRgb) {
            Color color;
            string rgb = argRgb;
            if (rgb.Substring(0, 1) != "#") {
                rgb = "#" + rgb;
            }
            if (!UnityEngine.ColorUtility.TryParseHtmlString(rgb, out color)) {
                throw new System.Exception("Invalid argument as rgb: " + rgb);
            }
            return color;
        }
    }

    public class Palette {
        public Color text = Color.black;
        public Color background = Color.white;
    }
}