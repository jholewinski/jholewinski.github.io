+++
title = "Set Dead Player Sprite Command"
+++

```c#
public class SetDeadPlayerSpriteCommand:ICommand
{
    private Game1 myGame;
    
    public SetDeadPlayerSpriteCommand(Game1 game)
    {
        myGame = game;
    }

    public void Execute()
    {
        myGame.sprite = new DeadPlayerSprite(); // tighter coupling
        
        myGame.setSprite(new DeadPlayerSprite()); // looser coupling 
    }
}
```