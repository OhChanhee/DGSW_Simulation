using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Birthday : Event
{
    public override bool HasEvent()
    {
        CharacterManager instance = CharacterManager.Get_instance();
        Gamedate curdate = instance.curdate;
        Gamedate birthday = instance.birthday;
        return (curdate.dateTime.Month == birthday.dateTime.Month && curdate.week == birthday.week);
    }
}