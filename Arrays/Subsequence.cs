namespace Arrays
{
    public class Subsequence
    {
        public static bool IsSubsequence(int[] main, int[] input)
        {
            var mainIndex = 0;
            var inputIndex = 0;

            for(; inputIndex < input.Length; )
            {
                if(mainIndex == main.Length)
                {
                    return false;
                }

                if(main[mainIndex] == input[inputIndex])
                {
                    if(mainIndex == main.Length -1 && inputIndex != input.Length - 1)
                    {
                        return false;
                    }
                    
                    if(inputIndex == input.Length -1)
                    {
                        return true;
                    }

                    inputIndex++;
                }

                mainIndex++;
            }

            return false;
        }
    }
}
