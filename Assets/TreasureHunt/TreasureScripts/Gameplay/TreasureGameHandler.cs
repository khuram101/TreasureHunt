using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreasureGameHandler : MonoBehaviour
{
    [Header("--Reference Prefabs--")]
    [SerializeField] private GameObject backgroundGridPrefab;
    [SerializeField] private GameObject treasurePrefab;

    ////// //

    [Header("--Grid Box Settings--")]
    [SerializeField] private GridLayoutGroup gridLayoutGroup;
    [SerializeField] private GridLayoutGroup gridLayoutTreasure;
    [SerializeField, Range(3, 5)] private int gridCount = 3;


    private Array[,] GridItems;


    // // // // Pool references
    [SerializeField]
    private GameObject[] backgroundGridPool;
    [SerializeField]
    private GameObject[] treasurePrefabPool;


    void Start()
    {
        PrepareGameSetup();
    }

    private void PrepareGameSetup()
    {
        gridLayoutGroup.constraintCount = gridCount;
        gridLayoutTreasure.constraintCount = gridCount;

        GridItems = new Array[gridCount, gridCount];
        backgroundGridPool = new GameObject[gridCount * gridCount];
        treasurePrefabPool = new GameObject[gridCount * gridCount];

        StartCoroutine(nameof(CreateGridItems));


    }

    private IEnumerator CreateGridItems()
    {
        var totalGridTiles = gridCount * gridCount;

        for (int i = 0; i < totalGridTiles; i++)
        {
            GameObject gridTile = Spawn(backgroundGridPrefab);
            gridTile.transform.SetParent(gridLayoutGroup.transform);
            backgroundGridPool[i] = gridTile;

            GameObject gridTreasure = Spawn(treasurePrefab);
            gridTreasure.transform.SetParent(gridLayoutTreasure.transform);

            treasurePrefabPool[i] = gridTreasure;


            treasurePrefabPool[i].GetComponent<IGridTilePosition>().TilePosition(new TilePosition() { x = i, y = i });


            yield return new WaitForEndOfFrame();

        }

    }
    private void CreateTreasureItems()
    {

    }


    GameObject Spawn(GameObject go)
    {
        return Instantiate(go);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
