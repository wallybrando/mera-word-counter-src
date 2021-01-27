using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Mera.WordCounter.Server.Interfaces.Repositories;
using Mera.WordCounter.Server.Repository;
using Mera.WordCounter.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mera.WordCounter.Server.Tests.Repository
{
    /// <summary>
    /// Text Repository Tests
    /// </summary>
    [TestClass]
    public class TextRepositoryTests
    {
        #region ReadText_ById(int id)

        [TestMethod]
        [TestCategory("Web API"), TestCategory("Repository"), TestCategory("Text")]
        [Owner("Marko Stojkovic")]
        [ExpectedException(typeof(ArgumentException))]
        public async Task ReadText_IdIsZero_ThrowArgumentException()
        {
            ITextRepository alertDataAccess = new TextRepository(new ApplicationDbContext(
                new DbContextOptions<ApplicationDbContext>()));

            await alertDataAccess.ReadText_ById(0);
        }

        [TestMethod]
        [TestCategory("Web API"), TestCategory("Repository"), TestCategory("Text")]
        [Owner("Marko Stojkovic")]
        [ExpectedException(typeof(ArgumentException))]
        public async Task ReadText_IdIsLessThanZero_ThrowArgumentException()
        {
            ITextRepository textRepository = new TextRepository(new ApplicationDbContext(
                    new DbContextOptions<ApplicationDbContext>()));

            await textRepository.ReadText_ById(-123);
        }

        #endregion

        #region CreateText(Text model)

        [TestMethod]
        [TestCategory("Web API"), TestCategory("Repository"), TestCategory("Text")]
        [Owner("Marko Stojkovic")]
        [ExpectedException(typeof(ValidationException))]
        public async Task CreateText_ContentIsEmpty_ThrowValidationException()
        {
            ITextRepository textRepository = new TextRepository(new ApplicationDbContext(
                new DbContextOptions<ApplicationDbContext>()));

            await textRepository.CreateText(new Text { Content = "" });
        }

        [TestMethod]
        [TestCategory("Web API"), TestCategory("Repository"), TestCategory("Text")]
        [Owner("Marko Stojkovic")]
        [ExpectedException(typeof(ValidationException))]
        public async Task CreateText_ContentIsNull_ThrowValidationException()
        {
            ITextRepository textRepository = new TextRepository(new ApplicationDbContext(
                new DbContextOptions<ApplicationDbContext>()));

            await textRepository.CreateText(new Text { Content = null });
        }

        #endregion

        #region UpdateText(Text text)

        [TestMethod]
        [TestCategory("Web API"), TestCategory("Repository"), TestCategory("Text")]
        [Owner("Marko Stojkovic")]
        [ExpectedException(typeof(ArgumentException))]
        public async Task UpdateText_IdIsZero_ThrowArgumentException()
        {
            ITextRepository textRepository = new TextRepository(new ApplicationDbContext(
                new DbContextOptions<ApplicationDbContext>()));

            await textRepository.UpdateText(new Text { Id = 0, Content = "Word Counter" });
        }

        [TestMethod]
        [TestCategory("Web API"), TestCategory("Repository"), TestCategory("Text")]
        [Owner("Marko Stojkovic")]
        [ExpectedException(typeof(ArgumentException))]
        public async Task UpdateText_IdIsLessThanZero_ThrowArgumentException()
        {
            ITextRepository textRepository = new TextRepository(new ApplicationDbContext(
                new DbContextOptions<ApplicationDbContext>()));

            await textRepository.UpdateText(new Text { Id = -123, Content = "Word Counter" });
        }

        [TestMethod]
        [TestCategory("Web API"), TestCategory("Repository"), TestCategory("Text")]
        [Owner("Marko Stojkovic")]
        [ExpectedException(typeof(ValidationException))]
        public async Task UpdateText_ContentIsEmpty_ThrowValidationException()
        {
            ITextRepository textRepository = new TextRepository(new ApplicationDbContext(
                new DbContextOptions<ApplicationDbContext>()));

            await textRepository.UpdateText(new Text { Id = 1, Content = "" });
        }

        [TestMethod]
        [TestCategory("Web API"), TestCategory("Repository"), TestCategory("Text")]
        [Owner("Marko Stojkovic")]
        [ExpectedException(typeof(ValidationException))]
        public async Task UpdateText_ContentIsNull_ThrowValidationException()
        {
            ITextRepository textRepository = new TextRepository(new ApplicationDbContext(
                new DbContextOptions<ApplicationDbContext>()));

            await textRepository.UpdateText(new Text { Id = 1, Content = null });
        }

        #endregion

        #region DeleteText(int id)

        [TestMethod]
        [TestCategory("Web API"), TestCategory("Repository"), TestCategory("Text")]
        [Owner("Marko Stojkovic")]
        [ExpectedException(typeof(ArgumentException))]
        public async Task DeleteText_IdIsZero_ThrowArgumentException()
        {
            ITextRepository alertDataAccess = new TextRepository(new ApplicationDbContext(
                new DbContextOptions<ApplicationDbContext>()));

            await alertDataAccess.DeleteText(0);
        }

        [TestMethod]
        [TestCategory("Web API"), TestCategory("Repository"), TestCategory("Text")]
        [Owner("Marko Stojkovic")]
        [ExpectedException(typeof(ArgumentException))]
        public async Task DeleteText_IdIsLessThanZero_ThrowArgumentException()
        {
            ITextRepository textRepository = new TextRepository(new ApplicationDbContext(
                new DbContextOptions<ApplicationDbContext>()));

            await textRepository.DeleteText(-123);
        }

        #endregion

    }
}
