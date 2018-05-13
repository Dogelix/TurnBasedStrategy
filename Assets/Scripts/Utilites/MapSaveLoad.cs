using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;

namespace Utilites
{ 
    public class MapSaveLoad : MonoBehaviour
    {
        private const char BLOCK_IDENTIFIER = '#';
        private const char DATA_SPLITTER = '-';
        
        private static string _fileDir;
        private string _saveName = "default.tbs";

        private void Start()
        {
            _fileDir = SaveFileDirectory + CurrentSaveName;
        }

        private static string SaveFileDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        /// <summary>
        /// Just set the name of the file not the extention
        /// </summary>
        public string CurrentSaveName
        {
            get
            {
                return _saveName;
            }
            set
            {
                _saveName = value + ".tbs";
            }
        }


        public static void SaveTileInformation(ITile[] tiles)
        {
            TextWriter writer = null;
            TextReader reader = null;
            try
            {
                writer = new StreamWriter(_fileDir);
                reader = new StreamReader(_fileDir);
                string line;
                while((line = reader.ReadLine()) != null)
                {
                    if (line == "TILES")
                    {
                        writer.WriteLine();

                        foreach(ITile t in tiles)
                        {
                            writer.Write(t.Location.x.ToString() + DATA_SPLITTER + t.Location.y.ToString() + DATA_SPLITTER + t.Location.z.ToString() + DATA_SPLITTER);

                            switch (t.TileType)
                            {
                                case ETileType.Cover:
                                    writer.WriteLine("C");
                                    break;
                                case ETileType.Ground:
                                    writer.WriteLine("G");
                                    break;
                                case ETileType.Impassable:
                                    writer.WriteLine("I");
                                    break;
                            }
                        }
                    }
                    if(line == "#")
                    {
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Debug.Log("Save (TILE) Error: " + e.StackTrace);
            }
            finally
            {
                writer.Close();
                reader.Close();
            }
        }

        public static void SavePlayerInformation()
        {
            try
            {

            }
            catch (Exception e)
            {
                Debug.Log("Save (PLAYER) Error: " + e.StackTrace);
            }
        }

    }
}