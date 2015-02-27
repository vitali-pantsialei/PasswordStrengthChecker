using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordStrengthChecker;

namespace PasswordStrengthCheckerTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void VerifyTest_If_Login_Null_ReturnFalse()
        {
            PasswordChecker pc = new PasswordChecker();
            string msg;

            bool res = pc.Verify(null, "dgdf", false, out msg);

            Assert.IsFalse(res);
        }

        [TestMethod]
        public void VerifyTest_If_Password_Null_ReturnFalse()
        {
            PasswordChecker pc = new PasswordChecker();
            string msg;

            bool res = pc.Verify("fdgd", null, false, out msg);

            Assert.IsFalse(res);
        }

        [TestMethod]
        public void VerifyTest_If_Login_And_Password_Null_ReturnFalse()
        {
            PasswordChecker pc = new PasswordChecker();
            string msg;

            bool res = pc.Verify(null, null, false, out msg);

            Assert.IsFalse(res);
        }

        [TestMethod]
        public void VerifyTest_If_Password_Length_Less_7_ReturnFalse()
        {
            PasswordChecker pc = new PasswordChecker();
            string msg;

            bool res = pc.Verify("user", "mypwd", false, out msg);

            Assert.IsFalse(res);
        }

        [TestMethod]
        public void VerifyTest_If_Password_Not_Contain_AtLeast_1_Alpha_ReturnFalse()
        {
            PasswordChecker pc = new PasswordChecker();
            string msg;

            bool res = pc.Verify("user", "1473434534534534534", false, out msg);

            Assert.IsFalse(res);
        }

        [TestMethod]
        public void VerifyTest_If_Password_Not_Contain_AtLeast_1_Digit_ReturnFalse()
        {
            PasswordChecker pc = new PasswordChecker();
            string msg;

            bool res = pc.Verify("user", "dsfdsdssfdsgddsfds", false, out msg);

            Assert.IsFalse(res);
        }

        [TestMethod]
        public void VerifyTest_If_Password_Length_Less_10_ForAdmins_ReturnFalse()
        {
            PasswordChecker pc = new PasswordChecker();
            string msg;

            bool res = pc.Verify("user", "12345678g", true, out msg);

            Assert.IsFalse(res);
        }

        [TestMethod]
        public void VerifyTest_If_Password_NotContain_AtLeast_1_Special_Char_ForAdmins_ReturnFalse()
        {
            PasswordChecker pc = new PasswordChecker();
            string msg;

            bool res = pc.Verify("user", "12345678g6876786", true, out msg);

            Assert.IsFalse(res);
        }
    }
}
