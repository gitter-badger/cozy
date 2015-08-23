﻿using CozyDungeon.Game.Component.Card.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CozyDungeon.RoleCardEditor
{
    public partial class EditorForm
    {
        private int InnerID = 0;
        public int IDMaker
        {
            get
            {
                return InnerID++;
            }
        }

        private void ClearId()
        {
            InnerID = 0;
        }

        private bool IsModified { get; set; }

        private void AddCard(RoleCard card, Image cardImage, Image selectedImage)
        {
            IsModified = true;

            ListOfRoleCardList[(int)card.Level].Add(card);
            CardImageDictionary[card.Id] = cardImage;

            ResetInput();
        }
    }
}
