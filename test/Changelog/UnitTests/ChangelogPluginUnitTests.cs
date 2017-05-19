﻿using JeremyTCD.ContDeployer.PluginTools;
using JeremyTCD.DotNetCore.Utils;
using LibGit2Sharp;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace JeremyTCD.ContDeployer.Plugin.Changelog.Tests.UnitTests
{
    public class ChangelogPluginUnitTests
    {
        private MockRepository _mockRepository { get; }

        public ChangelogPluginUnitTests()
        {
            _mockRepository = new MockRepository(MockBehavior.Loose) { DefaultValue = DefaultValue.Mock };
        }

        [Fact]
        public void Run_ThrowsExceptionIfStepContextPluginOptionsIsNotAChangelogPluginOptionsInstance()
        {
            // Arrange
            Mock<IStepContext> mockStepContext = _mockRepository.Create<IStepContext>();
            mockStepContext.Setup(s => s.Options).Returns((IPluginOptions)null);

            ChangelogPlugin plugin = new ChangelogPlugin(null, null);

            // Act and Assert
            Assert.Throws<InvalidOperationException>(() => plugin.Run(null, mockStepContext.Object));
            _mockRepository.VerifyAll();
        }

        [Fact]
        public void Run_ThrowsExceptionIfChangelogFileDoesNotExist()
        {
            // Arrange
            string testFile = "testFile";

            Mock<IStepContext> mockStepContext = _mockRepository.Create<IStepContext>();
            mockStepContext.Setup(s => s.Options).Returns(new ChangelogPluginOptions { File = testFile });

            Mock<IFileService> mockFileService = _mockRepository.Create<IFileService>();
            mockFileService.Setup(f => f.Exists(It.Is<string>(s => s == testFile))).Returns(false);

            ChangelogPlugin changelogPlugin = new ChangelogPlugin(null, mockFileService.Object);

            // Act and Assert
            Assert.Throws<InvalidOperationException>(() => changelogPlugin.Run(null, mockStepContext.Object));
            _mockRepository.VerifyAll();
        }

        [Fact]
        public void Run_ThrowsExceptionIfChangelogFileIsEmpty()
        {
            // Arrange
            string testFile = "testFile";

            Mock<IStepContext> mockStepContext = _mockRepository.Create<IStepContext>();
            mockStepContext.Setup(o => o.Options).Returns(new ChangelogPluginOptions { File = testFile });

            Mock<IFileService> mockFileService = _mockRepository.Create<IFileService>();
            mockFileService.Setup(f => f.Exists(It.Is<string>(s => s == testFile))).Returns(true);
            mockFileService.Setup(f => f.ReadAllText(It.Is<string>(s => s == testFile))).Returns("");

            ChangelogPlugin changelogPlugin = new ChangelogPlugin(null, mockFileService.Object);

            // Act and Assert
            Assert.Throws<InvalidOperationException>(() => changelogPlugin.Run(null, mockStepContext.Object));
            _mockRepository.VerifyAll();
        }

        [Fact]
        public void Run_GeneratesChangelogAndInsertsItIntoSharedDataIfSuccessful()
        {
            // Arrange
            string testFile = "testFile";
            string testChangelogText = "testChangelogText";
            string testPattern = "testPattern";

            Mock<IStepContext> mockStepContext = _mockRepository.Create<IStepContext>();
            mockStepContext.Setup(o => o.Options).Returns(new ChangelogPluginOptions
            {
                File = testFile,
                Pattern = testPattern
            });

            Mock<IChangelog> mockChangelog = _mockRepository.Create<IChangelog>();
            Mock<IChangelogFactory> mockChangelogFactory = _mockRepository.Create<IChangelogFactory>();
            mockChangelogFactory.Setup(c => c.Build(testPattern, testChangelogText)).Returns(mockChangelog.Object);

            Mock<IFileService> mockFileService = _mockRepository.Create<IFileService>();
            mockFileService.Setup(f => f.Exists(It.Is<string>(s => s == testFile))).Returns(true);
            mockFileService.Setup(f => f.ReadAllText(It.Is<string>(s => s == testFile))).Returns(testChangelogText);

            Mock<IPipelineContext> mockPipelineContext = _mockRepository.Create<IPipelineContext>();

            ChangelogPlugin changelogPlugin = new ChangelogPlugin(mockChangelogFactory.Object, mockFileService.Object);

            // Act
            changelogPlugin.Run(mockPipelineContext.Object, mockStepContext.Object);

            // Assert
            _mockRepository.VerifyAll();
            Mock<IDictionary<string, object>> mockSharedData = Mock.Get(mockPipelineContext.Object.SharedData);
            mockSharedData.VerifySet(s => s[nameof(Changelog)] = mockChangelog.Object);
        }
    }
}
