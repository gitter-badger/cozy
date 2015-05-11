﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CozyKxlol.Kxlol.Object;
using CozyKxlol.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CozyKxlol.Kxlol.Scene
{
    class BallGameSceneLayer : CozyLayer
    {
        List<CozyCircle> CircleList = new List<CozyCircle>();

        public BallGameSceneLayer()
        {
            var circle1 = new CozyCircle(new Vector2(300.0f, 300.0f), 20.0f, Color.Red, new Vector2(20.0f, 0.0f));
            var circle2 = new CozyCircle(new Vector2(400.0f, 300.0f), 20.0f, Color.Blue, new Vector2(0.0f, 20.0f));
            var circle3 = new CozyCircle(new Vector2(500.0f, 300.0f), 20.0f, Color.Green, new Vector2(-20.0f, 20.0f));
            var circle4 = new CozyCircle(
                new Vector2(500.0f, 200.0f),
                50.0f,
                CozyCircle.RandomColor(),
                new Vector2(-20.0f, 20.0f));

            CircleList.Add(circle1);
            CircleList.Add(circle2);
            CircleList.Add(circle3);
            CircleList.Add(circle4);
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var obj in CircleList)
            {
                obj.Update(gameTime);
            }

            List<KeyValuePair<CozyCircle, CozyCircle>> RemoveList = new List<KeyValuePair<CozyCircle, CozyCircle>>();
            foreach (var obj1 in CircleList)
            {
                foreach(var obj2 in CircleList)
                {
                    if(obj1.CanEat(obj2))
                    {
                        RemoveList.Add(new KeyValuePair<CozyCircle,CozyCircle>(obj1, obj2));
                    }
                }
            }

            foreach(var obj in RemoveList)
            {
                obj.Key.Radius = obj.Key.Radius + obj.Value.Radius;
                CircleList.Remove(obj.Value);
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (var obj in CircleList)
            {
                obj.Draw(gameTime, spriteBatch);
            }
        }
    }
}