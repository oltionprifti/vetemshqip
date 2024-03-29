﻿using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Xml.Linq;

namespace AppStudio.Data
{
    /// <summary>
    /// Rss reader implementation to parse Rss content.
    /// </summary>
    internal class RssReader : BaseRssReader
    {
        private readonly XNamespace NsRdfNamespaceUri = "http://www.w3.org/1999/02/22-rdf-syntax-ns#";
        private readonly XNamespace NsRdfElementsNamespaceUri = "http://purl.org/dc/elements/1.1/";

        /// <summary>
        /// THis override load and parses the document and return a list of RssSchema values.
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public override ObservableCollection<RssSchema> LoadFeed(XDocument doc)
        {
            bool isRDF = false;
            var feed = new ObservableCollection<RssSchema>();
            XNamespace defaultNamespace = string.Empty;

            if (doc.Root != null)
            {
                isRDF = doc.Root.Name == (NsRdfNamespaceUri + "RDF");
                defaultNamespace = doc.Root.GetDefaultNamespace();
            }

            foreach (var item in doc.Descendants(defaultNamespace + "item"))
            {
                var rssItem = isRDF ? ParseRDFItem(item) : ParseRssItem(item);
                feed.Add(rssItem);
            }
            return feed;
        }

        /// <summary>
        /// RSS all versions
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private static RssSchema ParseItem(XElement item)
        {
            var rssItem = new RssSchema();
            rssItem.Title = item.GetSafeElementString("title").Trim();
            rssItem.FeedUrl = item.GetSafeElementString("link");

            string content = item.GetSafeElementString("encoded", "http://purl.org/rss/1.0/modules/content/");
            if (string.IsNullOrEmpty(content))
                content = item.GetSafeElementString("content");


            string description = item.GetSafeElementString("content");

            rssItem.Content = string.IsNullOrEmpty(content) ? RssHelper.SanitizeString(description) : RssHelper.SanitizeString(content);

            rssItem.Summary = Utility.DecodeHtml(description).Trim().Truncate(500, true);

            rssItem.Summary = RssHelper.SanitizeString(rssItem.Summary);


            return rssItem;
        }

        /// <summary>
        /// RSS version 1.0
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private RssSchema ParseRDFItem(XElement item)
        {
            var rssItem = ParseItem(item);

            rssItem.PublishDate = item.GetSafeElementDate("date", NsRdfElementsNamespaceUri);

            string image = item.GetSafeElementString("image");
            if (string.IsNullOrEmpty(image))
            {
                image = item.GetImage();
            }
            if (string.IsNullOrEmpty(image) && item.ToString().Contains("media:thumbnail"))
            {
                XNamespace ns = "http://search.yahoo.com/mrss/";
                var element = item.Elements(ns + "thumbnail").Last();
                image = element.Attribute("url").Value;
            }
            if (string.IsNullOrEmpty(image) && item.ToString().Contains("thumbnail"))
            {
                image = item.GetSafeElementString("thumbnail");
            }

            rssItem.ImageUrl = image;

            return rssItem;
        }

        /// <summary>
        /// RSS version 2.0
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private static RssSchema ParseRssItem(XElement item)
        {
            var rssItem = ParseItem(item);

            rssItem.PublishDate = item.GetSafeElementDate("pubDate");

            string image = item.GetSafeElementString("image");
            if (string.IsNullOrEmpty(image))
            {
                image = item.GetImageFromEnclosure();
            }
            if (string.IsNullOrEmpty(image))
            {
                image = item.GetImage();
            }
            if (string.IsNullOrEmpty(image) && item.ToString().Contains("media:thumbnail"))
            {
                XNamespace ns = "http://search.yahoo.com/mrss/";
                var element = item.Elements(ns + "thumbnail").Last();
                image = element.Attribute("url").Value;
            }
            if (string.IsNullOrEmpty(image) && item.ToString().Contains("thumbnail"))
            {
                image = item.GetSafeElementString("thumbnail");
            }

            rssItem.ImageUrl = image;

            return rssItem;
        }
    }
}
