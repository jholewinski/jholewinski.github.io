+++
title = "Mini-Game With Objects"
+++

```c#
KeyboardController keyboardControls;
GamepadController gamepadControls;

StandingInPlacePlayerSprite standingInPlacePlayer;
RunningInPlacePlayerSprite runningInPlacePlayer;
DeadMovingUpAndDownPlayerSprite deadPlayerSprite;
RunningLeftAndRightPlayerSprite runningPlayerSprite;
int currentSprite = 0;

protected override void Initialize()
{
    keyboardControls = new KeyboardController();
    gamepadControls = new GamepadController();
}

protected override void LoadContent()
{
    standingInPlacePlayer = new StandingInPlacePlayerSprite();
    runningInPlacePlayer = new RunningInPlacePlayerSprite();
    deadPlayerSprite = new DeadMovingUpAndDownPlayerSprite();
    runningPlayerSprite = new RunningLeftAndRightPlayerSprite();
}

protected override void Update(GameTime gameTime)
{
    keyboardControls.Update();
    gamepadControls.Update();
    
    if(currentSprite == 0)
    {
        standingInPlacePlayer.Update();
    }
    else if(currentSprite == 1)
    {
        runningInPlacePlayerSprite.Update();
    }
    else if(currentSprite == 2)
    {
        deadPlayerSprite.Update();
    }
    else
    {
        runningPlayerSprite.Update();
    }
}
```
