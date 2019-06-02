using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    [HideInInspector]
    public bool IsFireActivated;
    [HideInInspector]
    public bool IsForceActivated;
    [HideInInspector]
    public bool IsRainyCloudActivated;

    public Button FireButton;
    public Button ForceButton;
    public Button RainyCloudButton;

    void FixedUpdate()
    {
        IsFireActivated = FireButton.interactable;
        IsForceActivated = ForceButton.interactable;
        IsRainyCloudActivated = RainyCloudButton.interactable;
    }
}
