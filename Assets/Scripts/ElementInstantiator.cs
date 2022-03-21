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

    public Transform point6;
    public Transform point7;
    public Transform point8;
    public List<Transform> FoodPoints = new List<Transform>();
    public List<Transform> EnemyPoints = new List<Transform>();
    public GameObject EnemyPrefab;

    Transform enemyTransform;
    Transform foodTransform;
    int serialNumber = 0;
    private void Start()
    {
        FoodPoints.Add(point1);
        FoodPoints.Add(point2);
        FoodPoints.Add(point3);
        FoodPoints.Add(point4);
        FoodPoints.Add(point5);

        EnemyPoints.Add(point6);
        EnemyPoints.Add(point7);
        EnemyPoints.Add(point8);
    }
    void Update()
    {
        if (CurrentNumOfEnemy < NumOfEnemy)
        {
            int rand = Random.Range(0, 5);
            enemyTransform = FoodPoints[rand];
            Instantiate(EnemyPrefab, enemyTransform.position,this.transform.rotation);
            CurrentNumOfEnemy++;
        }
        if (CurrentNumOfFood < NumOfFood)
        {
            int rand = Random.Range(0, 5);
            foodTransform = FoodPoints[rand];
            Instantiate(FoodTypes[serialNumber], foodTransform.position, this.transform.rotation);
            serialNumber++;
            if (serialNumber >= 4)
            {
                serialNumber = 0;
            }
            CurrentNumOfFood++;
        }
    }
}
