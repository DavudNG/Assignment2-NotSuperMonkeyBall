using System.Collections;
using UnityEngine;

public class EnemyFrostBreathScript : MonoBehaviour
{
    //uses GameObject prefab "frost breath" to spawn the frost breath that freezes ball
    public GameObject frostBreath;
    public Transform breathSpawnPos;
    public float breathLength = 3;
    public float breathCooldown = 5;

    private bool attacking = false;

    void Start()
    {
        //starts coroutine when game is started
        StartCoroutine(BreathCycle());
    }

    IEnumerator BreathCycle()
    {
        //waits for cooldown, spawns frostbreath prefab, waits again.
        while (true)
        {
            yield return new WaitForSeconds(breathCooldown);
            GameObject breath = Instantiate(frostBreath, breathSpawnPos.position, Quaternion.Euler(0, 0, -90));
            attacking = true;
            yield return new WaitForSeconds(breathLength);

            //checks if the breath is there while attacking, if it is, destroys it to end attack.
            if (breath != null)
            {
                Destroy(breath);

            }

            attacking = false;
        }
    }
}
