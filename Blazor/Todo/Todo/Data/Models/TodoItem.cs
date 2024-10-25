namespace Todo.Data.Models;

public class TodoItem
{
    public long Id { get; set; }
    public string Name { get; set; } = "Make a todo list.";
    public bool IsComplete { get; set; } = false;
}