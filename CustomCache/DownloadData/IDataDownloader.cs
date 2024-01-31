namespace CustomCache.DownloadData
{
    //INTERFACCIA PER IL FAKE DOWNLOAD
    public interface IDataDownloader
    {
        public string DownloadData(string resource);
    }
}
