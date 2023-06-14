using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; } //ENCAPSULATION, auto-implemented property
    public int vehicleIndex;

    void Awake()
    {
        //default settings
        vehicleIndex = 0;

        //Istilahnya pola singleton, yaitu memastikan hanya boleh 1 instance GameManager yang boleh ada, jadi perannya si 1 instance ini sebagai pusat akses
        if (instance != null) //pas masuk StartMenu, kalo ternyata sudah ada GameManager yang sebelumnya, maka akan Destroy GameManager yang baru
        {
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Game Manager created"); //info to whether has been created or not
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }
}
