using System.Collections;
using UnityEngine;

public class EnemyTraper : MonoBehaviour
{
    [SerializeField]
    private int maxTraps = 5;
    [SerializeField]
    private int currentTraps;
    [SerializeField]
    private GameObject trapPrefab;
    [SerializeField]
    private float cooldownCounter = 20f;
    [SerializeField]
    private SpawnPointsForEnemy SpawnPointsForEnemy;


    private float initialCooldown;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Start()
    {
      initialCooldown = cooldownCounter;
    }
    void Update()
    {
        if (cooldownCounter > 0)
        {
            cooldownCounter -= Time.deltaTime;
            Debug.Log("Cooldown: " + cooldownCounter);
        }
        if (cooldownCounter <= 0)
        {
            int randPos = Random.Range(0, 15);
            TrapSpawning(randPos);
            Instantiate(trapPrefab, transform.position, Quaternion.identity);
            cooldownCounter = initialCooldown;
            Debug.Log("Trap placed. Cooldown reset.");
        }
    }

    private Transform TrapSpawning(int randPos)
    {

        switch (randPos)
        {
            case 0:
                transform.position = SpawnPointsForEnemy.FirstSpawn.position;
                break;
            case 1:
                transform.position = SpawnPointsForEnemy.SecondSpawn.position;
                break;
            case 2:
                transform.position = SpawnPointsForEnemy.ThirdSpawn.position;
                break;
            case 3:
                transform.position = SpawnPointsForEnemy.FourthSpawn.position;
                break;
            case 4:
                transform.position = SpawnPointsForEnemy.FifthSpawn.position;
                break;
            case 5:
                transform.position = SpawnPointsForEnemy.SixthSpawn.position;
                break;
            case 6:
                transform.position = SpawnPointsForEnemy.SeventhSpawn.position;
                break;
            case 7:
                transform.position = SpawnPointsForEnemy.EightSpawn.position;
                break;
            case 8:
                transform.position = SpawnPointsForEnemy.NinethSpawn.position;
                break;
            case 9:
                transform.position = SpawnPointsForEnemy.TenthSpawn.position;
                break;
            case 10:
                transform.position = SpawnPointsForEnemy.EleventhSpawn.position;
                break;
            case 11:
                transform.position = SpawnPointsForEnemy.TwelfthSpawn.position;
                break;
            case 12:
                transform.position = SpawnPointsForEnemy.ThirteenthSpawn.position;
                break;
            case 13:
                transform.position = SpawnPointsForEnemy.FourthSpawn.position;
                break;
            case 14:
                transform.position = SpawnPointsForEnemy.FifteenthSpawn.position;
                break;
        }
        return null;
    }
}

[System.Serializable]
public class SpawnPointsForEnemy
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
        [SerializeField] private Transform eleventhSpawn;
        [SerializeField] private Transform twelfthSpawn;
        [SerializeField] private Transform thirteenthSpawn;
        [SerializeField] private Transform fourteenthSpawn;
        [SerializeField] private Transform fifteenthSpawn;

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
        public Transform EleventhSpawn => eleventhSpawn;
        public Transform TwelfthSpawn => twelfthSpawn;
        public Transform ThirteenthSpawn => thirteenthSpawn;
        public Transform FifteenthSpawn => fifteenthSpawn;
}
