using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace BillingApplication
{
    public static class Encode
    {

        public static string HtmlEncode(string text)
        {
            char[] chars = HttpUtility.HtmlEncode(text).ToCharArray();
            StringBuilder result = new StringBuilder(text.Length + (int)(text.Length * 0.1));

            foreach (char c in chars)
            {
                int value = Convert.ToInt32(c);
                if (value > 127)
                {
                    switch (value)
                    {
                        case 2534:
                            result.Append("0");
                            break;
                        case 2535:
                            result.Append("1");
                            break;
                        case 2536:
                            result.Append("2");
                            break;
                        case 2537:
                            result.Append("3");
                            break;
                        case 2538:
                            result.Append("4");
                            break;
                        case 2539:
                            result.Append("5");
                            break;
                        case 2540:
                            result.Append("6");
                            break;
                        case 2541:
                            result.Append("7");
                            break;
                        case 2542:
                            result.Append("8");
                            break;
                        case 2543:
                            result.Append("9");
                            break;
                        
                    }
                }

                else
                    result.Append(c);
            }

            return result.ToString();
        }

    }


}