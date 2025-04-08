namespace Poker.Model;

public class Hand {
    // Initial cards
    public List<Card> Cards;

    // Hand type, e.g., Straight, Flush, etc.
    public int Type;

    // When two hand are the same type, use ranks to compare
    public List<int> Ranks;

    // Max combination 5 cards for the hand
    public List<Card> MaxCombination;

    /// <summary>
    ///     Get all combinations of n cards from the given list of cards.
    /// </summary>
    /// <param name="cards">Given list of cards</param>
    /// <param name="n">The number of combination cards</param>
    /// <returns>
    ///     A list of all combinations of n cards from the given list of cards.
    /// </returns>
    public List<List<Card>> GetCombinations(List<Card> cards, int n) {
        List<List<Card>> combinations = new List<List<Card>>();
        int count = cards.Count;
        if (n > count) return combinations;

        // Generate all combinations of size n
        for (int i = 0; i < (1 << count); i++) {
            List<Card> combination = new List<Card>();
            for (int j = 0; j < count; j++) {
                if ((i & (1 << j)) != 0) {
                    combination.Add(cards[j]);
                }
            }

            if (combination.Count == n) {
                combinations.Add(combination);
            }
        }

        return combinations;
    }
}