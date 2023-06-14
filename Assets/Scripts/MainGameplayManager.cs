using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGameplayManager : MonoBehaviour
{
    public float boundaries = 335.46f;
    public GameObject treePrefab;
    public GameObject[] vehiclePrefabs;
    public int treeToSummon = 1;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < treeToSummon; i++)
        {
            //create trees
            Instantiate(treePrefab, GenerateRandomPos(), treePrefab.transform.rotation);
        }

        if (GameManager.instance != null)
        {
            //create a vehicle based on the selection from previous scene
            Instantiate(vehiclePrefabs[GameManager.instance.vehicleIndex], GenerateRandomPos(2f), vehiclePrefabs[GameManager.instance.vehicleIndex].transform.rotation);
        }
    }

    Vector3 GenerateRandomPos() //method overload
    {
        return new Vector3(Random.Range(-boundaries, boundaries), -0.18f, Random.Range(-boundaries, boundaries));
    }

    Vector3 GenerateRandomPos(float yPos) //method overload
    {
        return new Vector3(Random.Range(-boundaries, boundaries), yPos, Random.Range(-boundaries, boundaries));
    }

    public void GoToTitleScreen()
    {
        SceneManager.LoadScene(0);
    }
}
