// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.EventGrid.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.EventGrid;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FunctionApp
{
    public static class Functions
    {
        [FunctionName("negotiate")]
        public static SignalRConnectionInfo GetSignalRInfo(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequest req,
            [SignalRConnectionInfo(HubName = "chat")] SignalRConnectionInfo connectionInfo)
        {
            return connectionInfo;
        }

        [FunctionName("tweet")]
        public static Task SendTweet(
            [EventGridTrigger]EventGridEvent eventGridEvent,
            [SignalR(HubName = "chat")] IAsyncCollector<SignalRMessage> signalRMessages,
            ILogger log)
        {

            //log.LogInformation($"Received Event: {JsonConvert.SerializeObject(eventGridEvent.Data)}");
            dynamic data = eventGridEvent.Data;

            log.LogInformation($"Received tweet (${data.TweetText}) by (${data.TweetedBy})");

            var message = new
            {
                id = Guid.NewGuid().ToString(),
                sender = data.TweetedBy,
                text = data.TweetText
            };

            return signalRMessages.AddAsync(
                new SignalRMessage
                {
                    Target = "newMessage",
                    Arguments = new[] { message }
                });
        }

        public static object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }
    }
}
