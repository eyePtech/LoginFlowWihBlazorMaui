using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginFlowWithBlazorMaui.Models
{
	public class CountryModel
	{

        public int id { get; set; }

        public int language_id { get; set; }

        public string code { get; set; }

        public string description { get; set; }
    }
}

