using System.IO;
using static System.IO.Directory;

namespace BookshopTest.Data.Database
{
    public static class TestConnectionString
    {
        public static string Get()
        {
            string dbRelativePath = @"Database\bookshop.mdf";
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = GetParent(GetParent(GetParent(workingDirectory).FullName).FullName).FullName;
            string dbPath = Path.Combine(projectDirectory, dbRelativePath);
            return $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={dbPath};Integrated Security = True;";

        }
    }
}
