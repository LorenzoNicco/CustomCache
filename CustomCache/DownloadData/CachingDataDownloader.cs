using CustomCache.DownloadData;
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
