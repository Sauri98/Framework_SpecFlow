using FrameworkTest_Specflow.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkTest_Specflow.Test_cases
{
    class UserForm_TestCases
    {
        public static void UserFormValidation()
        {
            UserForm.userForm();

            //title
            UserForm.SelectDropDown("TitleId", "Mr.", PropertyType.Id);
            //Initial
            UserForm.EnterText("Initial", "Saurabh", PropertyType.Name);
            //Click
            UserForm.Click("Save", PropertyType.Name);

        }

    }
}
