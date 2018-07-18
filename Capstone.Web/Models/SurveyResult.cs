using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Capstone.Web.Models
{
    public class SurveyResult
    {
        public int SurveyId { get; set; }
        public string ParkCode { get; set; }
        public string EmailAddress { get; set; }
        public string State { get; set; }
        public string ActivityLevel { get; set; }



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
    }
}
