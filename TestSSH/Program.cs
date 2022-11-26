using Renci.SshNet;
using TestSSH.DatabaseContext;
using TestSSH.Models;

internal class Program
{
    static string _host = "192.168.43.107";
    static string _username = "fikalis";
    static string _password = "123";
    private static void Main(string[] args)
    {

        using (SshClient client = new SshClient(_host, _username, _password))
        {
            try
            {
                // подключение 
                client.Connect();                
                if (client.IsConnected)
                {                    
                    // не совсем понимаю, что это
                    var local = new ForwardedPortLocal("localhost", 5432, "localhost", 5432);                    
                    client.AddForwardedPort(local);
                    try
                    {

                        // 
                        local.Start();
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    using (var dbContext = new TestDbContextFactory().CreateDbContext())
                    {
                        /*TestModel testModel = new()
                        {
                            Id = 1
                        };
                        dbContext.Add(testModel);
                        dbContext.SaveChanges();*/
                    }


                    local.Stop();

                    // отключение от SSH-сервера
                    client.Disconnect();
                }                
            }
            catch (Exception)
            {
                throw;
            }
        }
        
    }
}