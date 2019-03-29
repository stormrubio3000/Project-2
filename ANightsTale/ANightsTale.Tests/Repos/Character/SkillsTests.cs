using ANightsTale.Library.CharacterLogic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ANightsTale.Library;

namespace ANightsTale.Tests.Repos.Character
{
    public class SkillsTests
    {
        public SkillManager manager { get; set; } = new SkillManager();

        [Fact]
        public void GetSkillsBardReturnsAllSkills()
        {
            // Arrange
            var skills = manager.GetSkillsByClass(4).ToList();

            // Act
            // Assert
            Assert.Equal(18, skills.Count);
            Assert.Equal("Acrobatics", skills[0].Name);
            Assert.Equal("History", skills[5].Name);
            Assert.Equal("Survival", skills[17].Name);
        }

        [Fact]
        public void GetSkillsPaladinReturnsProperSkills()
        {
            // Arrange
            var skills = manager.GetSkillsByClass(3).ToList();

            // Act
            // Assert
            Assert.Equal(6, skills.Count);
            Assert.Equal("Athletics", skills[0].Name);
            Assert.Equal("Insight", skills[1].Name);
            Assert.Equal("Intimidation", skills[2].Name);
            Assert.Equal("Medicine", skills[3].Name);
            Assert.Equal("Persuasion", skills[4].Name);
            Assert.Equal("Religion", skills[5].Name);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(11)]
        public void GetSkillsThrowsArgumentExceptionWithIncorrectId(int id)
        {
            // Arrange
            // Act
            // Assert
            Assert.ThrowsAny<ArgumentException>(() => manager.GetSkillsByClass(id));
        }

        [Fact]
        public void UpdateSkillsThrowsArgumentNullExceptionIfStatsIsNull()
        {
            // Arrange
            var skills = new List<int> { 1, 2 };

            // Act
            // Assert
            Assert.ThrowsAny<ArgumentNullException>(() => manager.UpdateSkills(skills, null));
        }

        [Fact]
        public void UpdateSkillsThrowsArgumentExceptionWhenSkillOutOfRange()
        {
            // Arrange
            var stats = new CharStats();
            var skills = new List<int> { -1 };
            // Act
            // Assert
            Assert.ThrowsAny<ArgumentException>(() => manager.UpdateSkills(skills, stats));
        }

        [Fact]
        public void UpdateSkillsUpdatesValuesCorrectly()
        {
            // Arrange
            var stats = new CharStats();
            stats.PB = 2;
            stats.Acrobatics = 2;
            stats.AnimalHandling = 0;
            stats.Survival = -1;

            var skills = new List<int> { 1, 2, 18 };

            // Act
            manager.UpdateSkills(skills, stats);

            // Assert
            Assert.Equal(4, stats.Acrobatics);
            Assert.Equal(2, stats.AnimalHandling);
            Assert.Equal(1, stats.Survival);
        }
    }
}
