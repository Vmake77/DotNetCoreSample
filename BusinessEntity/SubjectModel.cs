using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using Vega;

namespace BusinessEntity
{
    [Table(Name = "SubjectModel", NeedsHistory = false, NoUpdatedBy = true, NoUpdatedOn = true)]
    public class SubjectModel : EntityBase
    {
        [PrimaryKey(true)]
        public int SubjectId { get; set; }
        public string SubjectNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        [DataType(DataType.Date)]
        public DateTime RegistrationDate { get; set; }
        public bool Status { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public Language Languages { get; set; } = new Language();
        public int Height { get; set; }
        public int Weight { get; set; }
        public int BMI { get; set; }
        public string ContactNo { get; set; }
        public List<SelectListItem> GetLanguages { get; } = new List<SelectListItem>
        {
            new SelectListItem{  Value="1", Text="Gujarati", Selected=true},
            new SelectListItem{  Value="2", Text="hindi"},
            new SelectListItem{  Value="3", Text="English"}
        };

    }

    public class Language
    {
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
    }

    public class PaginationModel
    {
        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int Count { get; set; }
        public int PageSize { get; set; } = 1;
        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));
        public List<SubjectModel> Data { get; set; }
        public bool ShowPrevious => CurrentPage > 1;
        public bool ShowNext => CurrentPage < TotalPages;
        public bool ShowFirst => CurrentPage != 1;
        public bool ShowLast => CurrentPage != TotalPages;

        //public async Task OnGetAsync()
        //{
        //    Data = await _personService.GetPaginatedResult(CurrentPage, PageSize);
        //    Count = await _personService.GetCount();
        //}
    }
}
