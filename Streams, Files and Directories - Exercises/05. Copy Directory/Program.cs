﻿namespace CopyDirectory
{
    using System;
    public class CopyDirectory
    {
        static void Main()
        {
            string inputPath = @$"D:\S(4)\S(4)\programming\C#ADVANCED\10.Exercise Streams, Files and Directories\directoryToCopy";
            string outputPath = @$"D:\S(4)\S(4)\programming\C#ADVANCED\10.Exercise Streams, Files and Directories\CopiedDirectory";

            CopyAllFiles(inputPath, outputPath);
        }

        public static void CopyAllFiles(string inputPath, string outputPath)
        {
            if (Directory.Exists(outputPath))
            {
                Directory.Delete(outputPath, recursive: true);
            }
            Directory.CreateDirectory(outputPath);
            string[] fileNames = Directory.GetFiles(inputPath);
            foreach (string file in fileNames)
            {
                string fileName = Path.GetFileName(file);
                string destination = Path.Combine(outputPath, fileName);

                File.Copy(file, destination);
            }
        }
    }
}
