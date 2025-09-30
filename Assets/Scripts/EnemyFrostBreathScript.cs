using System.Collections;
using UnityEngine;

public class EnemyFrostBreathScript : MonoBehaviour
{
    public GameObject frostBreath;
    public Transform breathSpawnPos;
    public float breathLength = 3;
    public float breathCooldown = 5;

    private bool attacking = false;

    void Start()
    {
        StartCoroutine(BreathCycle());
    }

    IEnumerator BreathCycle()
    {
        while (true)
        {
            yield return new WaitForSeconds(breathCooldown);
            GameObject breath = Instantiate(frostBreath, breathSpawnPos.position, Quaternion.Euler(0,0,-90));
            attacking = true;
            yield return new WaitForSeconds(breathLength);

            if (breath != null)
            {
                Destroy(breath);

            }

            attacking = false;
        }
    }
}
