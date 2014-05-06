﻿using System.Drawing;

namespace BaseLib.Api{
    public interface INamedListItem : INamedItem{
        /// <summary>
        /// This number controls the order in which items are displayed e.g. in drop down menus.
        /// </summary>
        float DisplayOrder { get; }

        /// <summary>
        /// If false is returned, the item will not be available.
        /// </summary>
        bool IsActive { get; }

        /// <summary>
        /// The image for the menu entry and the shortcut button when applicable.
        /// </summary>
        Bitmap DisplayImage { get; }
    }
}