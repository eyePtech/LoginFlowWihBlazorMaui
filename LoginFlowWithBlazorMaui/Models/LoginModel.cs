using System;
using System.ComponentModel.DataAnnotations;

namespace LoginFlowWithBlazorMaui.Models
{
	public class LoginModel
	{
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

