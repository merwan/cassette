﻿using System;
using Cassette.BundleProcessing;

namespace Cassette.Stylesheets
{
    public class ParseCssReferences : ParseReferences<StylesheetBundle>
    {
        protected override bool ShouldParseAsset(IAsset asset)
        {
            return asset.SourceFile.FullPath.EndsWith(".css", StringComparison.OrdinalIgnoreCase);
        }

        internal override ICommentParser CreateCommentParser()
        {
            return new CssCommentParser();
        }
    }
}