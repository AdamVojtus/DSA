using static XmlRecursion.XmlErrorComparer; 

namespace Tests
{
    public class XmlErrorComparerTests
    {
        [Test]
        public void GivenXmlErrorComparer_WhenCurrentHasSameValueAsStaged_ThenReturnFalse()
        {
            // arrange
            var currentData = @"<Scenarios ErrorSource=""Error"">
                                  <Scenario ErrorSource=""Error"">
                                    <SubScenario ErrorSource=""Error"" />
                                  </Scenario>
                                  <Scenario ErrorSource=""Error"">
                                    <SubScenario ErrorSource=""Error"" />
                                  </Scenario>
                                 </Scenarios>";

            var stagedData = @"<Scenarios ErrorSource=""Error"">
                                  <Scenario ErrorSource=""Error"">
                                    <SubScenario ErrorSource=""Error"" />
                                  </Scenario>
                                  <Scenario ErrorSource=""Error"">
                                    <SubScenario ErrorSource=""Error"" />
                                  </Scenario>
                                 </Scenarios>";

            // act
            var result = IsCurrentRunHavingLessErrors(currentData, stagedData);

            // assert
            Assert.IsFalse(result);
        }

        [Test]
        public void GivenXmlErrorComparer_WhenCurrentHasLessValueThanStaged_ThenReturnTrue()
        {
            // arrange
            var currentData = @"<Scenarios>
                                  <Scenario>
                                    <SubScenario />
                                  </Scenario>
                                  <Scenario ErrorSource=""Error"">
                                    <SubScenario ErrorSource=""Error"" />
                                  </Scenario>
                                 </Scenarios>";

            var stagedData = @"<Scenarios ErrorSource=""Error"">
                                  <Scenario ErrorSource=""Error"">
                                    <SubScenario ErrorSource=""Error"" />
                                  </Scenario>
                                  <Scenario ErrorSource=""Error"">
                                    <SubScenario ErrorSource=""Error"" />
                                  </Scenario>
                                 </Scenarios>";

            // act
            var result = IsCurrentRunHavingLessErrors(currentData, stagedData);

            // assert
            Assert.IsTrue(result);
        }

        [Test]
        public void GivenXmlErrorComparer_WhenCurrentHasSameValuAsCombinedInStaged_ThenReturnFalse()
        {
            // arrange
            var currentData = @"<Scenarios>
                                  <Scenario>
                                    <SubScenario />
                                  </Scenario>
                                  <Scenario>
                                    <SubScenario ErrorSource=""Error"" />
                                    <SubScenario ErrorSource=""Error"" />
                                    <SubScenario ErrorSource=""Error"" />
                                    <SubScenario />
                                  </Scenario>
                                 </Scenarios>";

            var stagedData = @"<Scenarios>
                                  <Scenario ErrorSource=""Error"">
                                    <SubScenario ErrorSource=""Error"" />
                                  </Scenario>
                                  <Scenario>
                                    <SubScenario ErrorSource=""Error"" />
                                    <SubScenario />
                                    <SubScenario />
                                    <SubScenario />
                                  </Scenario>
                                 </Scenarios>";

            // act
            var result = IsCurrentRunHavingLessErrors(currentData, stagedData);

            // assert
            Assert.IsFalse(result);
        }

        [Test]
        public void GivenXmlErrorComparer_WhenCurrentHasLessValueThanFullScenarioInStaged_ThenReturnFalse()
        {
            // arrange
            var currentData = @"<Scenarios>
                                  <Scenario>
                                    <SubScenario />
                                  </Scenario>
                                  <Scenario>
                                    <SubScenario ErrorSource=""Error"" />
                                    <SubScenario ErrorSource=""Error"" />
                                    <SubScenario />
                                  </Scenario>
                                 </Scenarios>";

            var stagedData = @"<Scenarios>
                                  <Scenario ErrorSource=""Error"">
                                    <SubScenario ErrorSource=""Error"" />
                                  </Scenario>
                                  <Scenario>
                                    <SubScenario ErrorSource=""Error"" />
                                    <SubScenario />
                                    <SubScenario />
                                  </Scenario>
                                 </Scenarios>";

            // act
            var result = IsCurrentRunHavingLessErrors(currentData, stagedData);

            // assert
            Assert.IsFalse(result);
        }
    }  
}
