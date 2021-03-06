﻿using Diplom.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace Diplom.Models
{
    /// <summary>
    /// Пользователь для авторизации.
    /// </summary>
    public class LoginUser : ValidateViewModel
    {
        /// <summary>
        /// Логин.
        /// </summary>
        [Display(Name = "Логин")]
        [Required(ErrorMessage = "{0} не может быть пустым", AllowEmptyStrings = false)]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "{0} не должен быть больше {1} и не меньше {2} символов")]
        [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "{0} должен состоять из латинских букв и цифр")]
        public string Login { get; set; }

        /// <summary>
        /// Пароль.
        /// </summary>
        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "{0} не может быть пустым", AllowEmptyStrings = false)]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "{0} не должен быть больше {1} и не меньше {2} символов")]
        [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "{0} должен состоять из латинских букв и цифр")]
        public string Password { get; set; }
    }
}
