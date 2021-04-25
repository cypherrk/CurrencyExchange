using Microsoft.Extensions.DependencyInjection;
using ExternalWebApi.Biz;
using MediatR;
using System.Reflection;
using AutoMapper;

namespace ExternalWebApi.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services) 
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient<IGetCurrencyExchangeRates, GetCurrencyExchangeRates>();
            services.AddTransient<IGetLatestCurrencyExchangeRates, GetLatestCurrencyExchangeRates>();               
            services.AddTransient<IGetCurrencyExchangeRatesFromCache, GetCurrencyExchangeRatesFromCache>();
            services.AddTransient<ISetCurrencyExchangeRatesToCache, SetCurrencyExchangeRatesToCache>();
            services.AddTransient<IRefreshLatestCurrencyExchangeRates, RefreshLatestCurrencyExchangeRates>();
            return services;
        }
        
    }
}