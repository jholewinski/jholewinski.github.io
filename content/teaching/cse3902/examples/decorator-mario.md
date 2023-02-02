+++
title = "Decorator Example for Mario"
+++

```c#
namespace DecoratorExample
{
    interface IMario
    {
        void TakeDamage();
        void Update();
        
        // other methods...
    }

    class Mario : IMario
    {
        IMarioState state;

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

    class StarMario : IMario
    {
        IMario decoratedMario;
        int timer = 1000;

	public StarMario (IMario decoratedMario)
	{
	     this.decoratedMario = decoratedMario;
	}
		
        void TakeDamage()
        {
            // StarMario does not take damage
        }

        void Update()
        {
            timer--;
            if(timer == 0)
            {
                RemoveStar();
            }
			
	    decoratedMario.Update();
        }

        void RemoveStar()
        {
            Game1Singleton.Instance.mario = decoratedMario;
        }
		
	// other methods... (most make method calls on decoratedMario)
    }

}
```
