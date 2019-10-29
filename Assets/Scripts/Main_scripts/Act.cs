using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

public class Act
{
    public Act() { }

    public Act(Act act)
    {
        Title = string.Copy(act.Title);
        Description = string.Copy(act.Description);
        Category = act.Category;
        Name = string.Copy(act.Name);
        Changement = act.Changement.clone;
        IsEvent = act.IsEvent;
    }

    public Act(Acting acting)
    {
        Title = string.Copy(acting.Title.text);
        Description = string.Copy(acting.Description.text);
        Category = acting.category;
        Name = string.Copy(acting.actName);
        Changement = acting.Changement.clone;
        IsEvent = acting.IsEvent;
    }

    public string Title
    {
        get;
        set;
    }

    public string Description
    {
        get;
        set;
    }

    public eCategory Category
    {
        get;
        set;
    }

    public string Name
    {
        get;
        set;
    }

    public CharacterStat Changement
    {
        get;
        set;
    }

    public bool IsEvent
    {
        get;
        set;
    }


    public Act clone
    {
        get
        {
            Act clone = new Act();

            PropertyInfo[] properties = typeof(Act).GetProperties();

            foreach(PropertyInfo property in properties)
            {
                if (property.SetMethod == null) continue;

                property.SetValue(clone, property.GetValue(this));
            }

            return clone;
        }
    }

}
