+++
title = "Super Mario Bros Block Class (1)"
+++

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Super_Mario_Brothers.Animations;
using Super_Mario_Brothers.Collisions;
using Super_Mario_Brothers.Rooms;
using Super_Mario_Brothers.LevelDataStore.Importers;
using Super_Mario_Brothers.LevelDataStore;
using Super_Mario_Brothers.Behaviors;
using Microsoft.Xna.Framework.Audio;

namespace Super_Mario_Brothers.Entities
{
    public class Block : GameEntity
    {
        static Texture2D spriteSheet;
        static SoundEffect BrickSound;
        static SoundEffect SpawnSound;
        struct SpriteSet
        {
            public Sprite Dirt;
            public Sprite Used;
            public Sprite Bevel;
            public Sprite Question;
            public Sprite BrickTop;
            public Sprite Brick;

            internal Sprite BySpriteKind(ImportBlock.SpriteKind spriteKind)
            {
                switch (spriteKind) {
                    case ImportBlock.SpriteKind.DIRT:     return Dirt;
                    case ImportBlock.SpriteKind.BEVEL:    return Bevel;
                    case ImportBlock.SpriteKind.BLOCK:    return Used;
                    case ImportBlock.SpriteKind.QBLOCK:   return Question;
                    case ImportBlock.SpriteKind.BRICK:    return Brick;
                    case ImportBlock.SpriteKind.BRICKTOP: return BrickTop;
                }
                return null;
            }
        }
        private static SpriteSet[] sprites;
        int[] sprImages = new int[] { 0, 0, 0, 1, 2, 1 };

        GameEntityInstantiator contentInstantiator = null;
        int contentCount = 0;
        bool destructable = false;
        bool contentUseSpawner = false;
        
        Vector2 bumpOffset;

        protected override int initialDepth { get { return 0; } }

        public Block(Room room): base(room) {
            CurrentSprite = sprites[(int)room.TerrainTheme].Dirt;
        }

        override public void Update(GameTime time)
        {
            ImageIndex = sprImages[(int)(time.TotalGameTime.TotalMilliseconds / 125) % sprImages.Length];
            if (CurrentAnimation != null)
                CurrentAnimation.Update(this, time);
            bumpOffset /= 1.5f;
        }

        static Random rand = new Random();
        override public void Bump(GameEntity bumper, CollisionTesting.CollisionSides sides, GameTime time)
        {
            if ((sides & CollisionTesting.CollisionSides.OR_ALLSIDES) == CollisionTesting.CollisionSides.BOTTOM)
            {
                if (bumper is Mario)
                {
                    if (contentInstantiator != null) {
                        var e = MyRoom.Instantiate(contentInstantiator, time);
                        if (e.CurrentSprite != null)
                            e.Position = Position - CurrentSprite.Origin + new Vector2(CurrentSprite.Size.X / 2, CurrentSprite.Size.Y) +
                                new Vector2(e.CurrentSprite.Origin.X - e.CurrentSprite.Size.X / 2, e.CurrentSprite.Origin.Y - e.CurrentSprite.Size.Y);
                        else
                            e.Position = Position - CurrentSprite.Origin + CurrentSprite.Size / 2;
                        if (contentUseSpawner)
                        {
                            SpawnSound.Play();
                            e.CurrentAnimation = new Spawner(e, time, new Vector2(0, -CurrentSprite.Size.Y), 750);
                        }
                        bumpOffset = new Vector2(0, -4);
                        if (--contentCount == 0) {
                            contentInstantiator = null;
                            CurrentSprite = sprites[(int)MyRoom.TerrainTheme].Used;
                            if (!Visible)
                            {
                                Visible = true;
                                SolidSides = CollisionTesting.CollisionSides.EVERYTHING;
                            }
                        }
                    }
                    if (destructable)
                    {
                        if (!((Hero)bumper).IsPoweredUp())
                            bumpOffset = new Vector2(0, -4);
                        else
                        {
                            MyRoom.Destroy(this);
                            Vector2 g = new Vector2(0, .375f);
                            BrickSound.Play();
                            MyRoom.Add(new Particle(MyRoom, CurrentSprite, new Rectangle(0, 0, 8, 8), Position + new Vector2( 4,  4), new Vector2(-rand.Next(3,5), -rand.Next(3,6)), g, (float)(-.1 - .25 * rand.NextDouble())), time);
                            MyRoom.Add(new Particle(MyRoom, CurrentSprite, new Rectangle(8, 0, 8, 8), Position + new Vector2(12,  4), new Vector2(+rand.Next(3,5), -rand.Next(3,6)), g, (float)(-.1 - .25 * rand.NextDouble())), time);
                            MyRoom.Add(new Particle(MyRoom, CurrentSprite, new Rectangle(0, 8, 8, 8), Position + new Vector2( 4, 12), new Vector2(-rand.Next(3,5), -rand.Next(2,5)), g, (float)(-.1 - .25 * rand.NextDouble())), time);
                            MyRoom.Add(new Particle(MyRoom, CurrentSprite, new Rectangle(8, 8, 8, 8), Position + new Vector2(12, 12), new Vector2(+rand.Next(3,5), -rand.Next(2,5)), g, (float)(-.1 - .25 * rand.NextDouble())), time);
                        }
                    }
                }
            }
        }

