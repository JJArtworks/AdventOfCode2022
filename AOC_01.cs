using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
public class AOC_01 : MonoBehaviour
{
    List<int> dataList, blockResults, dataSums;
    List<string> dataLines;
    int blockID, totalSum, dataSubBlockSum, dataBlockMax;

    void Start()
    {    
        Initialize();
        ParseFile();
        ProcessData();
    }
    void Initialize(){
        totalSum = 0;
        dataSums = new List<int>();
        dataSubBlockSum = 0;
        dataBlockMax = 0;
        blockID = 0;
    }
    void ParseFile()
    {
        dataLines = File.ReadLines(@"Assets/Inputs/01_input.txt").ToList();
        Debug.Log("dataLines.Count = " + dataLines.Count());
        foreach (var i in dataLines){
            if (i != ""){
                totalSum += int.Parse(i);
            } 
        }
        Debug.Log("total sum = " + totalSum);
    }
    void AddData(int blockID, List<int> dataSubBlock)
    {
        dataSubBlockSum = dataSubBlock.Sum();
        dataSums.Add(dataSubBlockSum);
        dataBlockMax = dataSums.Max();
    }
    void ProcessData()
    {
        List<int> dataSubBlock = new List<int>();
        for (int i = 0; i < dataLines.Count(); i++)
        {    
            if (dataLines[i] == "")
            {
                AddData(blockID, dataSubBlock);
                blockID ++;
                dataSubBlock.Clear();
                dataSubBlock = new List<int>();
            } else {
                dataSubBlock.Add(int.Parse(dataLines[i]));
                if (i == dataLines.Count()-1){
                    AddData(blockID, dataSubBlock);
                    Debug.Log("------------- dataBlockMax = " + dataBlockMax);
                }
            }
        }
    }
}