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
        BirthdayDate birthday = instance.birthday;
        return (curdate.dateTime.Month == birthday.gamedate.dateTime.Month && (curdate.week == birthday.gamedate.week - 1 || curdate.week == birthday.gamedate.week) && instance.birthday.grade == instance.grade);
    }
}