static public class Simulation
{
    public const int SizeX = 20;
    public const int SizeY = 20;

    static public bool[,] grid;

    static public void GenerateGrid()
    {
        grid = new bool[SizeX, SizeY];

        for (int x = 0; x < SizeX; x++)
        {
            for (int y = 0; y < SizeY; y++)
            {
                grid[x, y] = UnityEngine.Random.Range(0, 100) > 50;//(x % 2 == 0 );
            }
        }
    }

    static public void ProcessSimCycle()
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

        // Any live cell with fewer than two live neighbours dies, as if by underpopulation.
        // Any live cell with two or three live neighbours lives on to the next generation.
        // Any live cell with more than three live neighbours dies, as if by overpopulation.
        // Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
    }

    static public int CountAliveNeighbours(int x, int y)
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
}