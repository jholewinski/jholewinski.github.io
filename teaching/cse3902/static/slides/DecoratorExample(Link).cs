namespace DecoratorExample
{
    interface ILink
    {
        void TakeDamage();
        void Update();
        
        // other methods...
    }

    class Link : ILink
    {
        ILinkState state;

        void TakeDamage()
        {
            state.TakeDamage();
        }

        void Update()
        {
            state.Update();
        }

	// other methods...
		
    }

    class DamagedLink : ILink
    {
		Game1 game;
        ILink decoratedLink;
        int timer = 1000;

	public DamagedLink (ILink decoratedLink, Game1 game)
	{
	     this.decoratedLink = decoratedLink;
		 this.game = game;
	}
		
        void TakeDamage()
        {
            // does not take damage
        }

        void Update()
        {
            timer--;
            if(timer == 0)
            {
                RemoveDecorator();
            }
			
	    decoratedLink.Update();
        }

        void RemoveDecorator()
        {
            game.Link = decoratedLink;
        }
		
	// other methods... (most make method calls on decoratedLink)
    }

}
