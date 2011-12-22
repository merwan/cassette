﻿using Cassette.BundleProcessing;
using Cassette.Configuration;

namespace Cassette.Stylesheets
{
    public class StylesheetBundle : Bundle
    {
        public StylesheetBundle(string applicationRelativePath)
            : base(applicationRelativePath)
        {
            ContentType = "text/css";
            Processor = new StylesheetPipeline();
        }

        /// <summary>
        /// The value of the media attribute for this stylesheet's link element. For example, <example>print</example>.
        /// </summary>
        public string Media { get; set; }

        /// <summary>
        /// The Internet Explorer specific condition used control if the stylesheet should be loaded using an HTML conditional comment.
        /// For example, <example>"lt IE 9"</example>.
        /// </summary>
        public string Condition { get; set; }

        public IBundleProcessor<StylesheetBundle> Processor { get; set; }

        public IBundleHtmlRenderer<StylesheetBundle> Renderer { get; set; }


        internal override void Process(CassetteSettings settings)
        {
            Processor.Process(this, settings);
        }

        internal override string Render()
        {
            return Renderer.Render(this);
        }
    }
}