using System.Collections;
using System.Collections.Generic;
using Core.Game;
using UnityEngine;
using Zenject;
using Zenject.Asteroids;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject enemyBossPrefab;

    [Inject] private LevelHandler _levelHandler;


    public GameObject CreateNewEnemy()
    {
        if (IsDivisibleByTen(_levelHandler.CurrentLevel.Value))
        {
            return CreateBoss();
        }
        else
        {
            return CreateEnemy();
        }
    }

    private GameObject CreateEnemy()
    {
        Debug.Log("Обычный враг");
        return enemyPrefab;
    }

    private GameObject CreateBoss()
    {
        Debug.Log("Враг-Босс");

        return enemyBossPrefab;
    }

    private bool IsDivisibleByTen(int number)
    {
        return number % 10 == 0;
    }
    
}
