# UpdaterBackgroundCS
Upgrate in the background in a project build in C#
This program runs an update for a C# application. To do this, you need to create a folder named "updater" and place this program inside it.

The program checks a URL every 20 seconds for differences in a JSON with the following information:
{
  "version": "1.0.0.X"
}
It compares this with the assembly version of the program you want to update. If it finds a greater difference in the server's JSON, it will download the accompanying ZIP file (the names of the JSON and ZIP are specified as variables).

It makes a copy in the default "versions" folder. Once the ZIP is downloaded, it replaces the current program and its files and then re-executes the updated program.

To perform the replacement correctly, you should run the updater from the application that needs to be updated.
