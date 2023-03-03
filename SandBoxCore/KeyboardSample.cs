//using System;
//using System.Text;
//using System.Windows.Forms;

//namespace SandBoxCore
//{
//    public class KeyboardSample
//    {
//        public KeyboardSample()
//        {
//            string inputString = "F12, Alt, Shift, Control";

//            //  inputString = "f12 + alt+ctrl";
//            inputString = "f12+      shift+alt, Ctrl";

//            //inputString = Regex.Replace(inputString, @"\s+", " ");
//            //    inputString = Regex.Replace(inputString, @"[\s]*[\x2B]?[\x2C]?[\s]+", ", ");

//            const string delimiter = ", ";

//            var elementBuilder = new StringBuilder();
//            inputString = inputString.ToLowerInvariant().Replace("+", " ").Replace(",", " ").Replace("ctrl", "control");
//            string[] inputElements = inputString.Split(' ');
//            foreach (string s in inputElements)
//            {
//                if (String.IsNullOrEmpty(s))
//                    continue;

//                elementBuilder.Append(s.Trim() + delimiter);
//            }

//            inputString = elementBuilder.Remove(elementBuilder.Length - delimiter.Length, delimiter.Length).ToString();

//            Keys k;
//            //Enum.TryParse("F12", false, out k);
//            bool result = Enum.TryParse(inputString, true, out k);
//            if (!result)
//                throw new Exception("Failed to parse input");
//            //  var k = Keys.F1;
//            // var k = Keys.F12 | Keys.Alt |  Keys.Shift;

//            //var k2 = Keys.Modifiers.
//            bool flag = k.HasFlag(Keys.Alt);

//            string keyCode = k.ToString();

//            // "F12, Shift, Alt"
//            // "F12"

//            switch (k)
//            {
//                case Keys.F12:
//                    break;
//                case Keys.F12 | Keys.Alt:
//                    break;
//                case Keys.F12 | Keys.Alt | Keys.Shift:
//                    break;
//                case Keys.F12 | Keys.Alt | Keys.Control:
//                    break;
//                case Keys.F12 | Keys.Control | Keys.Shift:
//                    break;
//                case Keys.F12 | Keys.Alt | Keys.Shift | Keys.Control:
//                    break;
//                default:
//                    break;
//            }
//        }
//    }
//}