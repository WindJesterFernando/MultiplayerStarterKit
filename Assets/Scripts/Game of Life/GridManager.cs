using UnityEngine;
using System.Threading;

public class GridManager : MonoBehaviour
{
    GameObject[,] gridVisuals;
    Thread simulationThread;

    void Start()
    {
        Simulation.GenerateGrid();

        simulationThread = new Thread(new ThreadStart(Simulation.ProcessSimCycle));
        simulationThread.Start();

        CreateVisuals();
    }

    void Update()
    {
        lock (Simulation.debugLogQueue)
        {
            while (Simulation.debugLogQueue.Count > 0)
                Debug.Log(Simulation.debugLogQueue.Dequeue());
        }

        DestroyVisuals();
        CreateVisuals();
    }

    private void CreateVisuals()
    {
        bool[,] gridCells = null;

        lock (Simulation.toLoadIntoVisualsQueue)
        {
            if (Simulation.toLoadIntoVisualsQueue.Count > 0)
            {
                gridCells = Simulation.toLoadIntoVisualsQueue.Dequeue();
            }
        }

        if (gridCells != null)
        {
            for (int x = 0; x < Simulation.SizeX; x++)
            {
                for (int y = 0; y < Simulation.SizeY; y++)
                {
                    CreateCell(x, y, gridCells[x, y]);
                }
            }
        }


    }

    private void CreateCell(int x, int y, bool isAlive)
    {
        GameObject cell = new GameObject();
        cell.name = "cell " + x + ", " + y;
        SpriteRenderer spriteRenderer = cell.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = Resources.Load<Sprite>("Square");
        cell.transform.position = new Vector3(x - Simulation.SizeX / 2, y - Simulation.SizeY / 2, 0);

        if (isAlive)
            spriteRenderer.color = Color.gray;
        else
            spriteRenderer.color = Color.black;
    }

    private void DestroyVisuals()
    {
        if (gridVisuals == null)
            return;

        foreach (GameObject cell in gridVisuals)
        {
            Destroy(cell);
        }
    }

}


//speed up bottleneck
//avoid bottleneck


//Egor's application of multi thread
//
//