using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;

namespace Schedulaaa2021_1._0
{
    public class Toast
    {
        public static void show(string text)
        {
            new ToastContentBuilder().AddText(text).Show();
        }
        public static void show(List<string> texts, Dictionary<string, string> args)
        {
            ToastContentBuilder builder = new ToastContentBuilder();

            foreach (string t in texts)
            {
                builder.AddText(t.ToString());
            }

            foreach (var a in args)
            {
                builder.AddArgument(a.Key, a.Value);
            }

            builder.Show();
        }
    }
}
