using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Queridometro.API.Application.Commands;
using Queridometro.API.Data;
using Queridometro.Core.MediatorHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Queridometro.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<IRequestHandler<RegisterVoteCommand, ValidationResult>, QueridometroCommandHandler>();

            services.AddScoped<IRequestHandler<CreateParticipantCommand, ValidationResult>, ParticipantCommandHandler>();

            services.AddScoped<IQueridometroRepository, QueridometroRepository>();

            //services.AddScoped<INotificationHandler<ClienteRegistradoEvent>, ClienteEventHandler>();
        }
    }
}
