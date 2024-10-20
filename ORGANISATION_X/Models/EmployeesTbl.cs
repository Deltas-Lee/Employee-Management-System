using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ORGANISATION_X.Models
{
    public partial class EmployeesTbl
    {
        [Required]public int Age { get; set; }
        public string Attrition { get; set; }
        public string BusinessTravel { get; set; } 
        public int? DailyRate { get; set; }
        [Required]public string Department { get; set; }
        public string DistanceFromHome { get; set; }
        public string Education { get; set; }
        public string EducationField { get; set; }
        public string EmployeeCount { get; set; }
        [Required]
        [Display(Name ="Employee#")]
        public string EmployeeNumber { get; set; }
        public string EnvironmentSatisfaction { get; set; }
        public string Gender { get; set; }
        public int? HourlyRate { get; set; }
        public string JobInvolvement { get; set; }
        public string JobLevel { get; set; }
        //[Display(Name = "Role")]
        public string JobRole { get; set; }
        public string JobSatisfaction { get; set; }
        public string MaritalStatus { get; set; }
        public int? MonthlyIncome { get; set; }
        public int? MonthlyRate { get; set; }
        public string NumCompaniesWorked { get; set; }
        public string Over18 { get; set; }
        public string OverTime { get; set; }
        public int? PercentSalaryHike { get; set; }
        public int? PerformanceRating { get; set; }
        public string RelationshipSatisfaction { get; set; }
        public int? StandardHours { get; set; }
        public string StockOptionLevel { get; set; }
        [Required]
        public string TotalWorkingYears { get; set; }
        public string TrainingTimesLastYear { get; set; }
        public string WorkLifeBalance { get; set; }
        public string YearsAtCompany { get; set; }
        public string YearsInCurrentRole { get; set; }
        public string YearsSinceLastPromotion { get; set; }
        public string YearsWithCurrManager { get; set; }
    }
}