        public override void Draw(GraphicsDevice graphics, SpriteBatch spriteBatch, GameTime time)
        {
            if (Visible)
                CurrentSprite.Draw(spriteBatch, (int)ImageIndex, Position + bumpOffset);
        }

        public class Instantiator : GameEntityInstantiator
        {
            override public GameEntity Instantiate(Room room) {
                return new Block(room);
            }

            protected override GameEntity ReadIn(Room room, EntityPlacementData e)
            {
                var res = new Block(room);
                ImportBlock ib = (ImportBlock)e.EntityImporter;
                res.CurrentSprite = sprites[(int)room.TerrainTheme].BySpriteKind(ib.Sprite);
                if (ib.Contains != null)
                {
                    res.contentInstantiator = Room.InstantiableEntities.LookUp(ib.Contains);
                    res.contentCount = ib.ContainsQuantity;
                    res.contentUseSpawner = ib.ContainsUseSpawner;
                }
                res.destructable = ib.Destructable;
                if (!(res.Visible = ib.Visible))
                    res.SolidSides = CollisionTesting.CollisionSides.BOTTOM;
                return res;
            }

            override public void LoadContent(ContentManager contentManager)
            {
                spriteSheet = contentManager.Load<Texture2D>("tileset");
                sprites = new SpriteSet[3];
                Point offset = new Point(0, 0);
                BrickSound = contentManager.Load<SoundEffect>("smb_breakblock");
                SpawnSound = contentManager.Load<SoundEffect>("smb_powerup_appears");
                for (int i = 0; i < sprites.Length; ++i) {
                    sprites[i].Dirt     = new Sprite(spriteSheet, new Rectangle(0   + offset.X,  0 + offset.Y, 16, 16), Vector2.Zero);
                    sprites[i].Used     = new Sprite(spriteSheet, new Rectangle(48  + offset.X,  0 + offset.Y, 16, 16), Vector2.Zero);
                    sprites[i].Bevel    = new Sprite(spriteSheet, new Rectangle(0   + offset.X, 16 + offset.Y, 16, 16), Vector2.Zero);
                    sprites[i].Question = new Sprite(spriteSheet, new Rectangle(384 + offset.X,  0 + offset.Y, 16, 16), Vector2.Zero, 3, new Vector2(16, 0));
                    sprites[i].BrickTop = new Sprite(spriteSheet, new Rectangle(16  + offset.X,  0 + offset.Y, 16, 16), Vector2.Zero);
                    sprites[i].Brick    = new Sprite(spriteSheet, new Rectangle(32  + offset.X,  0 + offset.Y, 16, 16), Vector2.Zero);
                    offset.Y += 32;
                }
            }
        }
    }
}
```
