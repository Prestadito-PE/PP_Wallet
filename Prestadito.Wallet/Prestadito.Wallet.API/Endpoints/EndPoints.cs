namespace Prestadito.Wallet.API.Endpoints
{
    public static class EndPoints
    {
        readonly static string basePath = "/api";
        public static WebApplication UseWalletEndpoints(this WebApplication app)
        {
            app.UseDepositEndpoints(basePath);

            return app;
        }
    }
}
