using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using System.Threading;

Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(webBuilder =>
    {
        webBuilder.Configure(app =>
        {
            app.Run(async context =>
            {
                //simulate bad access code to db 
                //Thread.Sleep(2000);

                //simulate good access code to db using async so we dont block the thread that handling the current 
                //request and release it so it can handle another thread ,without needing to use another thread 
                //because we can run out of the threads that we can create so we have to wait for thread to finish 
                //to process incoming requests 
                await Task.Delay(3000);

                await context.Response.WriteAsync("hello");
            });
        });
    }).Build().Run();

