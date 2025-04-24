using System;
using System.Collections.Generic;
using Sys = Cosmos.System;

namespace Saikat
{
    public class Kernel : Sys.Kernel
    {
        private Dictionary<string, string> files;

        protected override void BeforeRun()
        {
            Console.WriteLine("Cosmos booted successfully. Type 'cmd list' to see available commands.");
            files = new Dictionary<string, string>();
        }

        protected override void Run()
        {
            Console.Write("Command: ");
            var command = Console.ReadLine();
            ProcessCommand(command);
        }

        private void ProcessCommand(string command)
        {
            var parts = command.Split(' ');
            var action = parts[0].ToLower();

            switch (action)
            {
                case "create":
                    if (parts.Length < 3)
                    {
                        Console.WriteLine("Invalid command. Usage: create [filename] [content]");
                        return;
                    }
                    var filename = parts[1];
                    var content = string.Join(" ", parts, 2, parts.Length - 2);
                    CreateFile(filename, content);
                    break;

                case "read":
                    if (parts.Length != 2)
                    {
                        Console.WriteLine("Invalid command. Usage: read [filename]");
                        return;
                    }
                    var fileToRead = parts[1];
                    ReadFile(fileToRead);
                    break;

                case "write":
                    if (parts.Length < 3)
                    {
                        Console.WriteLine("Invalid command. Usage: write [filename] [content]");
                        return;
                    }
                    var fileToWrite = parts[1];
                    var contentToWrite = string.Join(" ", parts, 2, parts.Length - 2);
                    WriteFile(fileToWrite, contentToWrite);
                    break;

                case "delete":
                    if (parts.Length != 2)
                    {
                        Console.WriteLine("Invalid command. Usage: delete [filename]");
                        return;
                    }
                    var fileToDelete = parts[1];
                    DeleteFile(fileToDelete);
                    break;

                case "shutdown":
                    Shutdown();
                    break;

                case "cmd":
                    if (parts.Length != 2 || parts[1].ToLower() != "list")
                    {
                        Console.WriteLine("Invalid command. Usage: cmd list");
                        return;
                    }
                    DisplayCommandList();
                    break;

                default:
                    Console.WriteLine("Invalid command. Type 'cmd list' to see available commands.");
                    break;
            }
        }

        private void CreateFile(string filename, string content)
        {
            if (!files.ContainsKey(filename))
            {
                files.Add(filename, content);
                Console.WriteLine($"File '{filename}' created successfully.");
            }
            else
            {
                Console.WriteLine($"File '{filename}' already exists.");
            }
        }

        private void ReadFile(string filename)
        {
            if (files.ContainsKey(filename))
            {
                Console.WriteLine($"Content of file '{filename}':");
                Console.WriteLine(files[filename]);
            }
            else
            {
                Console.WriteLine($"File '{filename}' does not exist.");
            }
        }

        private void WriteFile(string filename, string content)
        {
            if (files.ContainsKey(filename))
            {
                files[filename] = content;
                Console.WriteLine($"Content of file '{filename}' updated successfully.");
            }
            else
            {
                Console.WriteLine($"File '{filename}' does not exist.");
            }
        }

        private void DeleteFile(string filename)
        {
            if (files.ContainsKey(filename))
            {
                files.Remove(filename);
                Console.WriteLine($"File '{filename}' deleted successfully.");
            }
            else
            {
                Console.WriteLine($"File '{filename}' does not exist.");
            }
        }

        private void Shutdown()
        {
            Console.WriteLine("Shutting down...");
            Sys.Power.Shutdown();
        }

        private void DisplayCommandList()
        {
            Console.WriteLine("Available commands:");
            Console.WriteLine("create [filename] [content] - Create a new file with the specified content.");
            Console.WriteLine("read [filename] - Read the content of the specified file.");
            Console.WriteLine("write [filename] [content] - Write or update the content of the specified file.");
            Console.WriteLine("delete [filename] - Delete the specified file.");
            Console.WriteLine("shutdown - Shutdown the system.");
            Console.WriteLine("cmd list - Display the list of available commands.");
        }
    }
}
-