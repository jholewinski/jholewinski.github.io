﻿namespace ObjectManagementExamples
{
	public class EnemySpriteFactory
	{
		private Texture2D enemySpritesheet;
		// More private Texture2Ds follow
		// ...
		
		private static EnemySpriteFactory instance = new EnemySpriteFactory();
				
		public static EnemySpriteFactory Instance
		{
			get
			{
				return instance;
			}
		}
		
		private EnemySpriteFactory()
		{
		}
			
		public void LoadAllTextures(ContentManager content)
		{
			enemySpriteSheet = content.Load<Texture2D>("enemy");
			// More Content.Load calls follow
			//...
		}
		
		public ISprite CreateSmallEnemySprite()
		{
			return new EnemySprite(enemySpritesheet, 32, 32);
		}
		
		public ISprite CreateBigEnemySprite()
		{
			return new EnemySprite(enemySpritesheet, 64, 64);
		}
		
		public ISprite CreateTintedEnemySprite(ILevel level)
		{
			return new EnemySprite(enemySpritesheet, level.ColorTheme);
		}
		
		// More public ISprite returning methods follow
		// ...
	}
}

// Client code in main game class' LoadContent method:
EnemySpriteFactory.Instance.LoadAllTextures(Content);

// Client code in Goomba class:
ISprite mySprite = EnemySpriteFactory.Instance.CreateBigEnemySprite();