+++
title = "Manual Animated Sprite"
+++

```c#
public void Draw(SpriteBatch spriteBatch, Vector2 location)
{
    Rectangle sourceRectangle;
    Rectangle destinationRectangle;
    
    if(currentFrame == 0)
    {
        sourceRectangle = new Rectangle(0, 0, 20, 20);
        destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 20, 20);
    }
    else if(currentFrame == 1)
    {
        sourceRectangle = new Rectangle(25, 0, 30, 20);
        destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 30, 20);
    }
    else if(currentFrame == 2)
    {
        sourceRectangle = new Rectangle(60, 0, 20, 20);
        destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 20, 20);
    }

    spriteBatch.Begin();
    spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
    spriteBatch.End();
}
```
