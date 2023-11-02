using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarScript : MonoBehaviour
{
    public GameObject heartPrefab;

    List<HealthHeart> hearts = new List<HealthHeart> ();


    public void DrawHearts()
    {
        ClearHearts();
        float maxHealtRemainder
    }


    public void CreatEmptyHeart()
    {
        GameObject newHeart=Instantiate(heartPrefab);
        newHeart.transform.SetParent(transform);

        HealthHeart heartComponent=newHeart.GetComponent<HealthHeart>();
        heartComponent.SetHeartImage(HeartStatus.Empty);
        hearts.Add(heartComponent);
    }


    public void ClearHearts()
    {
        foreach (Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        hearts = new List<HealthHeart>();

    }
}
