using BusinessEntity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface ISubject
    {
        void CreateTable();
        Task<List<SubjectModel>> GetSubjectModels(int currentPage, int pageSize = 10);

        Task<int> GetCount();
    }
}
