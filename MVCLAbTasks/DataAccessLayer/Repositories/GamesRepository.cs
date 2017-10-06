using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using DataAccessLayer.EFContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Entities.AbstractEntities;
using DataAccessLayer.Repositories.AbstractRepositories;

namespace DataAccessLayer.Repositories
{
    public class GamesRepository : ManipulationRepository<Game>
    {
        public GamesRepository(StoreDbContext dbContext) : base(dbContext)
        {
        }
    }
}
