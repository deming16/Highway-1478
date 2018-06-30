using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManagerSkytrain : MonoBehaviour {

    public GameObject[] tilePrefabs;
    private Transform playerTransform;
    private float spawnZ = 0f;
    private float tileLength = 10f;
    private int numTilesOnScreen = 20;
    private List<GameObject> activeTiles =new List<GameObject>();
    private float safeZone = 15f;
    private int lastPrefabIdx = 0;

    public GameManager gameManager;
    private float timePassed = 0f;
    public float TriggerDelay;
    private bool isDark = false;

    public GameObject screen;
    private float randNum;
    private bool isFlipped = false;
    // Use this for initialization
    void Start () {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        for (int i = 0; i < numTilesOnScreen; i++)
        {
            if(i<3)
            SpawnTile(0);
            else
            {
                SpawnTile();
            }
        }
        
    }
	
	// Update is called once per frame
	void Update () {
		if(playerTransform.position.z -safeZone >(spawnZ- numTilesOnScreen * tileLength))
        {
            SpawnTile();
            DeleteTile();
        }
        //Turns into birght/dark mode
        timePassed += Time.deltaTime;
        if (timePassed > TriggerDelay)
        {
            randNum = Random.Range(0, 1000); 
            if (randNum < 250)
            {
                if (isDark)
                {
                    gameManager.TurnBright();
                    isDark = false;
                }
                else
                {
                    gameManager.TurnDark();
                    isDark = true;
                }
            }
            else if(randNum < 500)
            {
                screen.GetComponent<CameraMovement>().startTime = Time.time;
                if(isFlipped)
                {
                    screen.GetComponent<CameraMovement>().flipEnter = false;
                    screen.GetComponent<CameraMovement>().flipExit = true;
                    isFlipped = false;
                }
                else
                {
                    screen.GetComponent<CameraMovement>().flipExit = false;
                    screen.GetComponent<CameraMovement>().flipEnter = true;
                    isFlipped = true;
                }
            }
            timePassed = 0f;
        }

    }
    private void SpawnTile(int prefabIdx = -1 )
    {
        GameObject go;
        if (prefabIdx == -1)
        {
            go = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
        }
        else
        {
            go = Instantiate(tilePrefabs[prefabIdx]) as GameObject;
        }
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        activeTiles.Add(go);
    }
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
    private int RandomPrefabIndex()
    {
        if(tilePrefabs.Length <= 1)
        {
            return 0;
        }

        int randomIndex = lastPrefabIdx;
        while(randomIndex == lastPrefabIdx)
        {
            randomIndex = Random.Range(0, tilePrefabs.Length);
        }
        lastPrefabIdx = randomIndex;
        return randomIndex;
    }
}
