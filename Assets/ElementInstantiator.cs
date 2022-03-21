using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementInstantiator : MonoBehaviour
{
    public List<FoodComponent> FoodTypes = new List<FoodComponent>();
    public int CurrentNumOfEnemy;
    public int CurrentNumOfFood;
    public  int NumOfEnemy;
    public  int NumOfFood;

    public GameObject EnemyPrefab;

    void Update()
    {
        if (CurrentNumOfEnemy < NumOfEnemy)
        {
            Instantiate(EnemyPrefab, this.transform.position,this.transform.rotation);
            CurrentNumOfEnemy++;
        }
        if (CurrentNumOfFood < NumOfFood)
        {
            var serialNumber = Random.Range(0, 4);
            Instantiate(FoodTypes[serialNumber], this.transform.position, this.transform.rotation);
            CurrentNumOfFood++;
        }
    }
}
