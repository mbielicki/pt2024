using System.IO;
using static System.IO.Directory;

namespace Data.Database
{
    public static class ConnectionString
    {
        public static string Get()
        {
            string dbRelativePath = @"Data\bookshop.mdf";
            string workingDirectory = Environment.CurrentDirectory;
            string solutionDirectory = GetParent(GetParent(GetParent(GetParent(workingDirectory).FullName).FullName).FullName).FullName;
            string dbPath = Path.Combine(solutionDirectory, dbRelativePath);
            return $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={dbPath};Integrated Security = True;";

        }
    }
}
