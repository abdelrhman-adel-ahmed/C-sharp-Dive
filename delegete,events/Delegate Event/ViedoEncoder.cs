using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
namespace delegete_events.Delegate_Event
{

    class VideoEventArgs 
    {
        public Video video { set; get; }
    }

    class VideoEncoder
    {
        //naming convention:append EventHandler     
        public delegate void VideoEncoderEventHandler(object source, VideoEventArgs args);
        //naming convention:use the past tense indicate that event will be fired after the viedoencode finish
        public event VideoEncoderEventHandler VideoEncoded;

        //or just use eventhandler 
       //public event EventHandler VideoEncoded;

        public void Encode(Video video)
        {
            Console.WriteLine("Encoding video");
            Thread.Sleep(2000);
            
            OnVideoEncoded(video);
        }

        public static void run()
        {
            Video video = new Video { Title = "v1" };
            VideoEncoder videoencoder = new VideoEncoder();
            MailService m = new MailService();
            Otp o = new Otp();
            videoencoder.VideoEncoded += m.OnVideoEncoded;
            videoencoder.VideoEncoded += o.OnVideoEncoded;

            videoencoder.Encode(video);

        }

        //naming convention of the method that will invoke the event:start with on follow by event name
        //declared as protected virtual
        protected virtual void OnVideoEncoded(Video v)
        {
           
            Console.WriteLine(VideoEncoded.Target);
            VideoEncoded?.Invoke(this, new VideoEventArgs { video = v });
        }
    }
   
}
