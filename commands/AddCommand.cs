
public class AddCommand : ICommand
{
    public void Execute(string[] args, TaskService taskService)
    {
        Console.WriteLine("Executing Add Command...");
        // Add your logic for the Add command here

        //logica del add
        //primero se fija si hay minimo dos argumentos, el primero es el titulo y el segundo la descripcion
        // si no hay dos argumentos, muestra un mensaje de error
        if (args.Length < 1)
        {
            Console.WriteLine("Error: Debes proporcionar una descripción");
            Console.WriteLine("Uso: add <descripción>");
            return;
        }
        //si hay argumentos, crea una nueva tarea con  la descripcion y la agrega a la lista de tareas con una id
        string description = string.Join(" ", args); //Une las cadenas que escribio el usuario

        taskService.Add(description); //Ejecuta el metodo que cree anteriormente

        Console.WriteLine("...");
        Console.WriteLine("Tarea agregada");
    }
}