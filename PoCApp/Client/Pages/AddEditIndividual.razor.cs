using Microsoft.AspNetCore.Components;
using PoCApp.Client.Entities;
using PoCApp.Client.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoCApp.Client.Pages
{
    public partial class AddEditIndividual
    {
        [Inject]
        public NavigationManager _navigationManager { get; set; }

        [Inject]
        public HttpService _studentService { get; set; }

        public Individual ObjStudent { get; set; } = new Individual();

        public List<Education> _residenceTypes { get; set; } = new List<Education>();
        public List<Country> _modeOfTranspots { get; set; } = new List<Country>();


        [Parameter]
        public string StudentGuid { get; set; }

        protected async override Task OnInitializedAsync()
        {

            _residenceTypes = (await _studentService.()).ToList();
            _modeOfTranspots = (await _studentService.GetModeOfTranspots()).ToList();


            if (!string.IsNullOrEmpty(StudentGuid))
            {
                ObjStudent = await _studentService.GetStudentByGuid(new Guid(StudentGuid));
            }
            // return base.OnInitializedAsync();
        }

        public async Task HandleValidSubmit()
        {
            if (ObjStudent.StudentId == 0)
            {
                ObjStudent.CreatedDate = DateTime.Now;
                ObjStudent.StudentGuid = Guid.NewGuid();

            }
            ObjStudent.ModifiedDate = DateTime.Now;
            await _studentService.Save(ObjStudent);
            _navigationManager.NavigateTo("/Students");

        }

        public void HandleInvalidSubmit()
        {

        }
        public void OnCancleClick()
        {
            _navigationManager.NavigateTo("/Students");
        }


    }
}
