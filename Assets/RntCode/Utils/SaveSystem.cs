using UnityEngine;
using UnityEditor;
using System.IO;
using System;
using System.Collections.Generic;

namespace RntCode.Utils {
    public static class SaveSystem {

        public static readonly string SAVE_FOLDER_PATH = Application.dataPath + "/Saves/";
        public const string DATE_TIME_FORMAT = "ddMMyyyyHHmmss";
        public const string FILE_EXTENSION = ".txt";

        /// <summary>
        /// Create folder if not exist.
        /// </summary>
        public static void Init(){
            if(!Directory.Exists(SAVE_FOLDER_PATH)){
                Directory.CreateDirectory(SAVE_FOLDER_PATH);
            }
        }

        /// <summary>
        /// Saving file of FILE_EXTENSION format in SAVE_FOLDER_PATH
        /// </summary>
        /// <param name="textToSave"> What you want to save to file in string format</param>
        /// <param name="name">Fill this up if you want save file with specific name or rewrite specific file. Null -> create file with unique name</param>
        public static void save(string textToSave, string name = null){
            File.WriteAllText(SAVE_FOLDER_PATH + createFileName(name), textToSave);
        }

        /// <summary>
        /// Loading file of of FILE_EXTENSION format in SAVE_FOLDER_PATH
        /// </summary>
        /// <param name="name">Fill this up if you want load file with specific name. Null -> load lates saved file</param>
        /// <returns></returns>
        public static string load(string name = null) {
            DirectoryInfo directoryInfo = new DirectoryInfo(SAVE_FOLDER_PATH);
            FileInfo[] fileInfos = directoryInfo.GetFiles("*" + FILE_EXTENSION);
            FileInfo loadedFile = null;
            foreach(FileInfo fileInfo in fileInfos) {
                if(name == null){
                    if(loadedFile == null) {
                        loadedFile = fileInfo;
                    } else {
                        if(fileInfo.LastWriteTime > loadedFile.LastWriteTime)
                            loadedFile = fileInfo;
                    }
                }else{ 
                    if(fileInfo.Name.Equals(name + FILE_EXTENSION))
                        loadedFile = fileInfo;
                }
            }
            
            if(loadedFile != null){
                string loadedString = File.ReadAllText(loadedFile.FullName);
                return loadedString;
            }else{
                return null;
            }
        }

        /// <summary>
        /// Create unique name for file based on current datetime
        /// </summary>
        /// <param name="name">Specific name for file</param>
        /// <returns></returns>
        private static string createFileName(string name){
            if(name == null){
                DateTime dateTime = DateTime.Now;
                return dateTime.ToString(DATE_TIME_FORMAT) + FILE_EXTENSION;
            }else{
                return name + FILE_EXTENSION;
            }
        }
    }
}