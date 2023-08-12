using AutoMapper;
using Core.Models;
using Nest;

public interface IElasticsearchService
{
    void Log(LogInput logInput);
}

public class ElasticsearchService : IElasticsearchService
{
    private readonly IElasticClient _elasticClient;
    private readonly IMapper _mapper;

    public ElasticsearchService(IConfiguration configuration, IMapper mapper)
    {
        var settings = new ConnectionSettings(new Uri(configuration["ElasticsearchSettings:Uri"]!))
            .DefaultIndex(configuration["ElasticsearchSettings:DefaultIndex"]);

        _elasticClient = new ElasticClient(settings);
        _mapper = mapper;
    }

    public void Log(LogInput logInput)
    {
        var log = _mapper.Map<Log>(logInput);
        log.Timestamp = DateTime.Now;
        var indexResponse = _elasticClient.Index(log, index => index.Index(log.Application));
    }
}
