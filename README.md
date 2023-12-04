# UpdaterBackgroundCS
Upgrate in the background in a project build in C#
This is a program to update a C# project without a graphical interface. To make it work, it must be in a folder called "update" and change the absolute paths to relative paths. In addition, you need to adjust the time it takes to verify the JSON:
{
  "version": "1.0.0.<newversion>"
}
on the server with the updated project in a .zip file.
