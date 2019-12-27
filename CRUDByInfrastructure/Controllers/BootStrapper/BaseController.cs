using DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace CRUDByInfrastructure.Controllers
{
    public class BaseController : Controller
    {
        public IEmployee Employee { get; set; }

        public ISubject Subject { get; set; }
    }
}
