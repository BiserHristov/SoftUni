﻿using MyWebServer.HTTP;

namespace MyWebServer.Results
{
    public class ContentResult : ActionResult
    {

        public ContentResult(
            HTTPResponse response,
            string content,
            string contentType)
            : base(response)
        {

            this.PrepareContent(content, contentType);

        }

    }
}
