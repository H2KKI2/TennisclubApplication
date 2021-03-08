using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tennisclub.BL.Services.ServiceInterfaces;
using Tennisclub.Common.MemberDTO;
using Tennisclub.DAL.Models;
using Tennisclub.DAL.Repositories;

namespace Tennisclub.BL.Services
{
    public class MemberService : IMemberService
    {
        const int FEDERATIONNR_MAX_LENGTH = 10;
        const int FIRST_NAME_MAX_LENGTH = 25;
        const int LAST_NAME_MAX_LENGTH = 35;
        const int ADDRESS_MAX_LENGTH = 70;
        const int NUMBER_MAX_LENGTH = 6;
        const int ADDITION_MAX_LENGTH = 2;
        const int ZIPCODE_MAX_LENGTH = 6;
        const int CITY_MAX_LENGTH = 30;
        const int PHONENR_MAX_LENGTH = 15;

        private readonly IMemberRepository _repository;

        public MemberService(IMemberRepository repository)
        {
            _repository = repository;
        }
        public IEnumerable<MemberReadDto> GetAllMembers()
        {
            return (IEnumerable<MemberReadDto>)_repository.GetAll();
        }
        public IEnumerable<MemberReadDto> GetAllMembersFiltered(string federationNr, string firstName, string lastName, string city, string zipcode)
        {
            return _repository.GetAllFiltered(member => (member.FederationNr == federationNr || federationNr == null)
                                                        && (member.FirstName == firstName || firstName == null)
                                                        && (member.LastName == lastName || lastName == null)
                                                        && (member.City == city || city == null)
                                                        && (member.Zipcode == zipcode || zipcode == null));
        }
        public MemberReadDto GetMemberById(int id)
        {
            return _repository.GetById(id);
        }
        public MemberReadDto AddMember(MemberCreateDto member)
        {
            ValidationCheck(member.FederationNr, member.FirstName, member.LastName, member.Birthdate, member.GenderId, member.Address, member.Number, member.Addition,
                            member.Zipcode, member.City, member.PhoneNr);
            FederationNrCheck(m => m.FederationNr == member.FederationNr);
            return _repository.Add(member);
        }
        public void UpdateMember(MemberUpdateDto member)
        {
            ValidationCheck(member.FederationNr, member.FirstName, member.LastName, member.Birthdate, member.GenderId, member.Address, member.Number, member.Addition,
                            member.Zipcode, member.City, member.PhoneNr);
            FederationNrCheck(m => m.FederationNr == member.FederationNr && m.Id != member.Id);
            _repository.Update(member);
        }

        public void DeleteMember(int id)
        {
            _repository.DeleteMember(id);
        }
        public void RestoreMember(int id)
        {
            _repository.RestoreMember(id);
        }

        private void ValidationCheck(string federationNr, string firstName, string lastName, DateTime? birthdate, byte genderId, string address, string number, string addition,
                                     string zipcode, string city, string phoneNr)
        {
            if (string.IsNullOrWhiteSpace(federationNr) || federationNr.Length > FEDERATIONNR_MAX_LENGTH)
                throw new ArgumentException($"FederationNr cannot be empty or longer than {FEDERATIONNR_MAX_LENGTH}");

            if (string.IsNullOrWhiteSpace(firstName) || firstName.Length > FIRST_NAME_MAX_LENGTH)
                throw new ArgumentException($"First name cannot be empty or longer than {FIRST_NAME_MAX_LENGTH}");

            if (string.IsNullOrWhiteSpace(lastName) || lastName.Length > LAST_NAME_MAX_LENGTH)
                throw new ArgumentException($"Last name cannot be empty or longer than {LAST_NAME_MAX_LENGTH}");

            if (!birthdate.HasValue)
                throw new NullReferenceException("Birthdate cant be empty");

            if (genderId <= 0)
                throw new NullReferenceException("Gender cannot be empty");

            if (string.IsNullOrWhiteSpace(address) || address.Length > ADDRESS_MAX_LENGTH)
                throw new ArgumentException($"Address cannot be empty or longer than {ADDRESS_MAX_LENGTH}");

            if (string.IsNullOrWhiteSpace(number) || number.Length > NUMBER_MAX_LENGTH)
                throw new ArgumentException($"Number cannot be empty or longer than {NUMBER_MAX_LENGTH}");

            if (addition.Length > ADDITION_MAX_LENGTH)
                throw new ArgumentException($"Addition cannot be longer than {ADDITION_MAX_LENGTH}");

            if (string.IsNullOrWhiteSpace(zipcode) || zipcode.Length > ZIPCODE_MAX_LENGTH)
                throw new ArgumentException($"Zipcode cannot be empty or longer than {ZIPCODE_MAX_LENGTH}");

            if (string.IsNullOrWhiteSpace(city) || city.Length > CITY_MAX_LENGTH)
                throw new ArgumentException($"City cannot be empty or longer than {CITY_MAX_LENGTH}");

            if (phoneNr.Length > PHONENR_MAX_LENGTH)
                throw new ArgumentException($"PhoneNr cannot be longer than {PHONENR_MAX_LENGTH}");
        }

        private void FederationNrCheck(Func<Member, bool> filter)
        {
            IEnumerable<MemberReadDto> listMembers = _repository.GetAllMembersWithDeletedFiltered(filter);
            if (listMembers.Count() != 0)
                throw new ArgumentException("FederationNr is not unique");
        }
    }
}
