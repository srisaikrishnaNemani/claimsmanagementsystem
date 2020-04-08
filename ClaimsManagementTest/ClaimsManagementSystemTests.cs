using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Claim_Management_Dao;
using Claim_Management_Model;

namespace ClaimsManagementTest
{
    [TestClass]
    public class ClaimsManagementSystemTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            Admin admin = new Admin("sufiyan@gmail.com", "sufiyan@123");
            Assert.AreEqual(admin.EmailId, "sufiyan@gmail.com");
            Assert.AreEqual(admin.Password, "sufiyan@123");
        }

        [TestMethod]
        public void TestMethod2()
        {
            Member member = new Member("sufiyan@gmail.com", "sabriya@123");
            Assert.AreEqual(member.EmailId, "sufiyan@gmail.com");
            Assert.AreEqual(member.Password, "sabriya@123");
        }
    }
}
