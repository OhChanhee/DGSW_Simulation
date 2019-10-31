using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MessengerCall : Event
{
    public MessengerCall()
    {
        Priority =  1;
    }

    public override bool HasEvent()
    {
        CharacterManager instance = CharacterManager.Get_instance();
        return (!instance.hasTeam && instance.characterStat.programming > 500 && 
                instance.characterStat.sociability > 500 && new Random().Next(0, 3) == 0);
    }
}
