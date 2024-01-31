using CustomCache.DownloadData;
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
