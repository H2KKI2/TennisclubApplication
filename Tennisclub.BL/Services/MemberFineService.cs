using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tennisclub.BL.Services.ServiceInterfaces;
using Tennisclub.Common.MemberFineDTO;
using Tennisclub.DAL.Models;
using Tennisclub.DAL.Repositories.RepositorieInterfaces;

namespace Tennisclub.BL.Services
{
    public class MemberFineService : IMemberFineService
    {
        const int DECIMAL_FIRST_MAX_LENGTH = 7;
        const int DECIMAL_SECOND_MAX_LENGTH = 2;

        private readonly IMemberFineRepository _repository;

        public MemberFineService(IMemberFineRepository repository)
        {
            _repository = repository;
        }

        public MemberFineReadDto AddMemberFine(MemberFineCreateDto memberFine)
        {
            ValidationCheck(memberFine.Amount, memberFine.HandoutDate, memberFine.PaymentDate);
            MemberFineCheck(mf => mf.FineNumber == memberFine.FineNumber);
           return _repository.Add(memberFine);
        }

        public void CompleteMemberFine(MemberFineUpdateDto memberFine)
        {
            UpdateValidationCheck(memberFine.PaymentDate, memberFine.Id);
            MemberFineUpdateCheck(memberFine.Id);
            _repository.Update(memberFine);
        }

        public IEnumerable<MemberFineReadDto> GetAllFines()
        {
            return _repository.GetAll();
        }

        public IEnumerable<MemberFineReadDto> GetAllFinesByMemberId(int memberId)
        {
            return _repository.GetFinesByMemberId(memberId);
        }

        public IEnumerable<MemberFineReadDto> GetAllFinesFiltered(DateTime? handoutDate, DateTime? paymentDate)
        {
            return _repository.GetAllFiltered(memberFine => (memberFine.HandoutDate == handoutDate || handoutDate == null)
                                                        && (memberFine.PaymentDate == paymentDate || paymentDate == null));
        }

        private void ValidationCheck(decimal amount, DateTime handoutDate, DateTime? paymentDate)
        {
            string[] amountSplit = amount.ToString().Split(new char[] { '.' });
            int decimalFirstPart = amountSplit[0].Length;
            int decimalSecondPart = amountSplit[1].Length;

            if (amount != 0)
            {
                if (decimalFirstPart > DECIMAL_FIRST_MAX_LENGTH)
                    throw new ArgumentException($"There can only be {DECIMAL_FIRST_MAX_LENGTH} numbers becore the '.'");

                if (decimalSecondPart > DECIMAL_SECOND_MAX_LENGTH)
                    throw new ArgumentException($"There can only be {DECIMAL_SECOND_MAX_LENGTH} numbers after the '.'");
            }
            else
            {
                throw new ArgumentException("Amount is empty");
            }
            
            if (paymentDate != null)
            {
                if (handoutDate > paymentDate)
                    throw new ArgumentException("Payment date can't come before handout date");
            }
        }

        private void UpdateValidationCheck(DateTime paymentDate, int id) {
            MemberFineReadDto memberFine = _repository.GetById(id);

            if(memberFine.HandoutDate > paymentDate)
                throw new ArgumentException("Payment date can't come before handout date");
        }

        private void MemberFineCheck(Func<MemberFine, bool> filter)
        {
            IEnumerable<MemberFineReadDto> listMemberFines = _repository.GetAllFiltered(filter);
            if (listMemberFines.Count() != 0)
                throw new ArgumentException("Member fine is not unique");
        }

        private void MemberFineUpdateCheck(int id)
        {
            MemberFineReadDto memberFine = _repository.GetById(id);
            IEnumerable<MemberFineReadDto> listMemberFines = _repository.GetAllFiltered(mf => mf.FineNumber == memberFine.FineNumber && mf.Id != memberFine.Id);
            if (listMemberFines.Count() != 0)
                throw new ArgumentException("Member fine is not unique");
        }
    }
}
