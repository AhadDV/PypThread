HttpClient HttpClient = new();
var list = new List<Task<string>>
{
    HttpClient.GetStringAsync("https://www.youtube.com/watch?v=GQZpGgwHGj4"),
    HttpClient.GetStringAsync("https://www.facebook.com/ehed.tagyev.14"),
    HttpClient.GetStringAsync("https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/"),
    HttpClient.GetStringAsync("https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/")
};
await PrintHtmlLength(list);



async Task PrintHtmlLength(List<Task<string>> list)
{
    while (list.Count > 0)
    {
        var result = await Task.WhenAny(list);
        Console.WriteLine($"{result.Result.Length}");
        list.Remove(result);
    }
}













