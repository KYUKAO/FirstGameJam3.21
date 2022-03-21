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

    public Transform point1;
    public Transform point2;
    public Transform point3;
    public Transform point4;
    public Transform point5;
    public List<Transform> FoodPoints = new List<Transform>();
    public GameObject EnemyPrefab;

    Transform enemyTransform;
    Transform foodTransform;
    private void Start()
    {
        FoodPoints.Add(point1);
        FoodPoints.Add(point2);
        FoodPoints.Add(point3);
        FoodPoints.Add(point4);
        FoodPoints.Add(point5);
    }
    void Update()
    {
        if (CurrentNumOfEnemy < NumOfEnemy)
        {
            int rand = Random.Range(0,5);
            foodTransform = FoodPoints[rand];
            Instantiate(EnemyPrefab, foodTransform.position,this.transform.rotation);
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
