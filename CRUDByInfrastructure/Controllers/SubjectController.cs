using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessEntity;
using DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace CRUDByInfrastructure.Controllers
{
    public class SubjectController : BaseController
    {
        public SubjectController(ISubject subject)
        {
            Subject = subject;

            Subject.CreateTable();
        }
        public async Task<IActionResult> IndexAsync(PaginationModel model)
        {
            model.Data = await Subject.GetSubjectModels(model.CurrentPage, model.PageSize);
            model.Count = await Subject.GetCount();
            return View(model);
        }
    }
}