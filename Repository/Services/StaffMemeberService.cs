using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services
{
    public class StaffMemberService
    {
        GenericRepository<StaffMember> _repository;

        public StaffMemberService()
        {
            _repository = new GenericRepository<StaffMember>();
        }

        public List<StaffMember> GetAllStaffMembers()
        {
            return _repository.GetAll();
        }

        public void AddStaffMember(StaffMember staffMember)
        {
            _repository.Add(staffMember);
        }

        public void UpdateStaffMember(StaffMember staffMember)
        {
            _repository.Update(staffMember);
        }

        public void DeleteStaffMember(StaffMember staffMember)
        {
            _repository.Delete(staffMember);
        }

        //public StaffMember GetStaffMemberById(int id)
        //{
        //    return _repository.GetAll().FirstOrDefault(m => m.MemberID == id);
        //}
    }
}
