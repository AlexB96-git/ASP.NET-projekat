﻿namespace Application
{
        public interface IApplicationActor
        {
            int Id { get; }
            string Identity { get; }
            IEnumerable<int> AllowedUseCases { get; }
        }
}