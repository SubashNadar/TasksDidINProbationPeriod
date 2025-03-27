using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace JqueryAjaxWebApp.Models
{
    [MetadataType(typeof(EmployeeMetaData))]
    public partial class Employee { }
    public class EmployeeMetaData
    {

        [Remote("IsUserNameAvailable", "Employee", ErrorMessage = "Employee name already in use")]
        public string empname{get;set;}
    }
}
