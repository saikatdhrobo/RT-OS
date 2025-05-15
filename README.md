# RTOS

A simple Real-Time Operating System (RTOS) kernel built using the Cosmos OS framework in C#.

## Overview

This RTOS kernel provides basic file management commands and system control through a command-line interface. It demonstrates simple file creation, reading, writing, deletion, and system shutdown commands implemented with an in-memory file system.

## Features

- Create files with specified content
- Read file content
- Write/update content of existing files
- Delete files
- Shutdown the system
- Display list of available commands

## Available Commands

- `create [filename] [content]`  
  Create a new file with the specified content.

- `read [filename]`  
  Display the content of the specified file.

- `write [filename] [content]`  
  Write or update the content of the specified file.

- `delete [filename]`  
  Delete the specified file.

- `shutdown`  
  Shutdown the system.

- `cmd list`  
  Display the list of available commands.

## Usage

1. Boot the Cosmos kernel.
2. At the command prompt, type any supported command.
3. Follow on-screen instructions or error messages for proper usage.

## Code Structure

- Kernel class inherits from `Cosmos.System.Kernel`.
- Uses a `Dictionary<string, string>` as an in-memory file system.
- Overrides `BeforeRun()` to initialize and display welcome message.
- Overrides `Run()` to read and process user commands.
- Implements command parsing and validation.

## Notes

- This is a group project.
- No license specified.

---

Project developed by Saikat and Fahim.
