using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using BusinessEntity;
using Microsoft.Extensions.Configuration;

using Vega;
using System.Linq;

namespace DataAccess
{
    public class EmployeeRepository : IEmployee
    {
        #region Private Properties
        private readonly IConfiguration _configuration;
        private Repository<EmployeeModel> employeeRepository { get; set; }

        #endregion

        public EmployeeRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool Delete(int Id)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                employeeRepository = new Repository<EmployeeModel>(connection);
                return employeeRepository.Delete(Id, 1);
            }
        }

        public EmployeeModel GetEmployeeById(int employeeId)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                employeeRepository = new Repository<EmployeeModel>(connection);
                return employeeRepository.ReadOne(employeeId);
            }
        }

        public List<EmployeeModel> GetEmployees()
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                employeeRepository = new Repository<EmployeeModel>(connection);

                if (!employeeRepository.IsTableExists())
                    employeeRepository.CreateTable();

                return employeeRepository.ReadAll(RecordStatusEnum.Active).ToList();
            }
        }
        public int Insert(EmployeeModel employeeModel)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                employeeRepository = new Repository<EmployeeModel>(connection);
                employeeModel.IsActive = true;
                employeeModel.VersionNo = 1;
                employeeModel.CreatedBy = 1;
                return (int)employeeRepository.Add(employeeModel);
            }
        }

        public bool Update(EmployeeModel employeeModel)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                employeeRepository = new Repository<EmployeeModel>(connection);
                employeeModel.UpdatedBy = 1; //TODO Maintain Session
                return employeeRepository.Update(employeeModel);
            }
        }
    }
}
