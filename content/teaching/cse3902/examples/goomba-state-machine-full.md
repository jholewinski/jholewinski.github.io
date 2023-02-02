+++
title = "Goomba State Machine Example (Full)"
+++

```c#
public class Goomba
{
    private GoombaStateMachine stateMachine;
    
    public Goomba()
    {
        stateMachine = new GoombaStateMachine();
    }
    
    public void ChangeDirection()
    {
        stateMachine.ChangeDirection();
    }
    
    public void BeStomped()
    {
        stateMachine.BeStomped();
    }
    
    public void BeFlipped()
    {
        stateMachine.BeFlipped();
    }

    // Draw and other methods omitted
}

public class GoombaStateMachine
{
    private enum GoombaState {LeftNormal, RightNormal, LeftStomped, RightStomped, Flipped };
    private GoombaState currentState = GoombaState.LeftNormal;
    // other state machines might make use of a previousState field
    
    public void ChangeDirection()
    {
        switch(currentState)
        {
            case LeftNormal:
                currentState = RightNormal;
                break;
            case RightNormal:
                currentState = LeftNormal;
                break;
            case LeftStomped:
                currentState = RightStomped;
                break;
            case RightStomped:
                currentState = LeftStomped;
                break;
            // No need for a case for Flipped, it does not move left/right
        }
        
    }
    
    public void BeStomped()
    {
        switch(currentState)
        {
            case LeftNormal:
                currentState = LeftStomped;
                // Construct a stomped goomba sprite
                break;
            case RightNormal:
                currentState = RightStomped;
                // Construct a stomped goomba sprite
                break;
            // No need for other 3 cases, stomped and flipped states do not transition
        }
    }
    
    public void BeFlipped()
    {
        if(currentState != GoombaState.Flipped)	// the if is needed so we only do the transition once
        {
            currentState = GoombaState.Flipped;
            // Construct a flipped goomba sprite
        }
    }
    
    public void Update()
    {
        // switch statement with 3-5 cases
    }
}
```
