using System.Collections.Generic;
using BreakInfinity;

public class Data
{
    public BigDouble neutrons;
    
    public List<BigDouble> clickUpgradeLevel;

    public Data()
    {
        neutrons = 10;

        clickUpgradeLevel = Methods.CreateList<BigDouble>(3);
    }
}
