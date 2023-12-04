// See https://aka.ms/new-console-template for more information
using System;
using System.Diagnostics;
using System.IO.Compression;
using System.Net;
using System.Reflection;


Console.WriteLine(" - Begin / Download ");

/* ---------- Begin variables ---------- */

// relatives routes :
string current =  Directory.GetCurrentDirectory();

string destinationDirectoryName = current;
string destinationDirectoryNamewithzip = Path.Combine(destinationDirectoryName, "prueba.zip");

string exeOutside = Path.Combine(destinationDirectoryName, "prueba.exe");
string newFolder = Path.Combine(destinationDirectoryName, "Versions");

// other variables :
string remoteUri = "http://localhost/";
string Name = @"prueba.zip";
string fileName = Name, 
myStringWebResource = null;
myStringWebResource = remoteUri + fileName;

bool overwriteFiles = true;

/* ---------- End variables ---------- */

/* ---------- Begin process ---------- */
DownloadZip();
DecompressAndOverDrive();
MoveAndOpen();
/* ---------- End process ---------- */


void DownloadZip()
{
    try
    {
        // Create a new WebClient instance.
        WebClient myWebClient = new WebClient();
        Console.WriteLine("Downloading File \"{0}\" from \"{1}\" .......\n\n", fileName, myStringWebResource);
        // Download the Web resource and save it into the current filesystem folder.
        try
        {
            myWebClient.DownloadFile(myStringWebResource, Path.Combine(destinationDirectoryName, fileName));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message + ex.InnerException);
        }
        Console.WriteLine("Successfully Downloaded File \"{0}\" from \"{1}\"", fileName, myStringWebResource);
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error: " + ex.Message + ex.InnerException);
    }
}

void DecompressAndOverDrive()
{
    // Decompress and overwrite

    try
    {
        ZipFile.ExtractToDirectory(destinationDirectoryNamewithzip, destinationDirectoryName, overwriteFiles);
        Console.WriteLine("Successfully Extract File \"{0}\" from \"{1}\"", destinationDirectoryNamewithzip, destinationDirectoryName);
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error: " + ex.Message);
    }
}

void MoveAndOpen()
{

    //string newFolder = "Versions";
    string newName = "Respaldo";

    // Check if the original file exists
    if (File.Exists(destinationDirectoryNamewithzip))
    {
        // Create the new folder if it doesn't exist
        if (!Directory.Exists(newFolder))
        {
            try
            {
                Directory.CreateDirectory(newFolder);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message + ex.InnerException);
            }
        }

        // Increment the version using the current date and time
        string version = $"{DateTime.Now:yyyyMMddHHmm}";

        // obtain AssemblyVersion version
        string AssemblyVersion = Assembly.GetEntryAssembly().GetName().Version.ToString();

        // Create the new file path with the updated name and version
        string newFilePath = Path.Combine(newFolder, $"{newName}_V_{AssemblyVersion}_T_{version}.zip");

        // Copy the original file to the new file path
        try
        {
            File.Move(destinationDirectoryNamewithzip, newFilePath, true);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message + ex.InnerException);
        }
        Console.WriteLine($"File renamed, version {version} added, and moved to the new folder.");

        // Optionally, you can delete the original file
        // File.Delete(originalFilePath);

        // Start a new instance of the application
        try
        {
            Process.Start(exeOutside);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message + ex.InnerException);
        }
    }
    else
    {
        Console.WriteLine("Original file does not exist.");
        File.Delete(destinationDirectoryNamewithzip);
    }
}




