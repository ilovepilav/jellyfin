﻿using MediaBrowser.Controller.Entities;
using MediaBrowser.Controller.Library;
using System;
using System.ComponentModel.Composition;
using System.IO;

namespace MediaBrowser.Controller.Resolvers
{
    /// <summary>
    /// Class LocalTrailerResolver
    /// </summary>
    [Export(typeof(IBaseItemResolver))]
    public class LocalTrailerResolver : BaseVideoResolver<Trailer>
    {
        /// <summary>
        /// Resolves the specified args.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns>Trailer.</returns>
        protected override Trailer Resolve(ItemResolveArgs args)
        {
            // Trailers are not Children, therefore this can never happen
            if (args.Parent != null)
            {
                return null;
            }

            // If the file is within a trailers folder, see if the VideoResolver returns something
            if (!args.IsDirectory)
            {
                if (string.Equals(Path.GetFileName(Path.GetDirectoryName(args.Path)), BaseItem.TrailerFolderName, StringComparison.OrdinalIgnoreCase))
                {
                    return base.Resolve(args);
                }
            }

            return null;
        }
    }
}
