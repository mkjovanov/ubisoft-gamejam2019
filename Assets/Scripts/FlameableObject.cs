using UnityEngine;

public class FlameableObject : MonoBehaviour
{
    public float BurningTime = 2f;
    public bool IsOnFire = false;
    public bool progressionTrigger = false;
    public GameObject FireObject;
    private bool firesSpawned = false;
    private float _colorChange = 0;

    void Update()
    {
        if (IsOnFire)
        {
            if (!firesSpawned)
            {
                Instantiate(FireObject, transform.position + transform.up * 5, Quaternion.identity);
                firesSpawned = true;
            }
            Renderer rend = GetComponent<Renderer>();
            BurningTime -= Time.deltaTime;
            if (_colorChange < 1)
            {
                _colorChange += Time.deltaTime / BurningTime;
            }

            //rend.material.shader = Shader.Find("_Color");
            //rend.material.color = Color.Lerp(Color.green, Color.red, _colorChange);
            //rend.material.shader = Shader.Find("Specular");
            //rend.material.color = Color.Lerp(Color.green, Color.red, _colorChange);

            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z * .99f);

            if (BurningTime <= 0)
            {
                if (progressionTrigger)
                {
                    foreach (PersonMovement person in FindObjectsOfType<PersonMovement>())
                    {
                        person.nextTarget();
                    }
                }
                
                Destroy(gameObject);
            }
        }
    }
}
