using System.Net;
using System.Text;

namespace Customer
{
    public class HttpHealthcheck : BackgroundService
    {
        private readonly ILogger<Customer.Worker.Worker> _logger;
        private readonly HttpListener _httpListener;
        private readonly IConfiguration _configuration;


        public HttpHealthcheck(ILogger<Customer.Worker.Worker> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _httpListener = new HttpListener();
        }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            _httpListener.Prefixes.Add($"http://*:5015/healthz/live/");
            _httpListener.Prefixes.Add($"http://*:5016/healthz/ready/");

            _httpListener.Start();
            _logger.LogInformation($"Healthcheck listening...");

            while (!stoppingToken.IsCancellationRequested)
            {
                HttpListenerContext ctx = null;
                try
                {
                    ctx = await _httpListener.GetContextAsync();
                }
                catch (HttpListenerException ex)
                {
                    if (ex.ErrorCode == 995) return;
                }

                if (ctx == null) continue;

                var response = ctx.Response;
                response.ContentType = "text/plain";
                response.Headers.Add(HttpResponseHeader.CacheControl, "no-store, no-cache");
                response.StatusCode = (int)HttpStatusCode.OK;

                var messageBytes = Encoding.UTF8.GetBytes("Healthy");
                response.ContentLength64 = messageBytes.Length;
                await response.OutputStream.WriteAsync(messageBytes, 0, messageBytes.Length);
                response.OutputStream.Close();
                response.Close();
            }
        }
    }
}