using UnityEngine;

public class GridManager : MonoBehaviour
{
    const int SizeX = 20;
    const int SizeY = 20;

    GameObject[,] gridVisuals;

    bool[,] grid;

    void Start()
    {
        grid = new bool[SizeX, SizeY];

        for (int x = 0; x < SizeX; x++)
        {
            for (int y = 0; y < SizeY; y++)
            {
                grid[x, y] = Random.Range(0, 100) > 50;//(x % 2 == 0 );
            }
        }

        CreateVisuals();

        // int alive = CountAliveNeighbours(0, 0);
        // Debug.Log("Alive Count = " + alive);

        // alive = CountAliveNeighbours(1, 0);
        // Debug.Log("Alive Count = " + alive);

        // alive = CountAliveNeighbours(0, 1);
        // Debug.Log("Alive Count = " + alive);

        // alive = CountAliveNeighbours(SizeX - 1, 0);
        // Debug.Log("Alive Count = " + alive);

        // alive = CountAliveNeighbours(0, SizeY - 1);
        // Debug.Log("Alive Count = " + alive);

        // alive = CountAliveNeighbours(SizeX - 1, SizeY - 1);
        // Debug.Log("Alive Count = " + alive);

        // alive = CountAliveNeighbours(3, 3);
        // Debug.Log("Alive Count = " + alive);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            ProcessSimCycle();
    }

    private void ProcessSimCycle()
    {
        bool[,] newGrid = new bool[SizeX, SizeY];

        for (int x = 0; x < SizeX; x++)
        {
            for (int y = 0; y < SizeY; y++)
            {
                int aliveCount = CountAliveNeighbours(x, y);

                if (grid[x, y])
                {
                    if (aliveCount < 2)
                        newGrid[x, y] = false;
                    else if (aliveCount == 3 || aliveCount == 2)
                        newGrid[x, y] = true;
                    else if (aliveCount > 3)
                        newGrid[x, y] = false;
                }
                else
                {
                    if (aliveCount == 3)
                        newGrid[x, y] = true;
                }
            }
        }

        grid = newGrid;

        DestroyVisuals();
        CreateVisuals();
        

        // Any live cell with fewer than two live neighbours dies, as if by underpopulation.
        // Any live cell with two or three live neighbours lives on to the next generation.
        // Any live cell with more than three live neighbours dies, as if by overpopulation.
        // Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.

    }

    private int CountAliveNeighbours(int x, int y)
    {
        int aliveCells = 0;

        if (y < SizeY - 1)
        {
            if (grid[x, y + 1])
                aliveCells++;
        }

        if (x < SizeX - 1 && y < SizeY - 1)
        {
            if (grid[x + 1, y + 1])
                aliveCells++;
        }

        if (x < SizeX - 1)
        {
            if (grid[x + 1, y])
                aliveCells++;
        }

        if (x < SizeX - 1 && y > 0)
        {
            if (grid[x + 1, y - 1])
                aliveCells++;
        }

        if (y > 0)
        {
            if (grid[x, y - 1])
                aliveCells++;
        }

        if (x > 0 && y > 0)
        {
            if (grid[x - 1, y - 1])
                aliveCells++;
        }

        if (x > 0)
        {
            if (grid[x - 1, y])
                aliveCells++;
        }

        if (x > 0 && y < SizeY - 1)
        {
            if (grid[x - 1, y + 1])
                aliveCells++;
        }

        return aliveCells;
    }

    private void CreateVisuals()
    {
        gridVisuals = new GameObject[SizeX, SizeY];

        for (int x = 0; x < SizeX; x++)
        {
            for (int y = 0; y < SizeY; y++)
            {
                GameObject cell = new GameObject();
                cell.name = "cell " + x + ", " + y;
                SpriteRenderer spriteRenderer = cell.AddComponent<SpriteRenderer>();
                spriteRenderer.sprite = Resources.Load<Sprite>("Square");
                cell.transform.position = new Vector3(x - SizeX / 2, y - SizeY / 2, 0);

                if (grid[x, y])
                    spriteRenderer.color = Color.black;
                else
                    spriteRenderer.color = Color.gray;

                gridVisuals[x, y] = cell;
            }
        }
    }

    private void DestroyVisuals()
    {
        foreach(GameObject cell in gridVisuals)
        {
            Destroy(cell);
        }
    }

}
