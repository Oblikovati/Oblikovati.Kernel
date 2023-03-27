using Oblikovati.Domain.Contracts;

namespace Oblikovati.Domain.Core.Application;

public class TestManager : ITestManager
{
    public ITestCases TestCases { get; set; }
    public ITestPrograms TestPrograms { get; set; }
    public ITestConfiguration TestConfiguration { get; set; }
    public object TestHost { get; set; }
    public object TestObject { get; set; }
    public IEnumType GetEnumType(string EnumNameType)
    {
        throw new NotImplementedException();
    }
}