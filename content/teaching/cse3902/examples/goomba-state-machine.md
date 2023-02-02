+++
title = "Goomba State Machine"
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
    private bool facingLeft = true;
    private enum GoombaHealth {Normal, Stomped, Flipped };
    private GoombaHealth health = GoombaHealth.Normal;
    
    public void ChangeDirection()
    {
        facingLeft = !facingLeft;
    }
    
    public void BeStomped()
    {
        if(health != GoombaHealth.Stomped)	// Note: the if is needed so we only do the transition once
        {
            health = GoombaHealth.Stomped;
            // Compute and construct goomba sprite - requires if-else logic with value of health
        }
    }
    
    public void BeFlipped()
    {
        if(health != GoombaHealth.Flipped)	// Note: the if is needed so we only do the transition once
        {
            health = GoombaHealth.Flipped;
            // Compute and construct goomba sprite - requires if-else logic with value of health
        }
    }
    
    public void Update()
    {
        // if-else logic based on the current values of facingLeft and health to determine how to move
    }
}
```