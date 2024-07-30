using MongoDB.Driver;

namespace minimalApiMongo.Services
{
    public class MongoDBService
    {
        private readonly IConfiguration _configuration;
        private readonly IMongoDatabase _database;

        public MongoDBService(IConfiguration configuration)
        {
            // Atribui a config recebida em _configuration
            _configuration = configuration;

            // Acessa a string de conexão
            var ConnectionString = _configuration.GetConnectionString("DbConnection");

            // Transforma a string obtida em MongoUrl
            var mongoUrl = MongoUrl.Create(ConnectionString);

            // Cria um client 
            var mongoClient = new MongoClient(mongoUrl);

            // Obtem a referência ao MongoDB
            _database = mongoClient.GetDatabase(mongoUrl.DatabaseName);
        }

        /// <summary>
        /// Propriedade para acessar o banco de dados => retorna os dados em _database
        /// </summary>
        public IMongoDatabase GetDatabase => _database;
    }
}
