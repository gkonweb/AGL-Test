using Microsoft.VisualStudio.TestTools.UnitTesting;
using AGL.Business.Service;
using AGL.Entity;

namespace AGL.Test
{
    [TestClass]
    public class PeopleServiceTest
    {
        [TestMethod]
        public void ShouldReturnPeople()
        {
            IPeopleService service = new PeopleService();

            var people = service.GetPeople();

            Assert.IsTrue(people != null && people.Count > 1);
        }
    }
}
