using System;
using System.Collections.Generic;
using System.Text;

namespace delegete_events.Delegate_Event
{
    class Video
    {
        public string Title { get; set; }
    }

    class MailService
    {
        public void OnVideoEncoded(object source,VideoEventArgs args)
        {
            Console.WriteLine(source.GetType());
            Console.WriteLine("mailserverFired "+ args.video.Title);
        }
    }
    class Otp
    {
        public void OnVideoEncoded(object source, VideoEventArgs args)
        {
            Console.WriteLine("invoker: "+ source);
            Console.WriteLine("otpFired " + args.video.Title);
        }
    }
}
