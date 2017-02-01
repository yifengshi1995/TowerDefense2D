using UnityEngine;
using System.Text;
using System.IO;
using System;

public class EnemyManager : MonoBehaviour {

    public string file;
    public static EnemyData[] enemyList;

    void Awake()
    {
        
        LoadFile(file);
    }

    private void LoadFile(string fileName)
    {
        try
        {
            int counter = 0;
            string line;
            bool firstLine = true;
            string path = Application.dataPath + fileName;
            StreamReader reader = new StreamReader(path, Encoding.Default);
            using (reader)
            {
                do
                {
                    line = reader.ReadLine();
                    if (firstLine)
                    {
                        enemyList = new EnemyData[Int32.Parse(line)];
                        firstLine = false;
                    }
                    else
                    {
                        if (line != null)
                        {
                            string[] lines = line.Split(' ');
                            int index = Int32.Parse(lines[0]);
                            string name = lines[1];
                            float waitTime = Convert.ToSingle(lines[2]);
                            EnemyData ed = new EnemyData(index, name, waitTime);
                            enemyList[counter] = ed;
                            counter++;
                        }

                    }
                }
                while (line != null);
                reader.Close();
            }
        }
        catch(Exception e)
        {
            Console.WriteLine("{0}\n", e.Message);
        }
    }
}


