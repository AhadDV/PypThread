using System.Diagnostics;

HttpClient HttpClient = new();
var list = new List<Task<string>>
{
    HttpClient.GetStringAsync("https://ahaddv.github.io/portfolio/"),
    HttpClient.GetStringAsync("https://beacon.az/"),
    HttpClient.GetStringAsync("http://birustmedia.az/"),
    HttpClient.GetStringAsync("https://ozonaptek.az/bio"),
};
var time =new Stopwatch();
time.Start();
await PrintHtmlLength(list);
Console.WriteLine(time.ElapsedMilliseconds+" "+" ms");

//ilk hansini elde etdise onu yazdirir ve buanda digerleri yuklenmeye davam edir

async Task PrintHtmlLength(List<Task<string>> list)
{
    while (list.Count > 0)
    {
        var result = await Task.WhenAny(list);
        Console.WriteLine($"{result.Result.Length}-length");
        list.Remove(result);
    }
}













