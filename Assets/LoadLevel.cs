using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel : MonoBehaviour
{

    [SerializeField] public List<GameObject> LevelPrefabs; // Lista prefabów do upuszczenia
    [SerializeField] private GameObject LevelParent;

    public int selectedLevel = 1;


    // Start is called before the first frame update
    void Start()
    {
        GameObject newBall = Instantiate(LevelPrefabs[0], transform.position, Quaternion.identity);
        newBall.transform.SetParent(LevelParent.transform);
    }

    public void LoadSelectedLevel()
    {
        Debug.Log(selectedLevel);
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);

        }
        GameObject newBall = Instantiate(LevelPrefabs[selectedLevel - 1], transform.position, Quaternion.identity);
        newBall.transform.SetParent(LevelParent.transform);

    }
    // Update is called once per frame
    void Update()
    {

    }
}
