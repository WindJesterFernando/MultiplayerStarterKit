using UnityEngine;

public class GridManager : MonoBehaviour
{
    GameObject[,] gridVisuals;

    void Start()
    {
        Simulation.GenerateGrid();
        CreateVisuals();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Simulation.ProcessSimCycle();
            DestroyVisuals();
            CreateVisuals();
        }
    }

    private void CreateVisuals()
    {
        gridVisuals = new GameObject[Simulation.SizeX, Simulation.SizeY];

        for (int x = 0; x < Simulation.SizeX; x++)
        {
            for (int y = 0; y < Simulation.SizeY; y++)
            {
                GameObject cell = new GameObject();
                cell.name = "cell " + x + ", " + y;
                SpriteRenderer spriteRenderer = cell.AddComponent<SpriteRenderer>();
                spriteRenderer.sprite = Resources.Load<Sprite>("Square");
                cell.transform.position = new Vector3(x - Simulation.SizeX / 2, y - Simulation.SizeY / 2, 0);

                if (Simulation.gridCells[x, y])
                    spriteRenderer.color = Color.gray;
                else
                    spriteRenderer.color = Color.black;

                gridVisuals[x, y] = cell;
            }
        }
    }

    private void DestroyVisuals()
    {
        foreach (GameObject cell in gridVisuals)
        {
            Destroy(cell);
        }
    }

}
