Console.WriteLine(dataDownloader.DownloadData("id1");
Console.WriteLine(dataDownloader.DownloadData("id2");
Console.WriteLine(dataDownloader.DownloadData("id3");
Console.WriteLine(dataDownloader.DownloadData("id1");
Console.WriteLine(dataDownloader.DownloadData("id3");
Console.WriteLine(dataDownloader.DownloadData("id1");
Console.WriteLine(dataDownloader.DownloadData("id2");



public class SlowDataDownloader : IDataDownloader
{
    public string DownloadData(string resourceId)
    {
        Thread.Sleep(1000);
        return $"Some data for {resourceId}";
    }
}