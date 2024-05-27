using System.IO;
using System.Security.AccessControl;
class BlackJack
{
    static void Main(string[] args)
    {
        //variables and arrays
        string[,] deck = new string[52,2];
        List<int> deckIndex = new List<int>();
        int listLength;
        //number of aces used to check for aces in hand for determining if an ace is a 1 or 11
        int aceNum = 0;
        float handValue = 0;
        bool game = true;
        int cardIndex;
        List<int> hand = new List<int>();

        deck = GetDeck(deck);
        CreateDeckIndex(deckIndex);
        listLength = deckIndex.Count;
        //the index of the array to get card name and value from the list.
        cardIndex = DrawCard(ref listLength, ref deckIndex, deck, ref aceNum);
        //player hand in main for now.        
        hand.Add(cardIndex);        
        
        DisplayHand(ref deck,ref hand,ref handValue, ref aceNum);
        while(game != false)
        {             
            Console.WriteLine("1: hit or 2: stay");
            try
            {
                int input = int.Parse(Console.ReadLine());

                    switch (input)
                    {
                        case 1:
                            cardIndex = DrawCard(ref listLength, ref deckIndex, deck, ref aceNum);
                            hand.Add(cardIndex);
                            break;
                        case 2:
                            game = false;
                            break;
                    }                
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            DisplayHand(ref deck,ref hand,ref handValue,ref aceNum);

            if(handValue >=22)
            {
                
                
                game = false;
                Console.WriteLine("you bust");
                
                
            }
        }
        
        
        

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
    static int DrawCard(ref int listLength, ref List<int> deckIndex, string[,] deck, ref int aceNum)
    {
        Random rndNum = new Random();
        int num = rndNum.Next(0,listLength);
        
        int value = deckIndex[0 /*num*/];
        
        deckIndex.RemoveAt(0 /*num*/);
        if(deck[value,1] == "11")
        {
            aceNum++;
            
        }
            

        return value;
    }

    static void DisplayHand(ref string[,] deck,ref List<int> hand, ref float handValue,ref int aceNum)
    {
        handValue = 0;    
        foreach(int i in hand)
        {
            int index = i;
            Console.Write(deck[i, 0] + ", ");
            handValue = handValue + float.Parse((deck[i, 1]));
            if(handValue >=22 && aceNum > 0)
            {
                handValue = handValue - (10*aceNum);
            }
        }
        Console.WriteLine("Total: " + handValue.ToString());
    }    
}