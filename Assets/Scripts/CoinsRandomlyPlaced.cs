using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinsRandomlyPlaced : MonoBehaviour
{
    [SerializeField] 
    private Player player;
    private Collider2D playerCollider;
    [SerializeField]
    private float delayForCoins;  

    [SerializeField]
    private SpawnPoints spawnPoints;
    
    int[] lastSpawns = new int[3];
    private int lastPos = 0;

    
    
    void Start()
    {
       playerCollider = player.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Player>())
        {
            int randPos = Random.Range(0, 10);
            transform.position = new Vector2(0, 0);
            
            if (randPos == lastPos)
            {
                randPos = Random.Range(0,10);
            }
            

            StartCoroutine(DelayCoinSpawning(delayForCoins, randPos));
            //Debug.Log($"Coin is now in {randPos}");
            
            lastPos = randPos;

        }
    }

    private IEnumerator DelayCoinSpawning(float delay, int randPos)
    {
         yield return new WaitForSeconds(delay);

        switch (randPos)
        {
            case 0:
                transform.position = spawnPoints.FirstSpawn.position;
                break;
            case 1:
                transform.position = spawnPoints.SecondSpawn.position;
                break;
            case 2:
                transform.position = spawnPoints.ThirdSpawn.position;
                break;
            case 3:
                transform.position = spawnPoints.FourthSpawn.position;
                break;
            case 4:
                transform.position = spawnPoints.FifthSpawn.position;
                break;
            case 5:
                transform.position = spawnPoints.SixthSpawn.position;
                break;
            case 6:
                transform.position = spawnPoints.SeventhSpawn.position;
                break;
            case 7:
                transform.position = spawnPoints.EightSpawn.position;
                break;
            case 8:
                transform.position = spawnPoints.NinethSpawn.position;
                break;
            case 9:
                transform.position = spawnPoints.TenthSpawn.position;
                break;
            /*case 10:
                transform.position = spawnPoints.EleventhSpawn.position;
                break;
            case 11:
                transform.position = spawnPoints.TwelfthSpawn.position;
                break;
            case 12:
                transform.position = spawnPoints.ThirteenthSpawn.position;
                break;
            case 13:
                transform.position = spawnPoints.FourthSpawn.position;
                break;
            case 14:
                transform.position = spawnPoints.FifteenthSpawn.position;
                break;*/
        }

    }
}

[System.Serializable]   
public class SpawnPoints
{
     [SerializeField] private Transform firstSpawn;
     [SerializeField] private Transform secondSpawn;
     [SerializeField] private Transform thirdSpawn;
     [SerializeField] private Transform fourthSpawn;
     [SerializeField] private Transform fifthSpawn;
     [SerializeField] private Transform sixthSpawn;
     [SerializeField] private Transform seventhSpawn;
     [SerializeField] private Transform eightSpawn;
     [SerializeField] private Transform ninethSpawn;
     [SerializeField] private Transform tenthSpawn;
     /*[SerializeField] private Transform eleventhSpawn;
     [SerializeField] private Transform twelfthSpawn;
     [SerializeField] private Transform thirteenthSpawn;
     [SerializeField] private Transform fourteenthSpawn;
     [SerializeField] private Transform fifteenthSpawn;*/

     public Transform FirstSpawn => firstSpawn;
     public Transform SecondSpawn => secondSpawn;
     public Transform ThirdSpawn => thirdSpawn;
     public Transform FourthSpawn => fourthSpawn;
     public Transform FifthSpawn => fifthSpawn;
     public Transform SixthSpawn => sixthSpawn;
     public Transform SeventhSpawn => seventhSpawn;
     public Transform EightSpawn => eightSpawn;
     public Transform NinethSpawn => ninethSpawn;
     public Transform TenthSpawn => tenthSpawn;
     /*public Transform EleventhSpawn => eleventhSpawn;
     public Transform TwelfthSpawn => twelfthSpawn;
     public Transform ThirteenthSpawn => thirteenthSpawn;
     public Transform FifteenthSpawn => fifteenthSpawn;*/
}



