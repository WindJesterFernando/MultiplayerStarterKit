using System;
using System.Collections.Generic;

static public class Simulation
{
    public const int SizeX = 50;
    public const int SizeY = 50;

    static public bool[,] gridCells;

    static public int generation;

    static long timeSinceLastBenchmark = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

    static public Queue<string> debugLogQueue;

    static public BufferToLoadIntoVisuals bufferToLoadIntoVisuals;

    // static public bool bufferIsLocked;

    static public void GenerateGrid()
    {
        debugLogQueue = new Queue<string>();

        bufferToLoadIntoVisuals = new BufferToLoadIntoVisuals();
        bufferToLoadIntoVisuals.gridCells = new bool[SizeX, SizeY];

        gridCells = new bool[SizeX, SizeY];

        for (int x = 0; x < SizeX; x++)
        {
            for (int y = 0; y < SizeY; y++)
            {
                gridCells[x, y] = UnityEngine.Random.Range(0, 100) > 50;//(x % 2 == 0 );
            }
        }
    }

    static public void ProcessSimCycle()
    {
        while (generation < 100000)
        {

            #region Process Next Generation of Sim

            generation++;

            bool[,] newGrid = new bool[SizeX, SizeY];

            for (int x = 0; x < SizeX; x++)
            {
                for (int y = 0; y < SizeY; y++)
                {
                    newGrid[x, y] = DetermineCellLifeState(x, y);
                }
            }

            gridCells = newGrid;

            #endregion

            #region Time Stamp

            if (generation % 1000 == 0)
            {
                long newTimeStamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                long timeDif = newTimeStamp - timeSinceLastBenchmark;
                timeSinceLastBenchmark = newTimeStamp;

                lock (debugLogQueue)
                {
                    debugLogQueue.Enqueue("gen == " + generation);
                    debugLogQueue.Enqueue("time == " + timeDif);
                }//unlocks
            }

            #endregion


            lock (bufferToLoadIntoVisuals)
            {
                if (!bufferToLoadIntoVisuals.hasNewData)
                {
                    for (int x = 0; x < Simulation.SizeX; x++)
                    {
                        for (int y = 0; y < Simulation.SizeY; y++)
                        {
                            bufferToLoadIntoVisuals.gridCells[x, y] = gridCells[x, y];
                        }
                    }

                    //bufferToLoadIntoVisuals.gridCells = gridCells;
                    bufferToLoadIntoVisuals.hasNewData = true;
                }
            }
        }

        lock (debugLogQueue)
        {
            debugLogQueue.Enqueue("Done!!!!");
        }

        //Don't use, recursion will kill Unity and you will be sad.
        // if (generation < 100000)
        //     ProcessSimCycle();
    }

    static public int CountAliveNeighbours(int x, int y)
    {
        int aliveCells = 0;

        #region Clean Code Solution

        if (IsCellAlive(x, y + 1))
            aliveCells++;
        if (IsCellAlive(x, y - 1))
            aliveCells++;
        if (IsCellAlive(x + 1, y))
            aliveCells++;
        if (IsCellAlive(x - 1, y))
            aliveCells++;
        if (IsCellAlive(x + 1, y + 1))
            aliveCells++;
        if (IsCellAlive(x - 1, y + 1))
            aliveCells++;
        if (IsCellAlive(x + 1, y - 1))
            aliveCells++;
        if (IsCellAlive(x - 1, y - 1))
            aliveCells++;

        #endregion

        #region Efficient Solution

        // if (y < SizeY - 1)
        // {
        //     if (grid[x, y + 1])
        //         aliveCells++;
        // }

        // if (x < SizeX - 1 && y < SizeY - 1)
        // {
        //     if (grid[x + 1, y + 1])
        //         aliveCells++;
        // }

        // if (x < SizeX - 1)
        // {
        //     if (grid[x + 1, y])
        //         aliveCells++;
        // }

        // if (x < SizeX - 1 && y > 0)
        // {
        //     if (grid[x + 1, y - 1])
        //         aliveCells++;
        // }

        // if (y > 0)
        // {
        //     if (grid[x, y - 1])
        //         aliveCells++;
        // }

        // if (x > 0 && y > 0)
        // {
        //     if (grid[x - 1, y - 1])
        //         aliveCells++;
        // }

        // if (x > 0)
        // {
        //     if (grid[x - 1, y])
        //         aliveCells++;
        // }

        // if (x > 0 && y < SizeY - 1)
        // {
        //     if (grid[x - 1, y + 1])
        //         aliveCells++;
        // }

        #endregion

        return aliveCells;
    }

    static private bool IsCellAlive(int x, int y)
    {
        bool isInBounds = true;
        if (y < 0 || x < 0 || y > SizeY - 1 || x > SizeX - 1)
            isInBounds = false;

        if (!isInBounds)
            return false;

        return gridCells[x, y];
    }

    static private bool DetermineCellLifeState(int x, int y)
    {
        int aliveCount = CountAliveNeighbours(x, y);

        if (gridCells[x, y])
        {
            if (aliveCount < 2)
                return false;
            else if (aliveCount == 3 || aliveCount == 2)
                return true;
            else if (aliveCount > 3)
                return false;
        }
        else
        {
            if (aliveCount == 3)
                return true;
        }

        return false;
    }

}


public class BufferToLoadIntoVisuals
{
    public bool[,] gridCells;

    public bool hasNewData;
}