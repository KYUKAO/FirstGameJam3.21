using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementInstantiator : MonoBehaviour
{
    public List<FoodComponent> FoodTypes = new List<FoodComponent>();
    public static int CurrentNumOfEnemy;
    public static int CurrentNumOfFood;
    public int NumOfEnemy;
    public int NumOfFood;

    public Transform point1;
    public Transform point2;
    public Transform point3;
    public Transform point4;
    public Transform point5;
    public Transform point9;

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
        CurrentNumOfEnemy = 0;
        CurrentNumOfFood = 0;
        Time.timeScale = 1;
        FoodPoints.Add(point1);
        FoodPoints.Add(point2);
        FoodPoints.Add(point3);
        FoodPoints.Add(point4);
        FoodPoints.Add(point5);
        FoodPoints.Add(point9);

        EnemyPoints.Add(point6);
        EnemyPoints.Add(point7);
        EnemyPoints.Add(point8);
    }
    void Update()
    {
        if (CurrentNumOfEnemy < NumOfEnemy)
        {
            int rand = Random.Range(0, 2);
            enemyTransform = FoodPoints[rand];
            Instantiate(EnemyPrefab, enemyTransform.position, this.transform.rotation);
            CurrentNumOfEnemy++;
        }
        if (CurrentNumOfFood < NumOfFood)
        {
            int rand = Random.Range(0, 5);
            foodTransform = FoodPoints[rand];
            int randNumber = Random.Range(0, 100);
            if (randNumber < 30)
            {
                serialNumber = 0;
            }
            else if (randNumber < 50)
            {
                serialNumber = 1;
            }
            else if (randNumber < 70)
            {
                serialNumber = 2;
            }
            else
            {
                serialNumber = 3;
            }
            Instantiate(FoodTypes[serialNumber], foodTransform.position, this.transform.rotation);
            CurrentNumOfFood++;
        }
    }
}
