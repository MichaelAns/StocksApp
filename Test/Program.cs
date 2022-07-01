const string _uri = @"https://iss.moex.com/iss/engines/stock/markets/shares/securities.json?iss.meta=off&securities.columns=SECID,SECNAME&iss.version=off&iss.only=securities";
Console.WriteLine(await GetStocksAsync());

static async Task<Stream> GetStocksStreamAsync()
{    
    using (var client = new HttpClient())
    {
        var response = await client.GetAsync(_uri);
        return await response.Content.ReadAsStreamAsync();
        //return await client.GetStreamAsync(_uri);
    }
}
static async Task<string> GetStocksAsync()
{
    using (var client = new HttpClient())
    {
        var response = await client.GetAsync(_uri);
        string jsonResponse  = await response.Content.ReadAsStringAsync();
        return jsonResponse;
    }
    //using var dataStream = GetStocksStreamAsync().Result;
    //using var dataReader = new StreamReader(dataStream);
    //return await dataReader.ReadToEndAsync();
}

