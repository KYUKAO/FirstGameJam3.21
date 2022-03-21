using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : MonoBehaviour
{
    protected SpriteRenderer sp;
    public int Level;

    protected void Awake()
    {
        sp = this.GetComponent<SpriteRenderer>();
        ChageAppearance();
    }
    public void ChageAppearance()
    {
        Sprite sprite1 = Resources.Load<Sprite>("Fox1");
        Sprite sprite2 = Resources.Load<Sprite>("Fox2");
        Sprite sprite3 = Resources.Load<Sprite>("Fox3");
        Sprite sprite4 = Resources.Load<Sprite>("Fox4");
        Sprite sprite5 = Resources.Load<Sprite>("Fox5");
        Sprite sprite6 = Resources.Load<Sprite>("Fox6");
        Sprite sprite7 = Resources.Load<Sprite>("Fox7");
        Sprite sprite8 = Resources.Load<Sprite>("Fox8");
        Sprite sprite9 = Resources.Load<Sprite>("Fox9");
        switch (Level)
        {
            case 1:
                sp.sprite = sprite1;
                return;
            case 2:
                sp.sprite = sprite2;
                return;
            case 3:
                sp.sprite = sprite3;
                return;
            case 4:
                sp.sprite = sprite4;
                return;
            case 5:
                sp.sprite = sprite5;
                return;
            case 6:
                sp.sprite = sprite6;
                return;
            case 7:
                sp.sprite = sprite7;
                return;
            case 8:
                sp.sprite = sprite8;
                return;
            case 9:
                sp.sprite = sprite9;
                return;
        }
    }

}
