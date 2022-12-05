using System;

public class MineList
{
    public List<LVL2Mines> mines = new List<LVL2Mines>();

    public MineList(){
        mines.Add(new LVL2Mines{name = "mine"});
    }
}
