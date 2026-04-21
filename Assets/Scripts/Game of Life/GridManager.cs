using UnityEngine;
using System.Threading;

public class GridManager : MonoBehaviour
{
    GameObject[,] gridVisuals;
    Thread simulationThread;

    bool isFirstUpdate = true;

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




        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        // Simulation.ProcessSimCycle();
        //if (//simulationThread.ThreadState != ThreadState.Running)
        //if(!simulationThread.IsAlive)
        {
            // DestroyVisuals();
            // CreateVisuals();

        }

        //Simulation.ProcessSimCycle();

        //}
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     DestroyVisuals();
        //     CreateVisuals();
        // }
    }

    private void CreateVisuals()
    {
        //bool[,] gridCells = new bool[Simulation.SizeX, Simulation.SizeY];

        lock (Simulation.bufferToLoadIntoVisuals)
        {
            if (Simulation.bufferToLoadIntoVisuals.hasNewData)
            {
                for (int x = 0; x < Simulation.SizeX; x++)
                {
                    for (int y = 0; y < Simulation.SizeY; y++)
                    {
                        GameObject cell = new GameObject();
                        cell.name = "cell " + x + ", " + y;
                        SpriteRenderer spriteRenderer = cell.AddComponent<SpriteRenderer>();
                        spriteRenderer.sprite = Resources.Load<Sprite>("Square");
                        cell.transform.position = new Vector3(x - Simulation.SizeX / 2, y - Simulation.SizeY / 2, 0);

                        if (Simulation.bufferToLoadIntoVisuals.gridCells[x, y])
                            spriteRenderer.color = Color.gray;
                        else
                            spriteRenderer.color = Color.black;

                        //gridCells[x, y] = Simulation.bufferToLoadIntoVisuals.gridCells[x, y];
                    }
                }

                //gridCells = Simulation.bufferToLoadIntoVisuals.gridCells;

                Simulation.bufferToLoadIntoVisuals.hasNewData = false;
            }
        }


        // gridVisuals = new GameObject[Simulation.SizeX, Simulation.SizeY];

        // for (int x = 0; x < Simulation.SizeX; x++)
        // {
        //     for (int y = 0; y < Simulation.SizeY; y++)
        //     {
        //         GameObject cell = new GameObject();
        //         cell.name = "cell " + x + ", " + y;
        //         SpriteRenderer spriteRenderer = cell.AddComponent<SpriteRenderer>();
        //         spriteRenderer.sprite = Resources.Load<Sprite>("Square");
        //         cell.transform.position = new Vector3(x - Simulation.SizeX / 2, y - Simulation.SizeY / 2, 0);

        //         if (gridCells[x, y])
        //             spriteRenderer.color = Color.gray;
        //         else
        //             spriteRenderer.color = Color.black;

        //         gridVisuals[x, y] = cell;
        //     }
        // }
    }

    //private void CreateCell

    private void DestroyVisuals()
    {
        if(gridVisuals == null)
            return;

        foreach (GameObject cell in gridVisuals)
        {
            Destroy(cell);
        }
    }

}
