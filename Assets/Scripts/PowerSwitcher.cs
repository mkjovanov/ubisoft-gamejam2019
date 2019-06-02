using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PowerSwitcher : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var d = Input.mouseScrollDelta;
        var powerBtns = gameObject.GetComponentsInChildren<Button>();
        var hasMultiplePowers = powerBtns.Length != 1 && powerBtns.Length != 0;
        if((d.y > 0f || d.y < 0f) && hasMultiplePowers)
        {
            var activePwr = powerBtns.First(x => x.IsInteractable());

            if(d.y > 0f)
            {
                if (activePwr == powerBtns.First())
                {
                    powerBtns.Last().interactable = true;
                }
                else
                {
                    int index = powerBtns.ToList().FindIndex(x => x.name == activePwr.name);
                    powerBtns[index - 1].interactable = true;
                }
            }
            else if (d.y < 0f)
            {
                if (activePwr == powerBtns.Last())
                {
                    powerBtns.First().interactable = true;
                }
                else
                {
                    int index = powerBtns.ToList().FindIndex(x => x.name == activePwr.name);
                    powerBtns[index + 1].interactable = true;
                }
            }
            activePwr.interactable = false;
        }
    }
}
