using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
public class AOC_01 : MonoBehaviour
{
    List<int> dataList, dataSubBlock, blockResults;
    List<List<int>> dataBlock;
    //List<int[]> dataBlock;
    List<string> dataLines;
    //int[] dataLines;
    int parsedDataLine, blockID, blockResult, biggestResult, finalResult;

    void Start()
    {    
        Initialize();
        ParseFile();
        ProcessData();
        ComputeResult();
    }
    void Initialize(){
        blockID = 0;
        dataList = new List<int>();
        dataSubBlock = new List<int>();
        dataBlock = new List<List<int>>();
        //dataBlock = new List<int[]>();
        blockResults = new List<int>();
    }
    void ParseFile()
    {
        dataLines = File.ReadLines(@"Assets/Inputs/01_input.txt").ToList();
        Debug.Log("dataLines.Count = " + dataLines.Count());
    }
    void ProcessData()
    {
        // break into different blocks
        for (int i = 0; i < dataLines.Count(); i++)
        {      
            //Debug.Log("dataLines[" + i + "] = " + dataLines[i]);
            if (dataLines[i] == "")
            {
                blockID += 1;
                dataBlock.Insert(blockID, new List<int>());
            } else {
                dataSubBlock.Add(int.Parse(dataLines[i]));
                dataBlock.Insert(blockID, dataSubBlock);
            }
        }
        // calculate sum for each block
        //for (int i = 0; i < dataBlock.Count(); i++)
        //{
            foreach (List<int> l in dataBlock)
            {
                blockResult = 0;
                foreach (int num in l)
                {
                    blockResult += num;
                }
                Debug.Log("blockResult = " + blockResult);
                blockResults.Add(blockResult);
            }
        //}
    }
    void ComputeResult()
    {
        finalResult = blockResults.Max();
        Debug.Log("----------------------- The highest number is " + finalResult);
    }
}