using RedStarter.Business.DataContract.SeedData;
using RedStarter.Database.DataContract.SeedData;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedStarter.Business.SeedData
{
    public class SeedDataManager : ISeedDataManager
    {
        private ISeedRepository _seedRepository;

        public SeedDataManager(ISeedRepository seedRepository)
        {
            _seedRepository = seedRepository;
        }

        public void SeedUsers()
        {
            _seedRepository.SeedUsers();
        }
    }
}
