using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoqTestPJ;
using Moq;

namespace LibraryCoreTest
{
    [TestClass]
    public class LibraryCoreTest
    {
        private LibraryCore _target;
        private Mock<IMemberManager> _mock;

        [TestMethod]
        public void CalculateMemberShipCostTest()
        {
            _mock = new Mock<IMemberManager>();
            _target = new LibraryCore(_mock.Object);

            //Arrange
            Member member = new Member()
            {
                MemberID = 1,
                FirstName = "Tang",
                SecondName = "Tuan",
                Age = 27,
                MaximumBookCanBorrow = 4
            };

            //Act
            _mock.Setup(x => x.GetMember(It.IsAny<int>())).Returns(member);

            //Assert
            double expected = 12;
            double actual = _target.CalculateMemberShipCost(member.MemberID); ;
            Assert.AreEqual(expected, actual);
        }
    }
}
