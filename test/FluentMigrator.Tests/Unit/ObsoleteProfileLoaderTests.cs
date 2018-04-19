﻿#region License
//
// Copyright (c) 2018, Fluent Migrator Project
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
#endregion

using System;
using System.Linq;

using FluentMigrator.Infrastructure;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Initialization;

using Moq;

using NUnit.Framework;
using NUnit.Should;

namespace FluentMigrator.Tests.Unit
{
    [TestFixture]
    [Obsolete]
    public class ObsoleteProfileLoaderTests
    {
        [Test]
        public void BlankProfileDoesntLoadProfiles()
        {
            var _runnerContextMock = new Mock<IRunnerContext>();
            var _runnerMock = new Mock<IMigrationRunner>();
            var _conventionsMock = new Mock<IMigrationRunnerConventions>();

            _runnerContextMock.Setup(x => x.Profile).Returns(string.Empty);
            //_runnerContextMock.VerifyGet(x => x.Profile).Returns(string.Empty);
            _runnerMock.SetupGet(x => x.MigrationAssemblies).Returns(new SingleAssembly(typeof(MigrationRunnerTests).Assembly));

            var profileLoader = new ProfileLoader(_runnerContextMock.Object, _runnerMock.Object, _conventionsMock.Object);

            profileLoader.ApplyProfiles();

            profileLoader.Profiles.Count().ShouldBe(0);
        }
    }
}
