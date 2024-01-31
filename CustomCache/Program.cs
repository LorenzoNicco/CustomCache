IDataDownloader dataDownloader = new CachingDataDownloader(new SlowDataDownloader());

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

//CLASSE PER DOWNLOAD CON CACHE SECONDO DECORATOR DESIGN PATTERN
public class CachingDataDownloader : IDataDownloader
{
    //Creiamo un'istanza dell'interfaccia oggetto da "decorare"
    private readonly IDataDownloader _dataDownloader;
    //Creiamo un'istanza della classe cache
    private readonly Cache<string, string> _cache = new();

    //Costruttore
    public CachingDataDownloader(IDataDownloader dataDownloader)
    {
        _dataDownloader = dataDownloader;
    }

    //Mmetodo per effettuare il fake download con la cache
    public string DownloadData(string resourceId)
    {
        return _cache.Get(resourceId, _dataDownloader.DownloadData);
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
    //metodo per effettuare il fake download
    public string DownloadData(string resourceId)
    {
        //Il programma viene fermato per 1 secondo prima di "scaricare" i dati
        Thread.Sleep(1000);
        return $"Some data for {resourceId}";
    }
}

