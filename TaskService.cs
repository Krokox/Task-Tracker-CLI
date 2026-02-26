using System.IO;
using System.Text.Json;
using System.Collections.Generic;

public class TaskService
{
    private string filePath = "tasks.json"; //Define donde esta el archivo JSON
    public List<Task> Tasks { get; private set; } // list <task> es donde guardamos los objetos de task, private set: solo la taskservice puede cambiar la lista de tareas, public get: cualquier clase puede acceder a la lista de tareas

    public TaskService() //el constructor se ejecuta cuando creas un objeto taskservice 
    {
        if (File.Exists(filePath)) //si el archivo JSON no existe, lo crea con una lista vacia de tareas
        {
            // lee el archivo JSON y lo convierte en una lista de Task
            string json = File.ReadAllText(filePath);
            Tasks = JsonSerializer.Deserialize<List<Task>>(json);
        }
        else
        {
            //Crea una lista vacia y escribe un JSON vacio
            Tasks = new List<Task>();
            Save();
        }
    }

    public void Save()
    {
        File.WriteAllText(filePath, JsonSerializer.Serialize(Tasks));
    }
}