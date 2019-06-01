using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt : MonoBehaviour
{
    public float maxBoldWidth = 4;

    public bool testOnSpace;

    void Update()
    {
        if (testOnSpace && Input.GetKeyDown(KeyCode.Space))
            Opizdi(Vector3.up * 10, Vector3.zero);
    }

    Vector3 target;

    IEnumerator Opizdiing()
    {
        Vector3 endPoint = target;

        Vector3 startPoint = transform.position;
        Vector3 diff = endPoint - startPoint;

        Vector3 right = Vector3.Cross(diff.normalized, Vector3.forward);

        int ct = 10;
        for (int i = 1; i < ct - 1; i++)
        {
            yield return null;
            Vector3 pos = startPoint + diff * ((float)i / ct) + right * Random.value * maxBoldWidth;
            transform.position = pos;
        }

        transform.position = startPoint + diff;
    }

    public void Opizdi(Vector3 from, Vector3 to)
    {
        var t = GetComponent<TrailRenderer>();
        t.Clear();
        transform.position = from;
        t.Clear();
        target = to;
        StartCoroutine(Opizdiing());
    }

    void Opizdi()
    {
        StartCoroutine(Opizdiing());
    }
}
