﻿using BookStore.Application.Exceptions;
using BookStore.Application.Logging;
using BookStore.Application.UseCases;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.UseCaseHandling
{
    public interface ICommandHandler
    {
        void HandleCommand<TRequest>(ICommand<TRequest> command, TRequest data);
    }
    public class CommandHandler : ICommandHandler
    {
        private IApplicationActor _actor;
        private IUseCaseLogger _logger;

        public CommandHandler(IApplicationActor actor, IUseCaseLogger logger)
        {
            _actor = actor;
            _logger = logger;
        }

        public void HandleCommand<TRequest>(ICommand<TRequest> command, TRequest data)
        {
            if (!_actor.AllowedUseCases.Contains(command.Id))
            {
                throw new UnauthorizedUseCaseExecutionException(_actor.Username, command.Name);
            }

            _logger.Add(new UseCaseLogEntry
            {
                Actor = _actor.Username,
                ActorId = _actor.Id,
                Data = data,
                UseCaseName = command.Name
            });

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            command.Execute(data);

            stopwatch.Stop();

            Console.WriteLine("Execution time:" + stopwatch.ElapsedMilliseconds + " UseCase: " + command.Name + " User: "/* + _actor.Username*/);
        }
    }
}
