
+++
title = "Mini-Game Without Interfaces"
+++

```c#
enum PlayerSpriteState {StandingInPlacePlayer, RunningInPlacePlayer, DeadPlayerMovingUpAndDown, RunningLeftAndRightPlayer };
PlayerSpriteState mySpriteState = PlayerSpriteState.StandingInPlacePlayer;
int currentFrame = 0;
int totalFrames = 1;
int yPos = 0;
int xPos = 0;
bool movingUp = false;
bool movingLeft = false;

protected override void Update(GameTime gameTime)
{
    if (GamePad.GetState(PlayerIndex.One).Buttons.Start == ButtonState.Pressed)
    {
        this.Exit();
    }
    else if (GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed)
    {
        mySpriteState = PlayerSpriteState.StandingInPlacePlayer;
        currentFrame = 0;
        totalFrames = 1;
        movingUp = false;
        movingLeft = false;
    }
    else if (GamePad.GetState(PlayerIndex.One).Buttons.B == ButtonState.Pressed)
    {
        mySpriteState = PlayerSpriteState.RunningInPlacePlayer;
        currentFrame = 0;
        totalFrames = 3;
        movingUp = false;
        movingLeft = false;
    }
    else if (GamePad.GetState(PlayerIndex.One).Buttons.X == ButtonState.Pressed)
    {
        mySpriteState = PlayerSpriteState.DeadPlayerMovingUpAndDown;
        currentFrame = 0;
        totalFrames = 1;
        movingUp = true;
        movingLeft = false;
    }	
    else if (GamePad.GetState(PlayerIndex.One).Buttons.Y == ButtonState.Pressed)
    {
        mySpriteState = PlayerSpriteState.RunningLeftAndRightPlayer;
        currentFrame = 0;
        totalFrames = 3;
        movingUp = false;
        movingLeft = true;
    }
    
    if (Keyboard.GetState().IsKeyDown(Keys.Q))
    {
        this.Exit();
    }
    else if (Keyboard.GetState().IsKeyDown(Keys.W))
    {
        mySpriteState = PlayerSpriteState.StandingInPlacePlayer;
        currentFrame = 0;
        totalFrames = 1;
        movingUp = false;
        movingLeft = false;
    }
    else if (Keyboard.GetState().IsKeyDown(Keys.E))
    {
        mySpriteState = PlayerSpriteState.RunningInPlacePlayer;
        currentFrame = 0;
        totalFrames = 3;
        movingUp = false;
        movingLeft = false;
    }
    else if (Keyboard.GetState().IsKeyDown(Keys.R))
    {
        mySpriteState = PlayerSpriteState.DeadPlayerMovingUpAndDown;
        currentFrame = 0;
        totalFrames = 1;
        movingUp = true;
        movingLeft = false;
    }	
    else if (Keyboard.GetState().IsKeyDown(Keys.T))
    {
        mySpriteState = PlayerSpriteState.RunningLeftAndRightPlayer;
        currentFrame = 0;
        totalFrames = 3;
        movingUp = false;
        movingLeft = true;
    }
    
    switch (mySpriteState)
    {
        case PlayerSpriteState.StandingInPlacePlayer:
            break;
        case PlayerSpriteState.RunningInPlacePlayer:
            currentFrame = (currentFrame + 1) % totalFrames;
            break;
        case PlayerSpriteState.DeadPlayerMovingUpAndDown:
            if (movingUp)
            {
                yPos -= 1;
                if(yPos == 0)
                    movingUp = false;
            }
            else
            {
                yPos += 1;
                if (yPos == 10)
                    movingUp = true;
            }
            break;
        case PlayerSpriteState.RunningLeftAndRightPlayer:
            currentFrame = (currentFrame + 1) % totalFrames;
            if(movingLeft)
            {
                xPos -= 1;
                if(xPos == 0)
                    movingLeft = false;
            }
            else
            {
                xPos += 1;
                if (xPos == 10)
                    movingLeft = true;
            }
            break;
    }
}
```
