using System.Collections.Generic;
using System.Linq;
using BreakInfinity;

public class Data
{
    public BigDouble neutrons;
    
    public List<BigDouble> clickUpgradeLevel;

    public Data()
    {
        neutrons = 10;

        clickUpgradeLevel = new BigDouble[3].ToList();
    }
}
