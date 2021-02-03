﻿using MediatR;
using System;

namespace Queridometro.Core.DomainObjects
{
    public class Event : Message, INotification
    {
        public DateTime Timestamp { get; private set; }
        protected Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}