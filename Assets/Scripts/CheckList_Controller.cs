using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Toggle = UnityEngine.UI.Toggle;

public class CheckList_Controller : MonoBehaviour
{
    public GameObject outroPanel;
    public Toggle[] togglesGO;
    public int togglesActivated;
    public UnityEngine.UI.Button button;

    private void Update()
    {

        for (int i = 0; i < togglesGO.Length; i++)
        {
            if (togglesGO[i].isOn == true && togglesGO[i].interactable == true)
            {
                togglesActivated++;
                togglesGO[i].interactable = false;
                if (togglesActivated == togglesGO.Length)
                {
                    button.interactable = true;
                    break;
                }
            }
            else if (togglesActivated == togglesGO.Length)
            {
                button.interactable = true;
                break;
            }
        }
    }

    public void CheckToggles()
    {
        outroPanel.SetActive(true);
    }

}
