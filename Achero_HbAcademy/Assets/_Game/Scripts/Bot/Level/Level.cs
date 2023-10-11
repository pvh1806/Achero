using UnityEngine;
using UnityEngine.AI;

public class Level : MonoBehaviour
{
    [SerializeField] private Transform minPoint,maxPoint;
    [SerializeField] private Bot botFarPrefab,botHitPrefab,bossPrefab;
    private int amountBotFar = 0;
    private int amountBoss = 1;
    private int amountBotHit = 10;
    public int amountTotal = 11;

    public void OnInit()
    {
        for (int i = 0; i < amountBotFar; i++)
        {
            Bot botSpawn = Instantiate(botFarPrefab, GetRandomPosition(),Quaternion.identity);
            botSpawn.OnInit();
            botSpawn.ChangeState(new IdleState());
        }
        for (int i = 0; i < amountBotHit; i++)
        {
            Bot botSpawn = Instantiate(botHitPrefab, GetRandomPosition(),Quaternion.identity);
            botSpawn.OnInit();
            botSpawn.ChangeState(new IdleState());
        }
        for (int i = 0; i < amountBoss; i++)
        {
            Bot botSpawn = Instantiate(bossPrefab, GetRandomPosition(),Quaternion.identity);
            botSpawn.OnInit();
            botSpawn.ChangeState(new IdleState());
        }
    }
    public Vector3 GetRandomPosition()
    {   
        Vector3 randPoint = Random.Range(minPoint.position.x, maxPoint.position.x) * Vector3.right + Random.Range(minPoint.position.z, maxPoint.position.z) * Vector3.forward;

        NavMeshHit hit;

        NavMesh.SamplePosition(randPoint, out hit, float.PositiveInfinity, 1);

        return hit.position;
    }
}
