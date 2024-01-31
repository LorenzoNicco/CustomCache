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
