using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;

namespace Taskever.Tasks.Dto
{
    public class GetTasksInput : IInputDto, IPagedResultRequest, ICustomValidate
    {
        [Range(1, int.MaxValue)]
        public int AssignedUserId { get; set; }

        public List<TaskState> TaskStates { get; set; }

        public int SkipCount { get; set; }

        public int MaxResultCount { get; set; }

        public GetTasksInput()
        {
            MaxResultCount = int.MaxValue;
            TaskStates = new List<TaskState>();
        }

        public void AddValidationErrors(List<ValidationResult> results)
        {
            //TODO: For demonstration, do it declarative!
            if (AssignedUserId <= 0)
            {
                results.Add(new ValidationResult("AssignedUserId must be a positive value!", new[] { "AssignedUserId" }));
            }
        }
    }
}