using UnityEngine;

public class FlameableObject : MonoBehaviour
{
    public float BurningTime = 2f;
    public bool IsOnFire = false;
    private float _colorChange = 0;

    void Update()
    {
        if (IsOnFire)
        {
            Renderer rend = GetComponent<Renderer>();
            BurningTime -= Time.deltaTime;
            if (_colorChange < 1)
            {
                _colorChange += Time.deltaTime / BurningTime;
            }

            rend.material.shader = Shader.Find("_Color");
            rend.material.color = Color.Lerp(Color.green, Color.red, _colorChange);
            rend.material.shader = Shader.Find("Specular");
            rend.material.color = Color.Lerp(Color.green, Color.red, _colorChange);

            if (BurningTime <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
