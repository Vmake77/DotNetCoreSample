using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BusinessEntity;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Vega;

namespace DataAccess
{
    public class SubjectRepository : ISubject
    {
        private readonly IConfiguration _configuration;
        private Repository<SubjectModel> subjectRepository;
        public SubjectRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<List<SubjectModel>> GetSubjectModels(int currentPage, int pageSize = 10)
        {
            var data = await GetData();
            return data.OrderBy(d => d.SubjectId).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
        }
        public async Task<int> GetCount()
        {
            var data = await GetData();
            return data.Count;
        }

        private async Task<List<SubjectModel>> GetData()
        {
            List<SubjectModel> subjectModels = new List<SubjectModel>();
            for (int i = 1; i < 10000; i++)
            {
                SubjectModel subjectModel = new SubjectModel
                {
                    BMI = +i,
                    ContactNo = "123456455" + i,
                    DateOfBirth = new DateTime(),
                    FirstName = "FirstName" + i,
                    Height = i,
                    LastName = "LastName" + i,
                    MiddleName = "MiddleName" + i,
                    RegistrationDate = new DateTime(),
                    Status = default(bool),
                    SubjectId = i,
                    SubjectNumber = "Subject" + i,
                    Weight = 10 + i,
                    Languages = new Language { LanguageId = 1, LanguageName = "Gujarati" }
                };
                subjectModels.Add(subjectModel);
            }
            return subjectModels;
        }

        public void CreateTable()
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                subjectRepository = new Repository<SubjectModel>(connection);
                if (!subjectRepository.IsTableExists())
                {
                    _ = subjectRepository.CreateTable();
                }
            }
        }
    }
}
