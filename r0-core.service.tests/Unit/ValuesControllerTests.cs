using System.Linq;
using Microsoft.Extensions.Logging;
using Moq;
using r0_core.service.Controllers;
using Xunit;

namespace r0_core.service.tests.Unit
{
    public class ValuesControllerTests
    {
        private readonly ValuesController _service;

        private readonly ILogger<ValuesController> _logger = new Mock<ILogger<ValuesController>>().Object;

        public ValuesControllerTests()
        {
            _service = new ValuesController(_logger);
        }

        [Fact(DisplayName = "Get() method in ValuesController returns a string array with two elements")]
        public void GetWithoutParamsReturnsStringArray()
        {
            var array = _service.Get();

            Assert.IsType<string[]>(array);
            Assert.Equal(array.Count(), 2);
        }

        [Fact(DisplayName = "Get() method value in ValuesController returns the string 'value' when passed an integer parameter")]
        public void GetWithIntParamReturnsValue()
        {
            Assert.Equal("value", _service.Get(0));
        }
    }
}
