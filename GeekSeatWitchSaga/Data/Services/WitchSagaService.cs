namespace GeekSeatWitchSaga.Data.Services
{
    public class WitchSagaService
    {
        public WitchSagaService() 
        { 
        
        }
        public int GenerateNumberOfKilled(int iMax)
        {
            int iKilled = 0;
            if (iMax == 1)
            {
                iKilled = 1;
            }
            else if (iMax == 2)
            {
                iKilled = 2;
            }
            else
            {
                iKilled = 2;
                int iFirst = 1;
                int iSecond = 2;
                int iStage = 0;
                for (var i = 2; i < iMax; i++)
                {
                    iKilled = iKilled + iSecond;

                    iStage = iSecond;
                    iSecond = iFirst + iSecond;
                    iFirst = iStage;
                }
            }

            return iKilled;
        }
        public decimal AverageData(int iSumData, int iCountData)
        {
            decimal dAvg = 0;

            dAvg = Convert.ToDecimal(iSumData) / Convert.ToDecimal(iCountData);
            return dAvg;
        }
    }
}
