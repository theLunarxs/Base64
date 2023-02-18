using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base64
{
    public static class Tools
    {
        public static string ConvertToBase64(string input, bool ios)
        {
            string[] raw = ios ? input.Split("\v") : new string[] { input };
            string[] Final = new string[raw.Length];

            for (int i = 0; i < raw.Length; i++)
            {
                // Convert the string to a byte array using the UTF-8 encoding
                byte[] toByte = Encoding.UTF8.GetBytes(raw[i]);

                // Convert the byte array to a Base64-encoded string using the Convert.ToBase64String method
                string encoded = Convert.ToBase64String(toByte);

                Final[i] = encoded;

            }

            return string.Join("\r\n", Final); ;
        }

        public static void MakeLabelGo(int interval, Label label)
        {
            // Create a new timer
            System.Threading.Timer timer = null;

            // Set the callback function to disable the label
            TimerCallback callback = state =>
            {
                label.Invoke(new Action(() =>
                {
                    label.Visible = false;
                }));

                // Dispose of the timer
                timer.Dispose();
            };

            // Start the timer
            timer = new System.Threading.Timer(callback, null, interval, Timeout.Infinite);
        }
    }
}
