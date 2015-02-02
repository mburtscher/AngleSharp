﻿namespace AngleSharp.Samples.Demos.Snippets
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    class GatherDataFromRssFeed : ISnippet
    {
        public async Task Run()
        {
            var feed = DocumentBuilder.Html(new Uri("http://www.florian-rappl.de/RSS"));
            var items = feed.QuerySelectorAll("item").Select(m => new
            {
                Updated = DateTime.Parse(m.GetElementsByTagName("a10:updated").First().TextContent),
                Title = m.QuerySelector("title").TextContent
            });

            Console.WriteLine("Available titles:");

            foreach (var item in items)
                Console.WriteLine("- {0} ({1})", item.Title, item.Updated);
        }
    }
}
