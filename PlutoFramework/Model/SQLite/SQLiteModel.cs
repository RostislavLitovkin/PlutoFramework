namespace PlutoFramework.Model.SQLite
{
    public class SQLiteModel
    {
        public static Task DeleteAllDatabasesAsync()
        {
            return Task.WhenAll(
                NftDatabase.DeleteAllAsync(),
                CollectionDatabase.DeleteAllAsync(),
                XcavatePropertyDatabase.DeleteAllAsync(),
                BalancesDatabase.DeleteAllAsync()
            );
        }
    }
}
