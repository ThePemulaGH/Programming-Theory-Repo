using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class TitleScreenHandler : MonoBehaviour //INHERITANCE, default from unity though ^^
{
    public TextMeshProUGUI vehicleSelectionDText;
    public int vehicleIndex;
    public string[] vehicleName;

    // Start is called before the first frame update
    void Start()
    {
        vehicleIndex = GameManager.instance.vehicleIndex;
        UpdateSelectionVehicle();
    }

    public void SwitchRight()
    {
        vehicleIndex++;
        UpdateSelectionVehicle(); //ABSTRACTION
    }
    public void SwitchLeft() 
    {
        vehicleIndex--;
        UpdateSelectionVehicle(); //ABSTRACTION
    }

    void UpdateSelectionVehicle()
    {
        if (vehicleIndex > vehicleName.Length - 1) //Length - 1 because the last index != Length
        {
            vehicleIndex = 0;
        }
        else if (vehicleIndex < 0) vehicleIndex = vehicleName.Length - 1; //Length - 1 will select the last index
        vehicleSelectionDText.text = vehicleName[vehicleIndex]; //changing the text
        GameManager.instance.vehicleIndex = vehicleIndex;
    }

    public void GoToMainGameplay()
    {
        SceneManager.LoadScene(1); //go to Main Gameplay Scene
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode(); //code to exit play mode in Unity Editor
#else
        		Application.Quit(); //Original code to quit Unity player
#endif
    }
}
