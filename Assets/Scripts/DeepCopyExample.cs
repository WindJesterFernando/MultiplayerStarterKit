using System.Collections.Generic;
using UnityEngine;

public class DeepCopyExample : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TestCopyClass tcc = new TestCopyClass();

        tcc.x = 45;
        tcc.text = "fsdgh werger erg";
        tcc.ints.AddLast(5);
        tcc.ints.AddLast(7);
        tcc.ints.AddLast(2);
        tcc.ints.AddLast(9);

        TestCopyClass tcc2 = tcc.MakeDeepCopy();

        // TestCopyClass tcc2 = new TestCopyClass();
        // tcc2.x = tcc.x;
        // tcc2.text = tcc.text;

        // foreach (int i in tcc.ints)
        // {
        //     tcc2.ints.AddLast(i);
        // }



        tcc2.ints.RemoveLast();
        tcc2.ints.RemoveLast();

        Debug.Log("tcc");
        tcc.PrintAllInts();
        Debug.Log("");
        Debug.Log("tcc2");
        tcc2.PrintAllInts();

    }

    // Update is called once per frame
    void Update()
    {

    }
}



public class TestCopyClass
{
    public int x;
    public string text;
    public TestCopyClass testCopyClass;

    public LinkedList<int> ints;


    public TestCopyClass()
    {
        ints = new LinkedList<int>();
    }


    public void PrintAllInts()
    {


        Debug.Log("x = " + x);

        foreach (int i in ints)
        {
            Debug.Log("i = " + i);
        }
    }

    public TestCopyClass MakeDeepCopy()
    {
        TestCopyClass copy = new TestCopyClass();
        copy.x = x;
        copy.text = text;

        foreach (int i in ints)
        {
            copy.ints.AddLast(i);
        }

        return copy;
    }


}