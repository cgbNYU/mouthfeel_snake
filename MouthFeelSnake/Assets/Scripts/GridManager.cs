using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int GridWidth;
    public int GridHeight;

    public GameObject GridPanel;

    public Material EmptyMat;
    public Material FilledMat;
    public Material DeathMat;

    public GameObject[,] PanelArray;
    public List<GameObject> SnakeList = new List<GameObject>();
    
    public Vector2 StartPos;

    public static GridManager Instance;
    
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        InitializeArray();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitializeArray()
    {
        PanelArray = new GameObject[GridWidth, GridHeight];
        for (int x = 0; x < GridWidth; x++)
        {
            for (int y = 0; y < GridHeight; y++)
            {
                GameObject panel = Instantiate(GridPanel);
                panel.transform.SetParent(transform, true);
                Vector3 panelPos = new Vector3(StartPos.x + (x * panel.transform.localScale.x), StartPos.y + (y * panel.transform.localScale.y), 0);
                panel.transform.position = panelPos;
                PanelArray[x, y] = panel;
            }
        }
    }
}
