using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Net.WebSockets;
using System.Timers;
using System.Xml.Serialization;

class Program
{
    static void Main(string[] args)
    {
        //si no tengo comandos no hago nada
        if (args == null || args.Length == 0)
        {
            Console.WriteLine("No se han ingresado comandos");
            ListarComandos();
            return;
        }

        if (!Commands.TryGetValue(args[0], out var command))
        {
            Console.WriteLine($"No conozco el comando {args[0]}");
            ListarComandos();
            return;
        }

        command.Execute(args, new TaskService());
    }

    static Dictionary<string, ICommand> Commands = new Dictionary<string, ICommand> {
        {
            "add", new AddCommand()
        },
        {
            "update", null
        },
        {
            "delete", null
        },
        {
            "mark-done", null
        },
        {
            "mark-in-progress", null
        },
        {
            "list", null
        }
    };

    static void ListarComandos()
    {
        Console.WriteLine("Comandos disponibles:");
        Console.WriteLine(string.Join(" - ", Commands.Keys));
    }
}