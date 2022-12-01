using System;

public class KitchenMobileElementTest
{
	public  MoveLeftTest()
	{
		Chef chef = new Chef();
		chef.MoveTo();
		Assert.IsNotNull(chef.MoveTo);
	}

    public MoveRightTest()
    {
        Chef chef = new Chef();
        chef.MoveTo();
        Assert.IsNotNull(chef.MoveTo);
    }

}
