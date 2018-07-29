using System.Net;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
{
    log.Info("C# HTTP trigger function processed a request.");

    var connectionString = Environment.GetEnvironmentVariable("MySQL");

    List<Chmuromaniak> chmuromaniacy = new List<Chmuromaniak>();

    using (var conn = new MySqlConnection(connectionString))
    {
        log.Info("Opening connection");
        await conn.OpenAsync();

        using (var command = conn.CreateCommand())
        {
            command.CommandText = "SELECT * FROM chmuromaniacy;";

            using (var reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    var chmuromaniak = new Chmuromaniak(reader.GetString(1), reader.GetString(2));
                    chmuromaniacy.Add(chmuromaniak);
                    log.Info($"Reading from table=({reader.GetString(1)} {reader.GetString(2)})");
                }
            }
        }

        log.Info("Closing connection");
    }

    return req.CreateResponse(HttpStatusCode.OK, chmuromaniacy);
}

public class Chmuromaniak
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Chmuromaniak(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
}