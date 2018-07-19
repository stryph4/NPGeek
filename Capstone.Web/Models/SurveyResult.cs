using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Capstone.Web.Models
{
    public class SurveyResult
    {
        public string ParkCode { get; set; }
        public string ParkName { get; set; }
        [Required(ErrorMessage = "*Email Address is Required")]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "*State of Residence is Required")]
        public string State { get; set; }
        [Required(ErrorMessage = "*Please Select Your Activity Level")]
        public string ActivityLevel { get; set; }
        public int SurveyCount { get; set; }



        public static List<SelectListItem> parks = new List<SelectListItem>()
        {
            new SelectListItem() {Text = "Cuyahoga Valley National Park", Value = "CVNP"},
            new SelectListItem() {Text = "Everglades National Park", Value = "ENP"},
            new SelectListItem() {Text = "Grand Canyon National Park", Value = "GCNP"},
            new SelectListItem() {Text = "Glacier National Park", Value = "GNP"},
            new SelectListItem() {Text = "Great Smoky Mountains National Park", Value = "GSMNP"},
            new SelectListItem() {Text = "Grand Teton National Park", Value = "GTNP"},
            new SelectListItem() {Text = "Mount Rainier National Park", Value = "MRNP"},
            new SelectListItem() {Text = "Rocky Mountain National Park", Value = "RMNP"},
            new SelectListItem() {Text = "Yellowstone National Park", Value = "YNP"},
            new SelectListItem() {Text = "Yosemite National Park", Value = "YNP2"},
            
        };

        public static List<SelectListItem> activityLevel = new List<SelectListItem>()
        {
            new SelectListItem() {Text = "Inactive", Value = "Inactive"},
            new SelectListItem() {Text = "Sedentary", Value = "Sedentary"},
            new SelectListItem() {Text = "Active", Value = "Active"},
            new SelectListItem() {Text = "Extremely Active", Value = "Extremely Active"}
        };
    }
}
