using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tennisclub.BL.Services.ServiceInterfaces;
using Tennisclub.Common.RoleDTO;
using Tennisclub.DAL.Models;
using Tennisclub.DAL.Repositories.RepositorieInterfaces;

namespace Tennisclub.BL.Services
{
    class RoleService : IRoleService
    {
        const int ROLE_NAME_MAX_LENGTH = 20;

        private readonly IRoleRepository _repository;

        public RoleService(IRoleRepository repository)
        {
            _repository = repository;
        }
        public RoleReadDto AddRole(RoleCreateDto role)
        {
            ValidationCheck(role.Name);
            RoleNameCheck(r => r.Name == role.Name);
            return _repository.Add(role);
        }

        public IEnumerable<RoleReadDto> GetAllRoles()
        {
            return _repository.GetAll();
        }

        public RoleReadDto GetRoleById(int id)
        {
            return _repository.GetById(id);
        }

        public RoleReadDto UpdateRole(RoleUpdateDto role)
        {
            ValidationCheck(role.Name);
            RoleNameCheck(r => r.Name == role.Name && r.Id != role.Id);
            return _repository.Update(role);
        }

        private void ValidationCheck(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length > ROLE_NAME_MAX_LENGTH)
                throw new ArgumentException($"Role name cannot be empty or longer than {ROLE_NAME_MAX_LENGTH}");
        }

        private void RoleNameCheck(Func<Role, bool> filter)
        {
            IEnumerable<RoleReadDto> listRoles = _repository.GetAllFiltered(filter);
            if (listRoles.Count() != 0)
                throw new ArgumentException("Role name is not unique");
        }
    }
}
