+++
title = "Mini-Game With Interfaces"
+++

```c#
List<IController> controllerList;
ISprite sprite;
		
protected override void Initialize()
{
	controllerList = new List<object>;
	controllerList.Add(new KeyboardController(this));
	controllerList.Add(new GamepadController(this));
}

protected override void LoadContent()
{
	sprite = new StandingInPlacePlayerSprite();
}
		
protected override void Update(GameTime gameTime)
{
    foreach(IController controller in controllerList)
    {
        controller.Update();
    }

    sprite.Update();
}
```
