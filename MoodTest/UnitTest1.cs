using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyzerProblem;

namespace MoodTest
{
    [TestClass]
    public class UnitTest1
    {
        //TC 1.1  
        [TestMethod]
        public void SadMood()
        {
            // Arrange
            string expected = "SAD";
            string message = "I am in Sad Mood";
            MoodAnalyzer moodAnalyse = new MoodAnalyzer(message);

            // Act
            string mood = moodAnalyse.AnalyseMood();

            // Assert
            Assert.AreEqual(expected, mood);
        }

        //TC 1.2
        [TestMethod]
        public void HappyMood()
        {
            // Arrange
            string expected = "HAPPY";
            string message = "I am in HAPPY Mood";
            MoodAnalyzer moodAnalyse = new MoodAnalyzer(message);

            // Act
            string mood = moodAnalyse.AnalyseMood();

            // Assert
            Assert.AreEqual(expected, mood);
        }
        // UC2 null message return happy
        [TestMethod]
        public void givenMood_WhenNull_ShouldReturnHappyMood()
        {
            // Arrange
            string expected = "Happy";
            UC2MoodAnalyzer moodAnalyse = new UC2MoodAnalyzer(null);
            // Act
            string mood = moodAnalyse.AnalyseMood();
            // Assert
            Assert.AreEqual(expected, mood);
        }


        // 3.1 null mood

        [TestMethod]
        public void Given_NULL_Mood_Should_Throw_MoodAnalysisException()
        {
            try
            {
                string message = null;
                UC3MoodAnalyse moodAnalyse = new UC3MoodAnalyse(message);
                string mood = moodAnalyse.AnalyseMood();
            }
            catch (MoodAnalysisException e)
            {
                Assert.AreEqual("Mood should not be null", e.Message);
            }
        }


        //3.2 Empty mood

        [TestMethod]
        public void Given_Empty_Mood_Should_Throw_MoodAnalysisException_Indicating_EmptyMood()
        {
            try
            {
                string message = "";
                UC3MoodAnalyse moodAnalyse = new UC3MoodAnalyse(message);
                string mood = moodAnalyse.AnalyseMood();
            }
            catch (MoodAnalysisException e)
            {
                Assert.AreEqual("Mood should not be Empty", e.Message);
            }
        }


        // Test Case 4.1 Given UC2MoodAnalyzer Class Name Should Return UC2MoodAnalyzer Object.

        [TestMethod]
        public void GivenMoodAnalyseClassName_ShouldReturnMoodAnalyseObject()
        {
            object expected = new UC2MoodAnalyzer();
            object obj = MoodAnalyseFactory.CreateMoodAnalyse("MoodAnalyzerProblem.UC2MoodAnalyzer", "UC2MoodAnalyzer");
            expected.Equals(obj);
        }


        // Test Case 4.2 Given Improper Class Name Should throw MoodAnalyssiException.

        [TestMethod]
        public void GivenImproperClassNameShouldThrowMoodAnalysisException()
        {
            string expected = "Class Not Found";
            try
            {
                object moodAnalyseObject = MoodAnalyseFactory.CreateMoodAnalyse("MoodAnalyzerApp.DemoClass", "DemoClass");

            }
            catch (MoodAnalysisException exception)
            {
                Assert.AreEqual(expected, exception.Message);
            }
        }


        /// Test Case 4.3 Given Improper Constructor should throw MoodAnalysisException.

        [TestMethod]
        public void GivenImproperConstructorShouldThrowMoodAnalysisException()
        {

            string expected = "Constructor is Not Found";
            try
            {
                object moodAnalyseObject = MoodAnalyseFactory.CreateMoodAnalyse("DemoClass", "MoodAnalyse");
            }
            catch (MoodAnalysisException exception)
            {
                Assert.AreEqual(expected, exception.Message);
            }
        }
    }
}