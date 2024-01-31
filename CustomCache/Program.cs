var dataDownloader = new SlowDataDownloader();

Console.WriteLine(dataDownloader.DownloadData("id1"));
Console.WriteLine(dataDownloader.DownloadData("id2"));
Console.WriteLine(dataDownloader.DownloadData("id3"));
Console.WriteLine(dataDownloader.DownloadData("id1"));
Console.WriteLine(dataDownloader.DownloadData("id3"));
Console.WriteLine(dataDownloader.DownloadData("id1"));
Console.WriteLine(dataDownloader.DownloadData("id2"));

Console.WriteLine("Press any key to close.");
Console.ReadKey();

//CLASSE PER LA CACHE
public class Cache<TKey, TData>
{
    //I dati che andranno salvati saranno formattati in un dictionary
    private readonly Dictionary<TKey, TData> _cacheData = new();

    //Metodo che prende l'identificatore e ci restituisce i dati associati
    public TData Get(TKey key, Func<TKey, TData> getForTheFirstTime)
    {
        //Controlliamo se la chiave passata fosse già stata richiesta in precedenza
        if(!_cacheData.ContainsKey(key))
        {
            //Se non è stata richiesta, la cacheiamo
            _cacheData[key] = getForTheFirstTime(key);
        }

        //Ritorniamo i dati associati alla chiave
        return _cacheData[key];
    }
}

//INTERFACCIA PER IL FAKE DOWNLOAD
public interface IDataDownloader
{
    public string DownloadData(string resource);
}

//CLASSE PER IL FAKE DOWNLOAD
public class SlowDataDownloader : IDataDownloader
{
    public string DownloadData(string resourceId)
    {
        //Il programma viene fermato per 1 secondo prima di "scaricare" i dati
        Thread.Sleep(1000);
        return $"Some data for {resourceId}";
    }
}

