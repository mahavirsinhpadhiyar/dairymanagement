using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace DairyManagement.ViewModels.Login
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "કૃપા કરીને વપરાશકર્તા નામ દાખલ કરો")]
        public string Username { get; set; }
        [Required(ErrorMessage = "કૃપા કરીને પાસવર્ડ દાખલ કરો")]
        public string Password { get; set; }
        public string ErrorMessage { get; set; }
    }
}