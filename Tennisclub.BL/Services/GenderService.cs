using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub.BL.Services.ServiceInterfaces;
using Tennisclub.Common.GenderDTO;
using Tennisclub.DAL.Repositories.RepositorieInterfaces;

namespace Tennisclub.BL.Services
{
    class GenderService : IGenderService
    {
        private readonly IGenderRepository _repository;

        public GenderService(IGenderRepository repository)
        {
            _repository = repository;
        }
        public IEnumerable<GenderReadDto> GetAllGenders()
        {
            return _repository.GetAll();
        }
    }
}
