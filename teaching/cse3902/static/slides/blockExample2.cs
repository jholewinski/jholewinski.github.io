using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Sprint6
{
    public class Block: IBlock
    {
        public IState TheState { get; set; }

        public Vector2 Location { get; set; }

        public IAnimatedSprite TheSprite { get; set; }

        public IPhysics ThePhysics { get; set; }

        public Boolean Flag { get; set; }

        public Game1 theGame;

        public Block(Game1 theGame)
        {
            this.theGame = theGame;
            this.TheState = new BrickBlockState(this);
            this.SetSpriteBasedOnState();
            ThePhysics = new Physics();
        }
        public void Update()
        {
            TheSprite.Update();
        }
        public void Draw()
        {
            TheSprite.Draw(theGame.spriteBatch, Location);
        }

        public void SetSpriteBasedOnState()
        {
            this.TheSprite = TheState.GetAnimatedSprite();
        }
    }
}
