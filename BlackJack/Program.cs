using System.IO;
class BlackJack
{
    static void Main(string[] args)
    {
        //variables and arrays
        string[,] deck = new string[52,2];
        List<int> deckIndex = new List<int>();
        int listLength;

        deck = GetDeck(deck);
        CreateDeckIndex(deckIndex);
        listLength = deckIndex.Count;
        //the index of the array to get card name and value from the list.
        int cardIndex = DrawCard(ref listLength, ref deckIndex);
//        Console.WriteLine(deck[cardIndex,0] + "\n" + deck[cardIndex,1]);

        //player hand in main for now.
        List<int> hand = new List<int>();
        hand.Add(cardIndex);
        
        float handValue = 0;
        bool game = true;
       
        while(game != false)
        {
            
            Console.WriteLine("1: hit or 2: stay");
            try
            {
                int input = int.Parse(Console.ReadLine());
  //              if(input != 1 || input != 2)
 //               {
  //                  Console.WriteLine("Please only type a 1 or 2");
   //                 input = int.Parse(Console.ReadLine());
  //              }
 //               else
 //               {
                    switch (input)
                    {
                        case 1:
                            cardIndex = DrawCard(ref listLength, ref deckIndex);
                            hand.Add(cardIndex);
                            break;
                        case 2:
                            game = false;
                            break;
                    }
 //               }
                
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

        }
        
        foreach(int i in hand)
        {
            Console.WriteLine(i.ToString());
        }
        Console.Write("Hand: ");
        foreach(int i in hand)
        {
        //    Console.WriteLine("card index: "+ i.ToString());
            int index = i;
            Console.Write(deck[i, 0] + ", ");
            handValue = handValue + float.Parse((deck[i, 1]));

        }
        Console.WriteLine("Total: " + handValue.ToString());

    }
    static string[,] GetDeck(string[,] pDeck)
    {
        string line;
        try
        {
            StreamReader sr = new StreamReader("deck.txt");
            line = sr.ReadLine();
            int x = 0;
            while(line != null)
            {
                pDeck[x,0] = line;
                line = sr.ReadLine();
                pDeck[x,1] = line;
                line = sr.ReadLine();
                x++;                
            }
        }
        catch(Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
        return pDeck;
    }
    //create deck reference
    static void CreateDeckIndex(List<int> pDeckIndex)
    {
        for(int i=0;i<52;i++)
        {
            pDeckIndex.Add(i);
        }
    }
    static int DrawCard(ref int listLength, ref List<int> deckIndex)
    {
        Random rndNum = new Random();
        int num = rndNum.Next(0,listLength);
        int value = deckIndex[num];
        deckIndex.RemoveAt(num);
        return value;
    }
    static void AddToHand()
    {

    }
    
}