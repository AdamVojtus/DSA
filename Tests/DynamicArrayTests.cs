using DynamicArray;

namespace Tests
{
    public class DynamicArrayTests
    {
        [Test]
        public void GivenDynamicArray_WhenInitialized_ThenArrayIsEmpty()
        {
            // arrange & act
            var array = new DynamicArray.DynamicArray<string>(3);

            // assert
            Assert.That(array.Search("A"), Is.EqualTo(-1));
        }

        [Test]
        public void GivenDynamicArray_WhenAddCalled_ThenElementIsAppended()
        {
            // arrange
            var array = new DynamicArray.DynamicArray<string>(3);

            // act
            array.Add("A");
            array.Add("B");

            // assert
            Assert.That(array.Search("A"), Is.EqualTo(0));
            Assert.That(array.Search("B"), Is.EqualTo(1));
        }

        [Test]
        public void GivenDynamicArray_WhenInsertAtIndex_ThenElementIsInsertedAtCorrectPosition()
        {
            // arrange
            var array = new DynamicArray.DynamicArray<string>(3);

            array.Add("A");
            array.Add("B");
            array.Add("C");

            // act
            array.Insert(0, "X");

            // assert
            Assert.That(array.Search("X"), Is.EqualTo(0));
        }

        [Test]
        public void GivenDynamicArray_WhenInsertTriggersGrow_ThenCapacityIsIncreased()
        {
            // arrange
            var array = new DynamicArray.DynamicArray<string>(1);

            // act
            array.Add("A");
            array.Add("B");

            // assert
            Assert.That(array.Size, Is.EqualTo(2));
        }

        [Test]
        public void GivenDynamicArray_WhenDeleteExistingValue_ThenValueIsRemovedAndArrayIsShifted()
        {
            // arrange
            var array = new DynamicArray.DynamicArray<string>(3);

            array.Add("A");
            array.Add("B");

            // act
            array.Delete("A");

            // assert
            Assert.That(array.Size, Is.EqualTo(1));
            Assert.That(array.Search("B"), Is.EqualTo(0));
        }

        [Test]
        public void GivenDynamicArray_WhenDeleteNonExistingValue_ThenArrayRemainsUnchanged()
        {
            // arrange
            var array = new DynamicArray.DynamicArray<string>(3);
            array.Add("A");

            // act
            array.Delete("B");

            // assert
            Assert.That(array.Size, Is.EqualTo(1));
        }

        [Test]
        public void GivenDynamicArray_WhenDeleteTriggersShrink_ThenCapacityIsReduced()
        {
            // arrange
            var array = new DynamicArray.DynamicArray<string>(3);

            array.Add("A");
            array.Add("B");
            array.Add("C");

            // act
            array.Delete("B");
            array.Delete("C");

            // assert
            Assert.That(array.Size, Is.EqualTo(1));
        }

        [Test]
        public void GivenDynamicArray_WhenSearchExistingValue_ThenReturnCorrectIndex()
        {
            // arrange / act
            var array = new DynamicArray.DynamicArray<string>(3);
            array.Add("A");

            // assert
            Assert.That(array.Search("A"), Is.EqualTo(0));
        }

        [Test]
        public void GivenDynamicArray_WhenSearchNonExistingValue_ThenReturnMinusOne()
        {
            // arrange / act
            var array = new DynamicArray.DynamicArray<string>(3);

            // assert
            Assert.That(array.Search("A"), Is.EqualTo(-1));
        }
    }
}
