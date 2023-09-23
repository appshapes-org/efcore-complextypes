using Xunit;

namespace Tests;

[CollectionDefinition("Service")]
public class ServiceTestsCollection : ICollectionFixture<ServiceTestsSetup>;