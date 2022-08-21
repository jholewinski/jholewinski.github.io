public interface IGoombaState
{
	void ChangeDirection();
	void BeStomped();
	void BeFlipped();
	void Update();
	// Draw() might also be included here
}

public class Goomba
{
	public IGoombaState state;
	
	public Goomba()
	{
		state = new LeftMovingGoombaState(this);
	}
	
	public void ChangeDirection()
	{
		state.ChangeDirection();
	}
	
	public void BeStomped()
	{
		state.BeStomped();
	}
	
	public void BeFlipped()
	{
		state.BeFlipped();
	}

	// Draw and other methods omitted
}

public class LeftMovingGoombaState : IGoombaState
{
	private Goomba goomba;
	
	public LeftMovingGoombaState(Goomba goomba)
	{
		this.goomba = goomba;
		// construct goomba's sprite here too
	}
	
	public void ChangeDirection()
	{
		goomba.state = new RightMovingGoombaState(goomba);
	}
	
	public void BeStomped()
	{
		goomba.state = new LeftMovingStompedGoombaState(goomba);	
	}
	
	public void BeFlipped()
	{
		goomba.state = new FlippedGoombaState(goomba);
	}
	
	public void Update()
	{
		// call something like goomba.MoveLeft() or goomba.Move(-x,0);
	}
}

public class LeftMovingStompedGoombaState : IGoombaState
{
	private Goomba goomba;
	
	public LeftMovingStompedGoombaState(Goomba goomba)
	{
		this.goomba = goomba;
		// construct goomba's sprite here too
	}
	
	public void ChangeDirection()
	{
		goomba.state = new RightMovingStompedGoombaState(goomba);
	}
	
	public void BeStomped()
	{
		// NO-OP
		// already stomped, do nothing
	}
	
	public void BeFlipped()
	{
		// NO-OP
		// if stomped, do not respond to being attacked by star mario (assumed but not tested behavior)
	}
	
	public void Update()
	{
		// call something like goomba.MoveLeft() or goomba.Move(-x,0);
	}
}
