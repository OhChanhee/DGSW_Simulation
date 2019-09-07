using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;
using System;
public class Show_Data : MonoBehaviour
{
    
    // 캐릭터 정보
    public Text playerName;
    public DateTime birthday;
    public Text year;
    public Text month;
    public Text Week;
    public Text personality;
    public Text Money;

    // 캐릭터의 스탯
    public Text hp;
    public Text sociability;
    public Text intelligence;
    public Text sensibility;
    public Text charm;
    public Text fatigue;
    public Text stress;
    public Text programming;
    public Text music;
    public Text design;
    public Text exercise;
    public Text creative;
    public Text leadership;
    public Text rewardPoint;

    // 달력 정보(날짜)
    public Text Cal_year;
    public Text Cal_month;

    public delegate void Method();
    public Method updateData;

    // Start is called before the first frame update
    void Start()
    {
        updateData = delegate ()
        {
            playerName.text = CharacterManager.Get_instance().playerName;
            year.text = CharacterManager.Get_instance().curdate.dateTime.Year.ToString();
            month.text = CharacterManager.Get_instance().curdate.dateTime.Month.ToString();
            Week.text = String.Format("{0}", CharacterManager.Get_instance().curdate.week);
            personality.text = CharacterManager.Get_instance().personality.ToString();
            Money.text = CharacterManager.Get_instance().Money.ToString();

            hp.text = String.Format("HP:{0}", CharacterManager.Get_instance().characterStat.hp);
            sociability.text = String.Format("사회성:{0}", CharacterManager.Get_instance().characterStat.sociability);
            intelligence.text = String.Format("지능:{0}", CharacterManager.Get_instance().characterStat.intelligence);
            sensibility.text = String.Format("감수성:{0}", CharacterManager.Get_instance().characterStat.sensibility);
            charm.text = String.Format("매력:{0}", CharacterManager.Get_instance().characterStat.charm);
            fatigue.text = String.Format("피로:{0}", CharacterManager.Get_instance().characterStat.fatigue);
            stress.text = String.Format("스트레스:{0}", CharacterManager.Get_instance().characterStat.stress);
            programming.text = String.Format("프로그래밍:{0}", CharacterManager.Get_instance().characterStat.programming);
            music.text = String.Format("음악:{0}", CharacterManager.Get_instance().characterStat.music);
            design.text = String.Format("디자인:{0}", CharacterManager.Get_instance().characterStat.design);
            exercise.text = String.Format("운동:{0}", CharacterManager.Get_instance().characterStat.exercise);
            creative.text = String.Format("창의력:{0}", CharacterManager.Get_instance().characterStat.creative); ;
            leadership.text = String.Format("리더쉽:{0}", CharacterManager.Get_instance().characterStat.leadership);
            rewardPoint.text = String.Format("상/벌점:{0}", CharacterManager.Get_instance().characterStat.rewardPoint);

            Cal_year.text = CharacterManager.Get_instance().curdate.dateTime.Year.ToString();
            Cal_month.text = CharacterManager.Get_instance().curdate.dateTime.Month.ToString();
           
            updateData = delegate ()
            {

            };
        };
    }

    // Update is called once per frame
    void Update()
    {
        updateData();
    }
}
