using static XmlRecursion.XmlErrorComparer; 

namespace Tests
{
    public class XmlErrorComparerTests
    {
        [Test]
        public void GivenXmlErrorComparer_WhenCurrentHasSameValueAsStaged_ThenReturnFalse()
        {
            // arrange
            var currentData = @"<Scenarios ErrorSource=""Torus"">
                                  <Scenario ErrorSource=""Torus"">
                                    <SubScenario ErrorSource=""Torus"" />
                                  </Scenario>
                                  <Scenario ErrorSource=""Torus"">
                                    <SubScenario ErrorSource=""Torus"" />
                                  </Scenario>
                                 </Scenarios>";

            var stagedData = @"<Scenarios ErrorSource=""Torus"">
                                  <Scenario ErrorSource=""Torus"">
                                    <SubScenario ErrorSource=""Torus"" />
                                  </Scenario>
                                  <Scenario ErrorSource=""Torus"">
                                    <SubScenario ErrorSource=""Torus"" />
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
                                  <Scenario ErrorSource=""Torus"">
                                    <SubScenario ErrorSource=""Torus"" />
                                  </Scenario>
                                 </Scenarios>";

            var stagedData = @"<Scenarios ErrorSource=""Torus"">
                                  <Scenario ErrorSource=""Torus"">
                                    <SubScenario ErrorSource=""Torus"" />
                                  </Scenario>
                                  <Scenario ErrorSource=""Torus"">
                                    <SubScenario ErrorSource=""Torus"" />
                                  </Scenario>
                                 </Scenarios>";

            // act
            var result = IsCurrentRunHavingLessErrors(currentData, stagedData);

            // assert
            Assert.IsTrue(result);
        }

        [Test]
        public void GivenXmlErrorComparer_WhenCurrentSubscenarioHasSameValueAsCombinedInStaged_ThenReturnFalse()
        {
            // arrange
            var currentData = @"<Scenarios>
                                  <Scenario>
                                    <SubScenario />
                                  </Scenario>
                                  <Scenario>
                                    <SubScenario ErrorSource=""Torus"" />
                                    <SubScenario ErrorSource=""Torus"" />
                                    <SubScenario ErrorSource=""Torus"" />
                                    <SubScenario />
                                  </Scenario>
                                 </Scenarios>";

            var stagedData = @"<Scenarios>
                                  <Scenario ErrorSource=""Torus"">
                                    <SubScenario ErrorSource=""Torus"" />
                                  </Scenario>
                                  <Scenario>
                                    <SubScenario ErrorSource=""Torus"" />
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
        public void GivenXmlErrorComparer_WhenUnfullScenarioHasLessValueThanFullScenarioWithAdditionInStaged_ThenReturnFalse()
        {
            // arrange
            var currentData = @"<Scenarios>
                                  <Scenario>
                                    <SubScenario />
                                  </Scenario>
                                  <Scenario>
                                    <SubScenario ErrorSource=""Torus"" />
                                    <SubScenario ErrorSource=""Torus"" />
                                    <SubScenario />
                                  </Scenario>
                                 </Scenarios>";

            var stagedData = @"<Scenarios>
                                  <Scenario ErrorSource=""Torus"">
                                    <SubScenario ErrorSource=""Torus"" />
                                  </Scenario>
                                  <Scenario>
                                    <SubScenario ErrorSource=""Torus"" />
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
