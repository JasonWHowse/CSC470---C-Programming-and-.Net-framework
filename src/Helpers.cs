using System;
using System.Windows.Media;

namespace Lab4.src {
    class Helpers {
        public static Color ColorFromHex(string color) {
            return Color.FromRgb(Convert.ToByte(color[0..2], 16), Convert.ToByte(color[2..4], 16), Convert.ToByte(color[4..6], 16));
        }//private static Color ColorFromHex(string color) {
    }//class Helpers {
}//namespace Lab4.src {