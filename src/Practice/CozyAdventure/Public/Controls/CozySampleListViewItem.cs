﻿using CocosSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CozyAdventure.Public.Controls
{
    public class CozySampleListViewItem : CozyControl
    {
        public CozySampleListViewItem(CCNode node)
        {
            node.AnchorPoint = CCPoint.Zero;
            this.AddChild(node);
            this.ContentSize = node.ContentSize;
        }
    }
}
