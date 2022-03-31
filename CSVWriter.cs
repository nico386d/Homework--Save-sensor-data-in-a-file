using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CSVWriter : MonoBehaviour
{
    Gyroscope gyro;
    // https://www.youtube.com/watch?v=sU_Y2g1Nidk&t=2s&ab_channel=DestinedToLearn
    string filename = "";
    // Start is called before the first frame update
    [System.Serializable]
    public class Data

    {
        public int Gyroscope;
    }

    public class DataList
    {
        public Data[] data;
    }
    public DataList myDataList = new DataList();
    List<string> data = new List<string>();

    void Start()
    {
        filename = Application.dataPath + "/test.csv";
        Debug.Log(filename);
        gyro = Input.gyro;
            if(SystemInfo.supportsGyroscope)
            {
            gyro.enabled = true;
             }
    }
    // tells where in my flies is located and enabled the input.gyro
    bool buttonClicked = false;

 
    void Update()
    {
        if (buttonClicked)
            data.Add(gyro.gravity.x + "," + gyro.gravity.y + "," + gyro.gravity.z);
    }
    // When the button is clicked the data from the gyroscope is collected from its x,y and z axis
    public void WriteCSV()
    {
   
            TextWriter tw = new StreamWriter(filename, false);
            tw.WriteLine("x,y,z");
            tw.Close();

            tw = new StreamWriter(filename, true);

            for(int i = 0; i < data.Count; i++)
            {
                tw.WriteLine(data[i]) ;
            }
            tw.Close();
        data.Clear();
        
    }

    public void clicked()
    {
        Debug.Log("clicked");
        buttonClicked = !buttonClicked;
       // if the button is false it will be true and if its true it will be falls after clickin it
        if(!buttonClicked)
            WriteCSV();
    }
}