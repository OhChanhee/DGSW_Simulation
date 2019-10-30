using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Hospital : Event
{
    public Hospital()
    {
        Priority = 1;
    }

    public override bool HasEvent()
    {
        return (CharacterManager.Get_instance().characterStat.hp <= 0);
    }
}
