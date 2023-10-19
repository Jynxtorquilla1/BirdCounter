namespace BirdCounter
{
    public  class Statistics
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public float Avarage { get
            {
                return Sum / Count;                
            }
        }
        public int Sum { get; set; }

        public int Count { get; set; }

        public Statistics()
        {
            Sum = 0;
            Count = 0;
            
            Min = int.MaxValue;
            Max = int.MinValue;
            
        }

        public void CalculateStatistics (int number)
        {
            Count++;
            Sum += number;
            Min = Math.Min(number, Min);
            Max = Math.Max(number, Max);
        }
       
     
    }
}
