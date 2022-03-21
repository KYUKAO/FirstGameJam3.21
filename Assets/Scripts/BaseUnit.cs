using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : MonoBehaviour
{
    protected SpriteRenderer sp;
    public List<Sprite> FoxSprties;
    public int Level;
    void Start()
    {

    }

    void Update()
    {
        sp.sprite = FoxSprties[Level - 1];
    }
}
