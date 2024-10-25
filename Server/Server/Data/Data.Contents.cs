namespace Server.Data
{
    #region Test
    [Serializable]
    public class Test
    {
        public long Id;
    }

    [Serializable]
    public class TestData : ILoader<long, Data.Test>
    {
        public List<Test> Test = new();

        public Dictionary<long, Test> MakeDict()
        {
            Dictionary<long, Test> testDict = new();

            foreach (var test in Test)
            {
                testDict.Add(test.Id, test);
            }

            return testDict;
        }
    }
    #endregion

}
