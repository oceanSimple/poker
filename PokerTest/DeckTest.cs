using Poker.Exception;
using Poker.Model;
using Xunit.Abstractions;

namespace PokerTest;

public class DeckTest(ITestOutputHelper testOutputHelper) {
    [Fact]
    public void TestDeck() {
        var deck = new Deck();
        testOutputHelper.WriteLine(deck.ToString());
    }

    [Fact]
    public void TestDeckShuffle() {
        var deck = new Deck();
        deck.Shuffle();
        testOutputHelper.WriteLine(deck.ToString());
    }

    [Fact]
    public void TestDeckSort() {
        var deck = new Deck();
        deck.Shuffle();
        deck.Sort();
        testOutputHelper.WriteLine(deck.ToString());
    }

    [Fact]
    public void TestDeckDraw() {
        var deck = new Deck();
        deck.Shuffle();

        var cards = deck.Draw(5);
        Assert.Equal(5, cards.Count);
        Assert.Equal(47, deck.Count);

        Assert.Throws<NoEnoughCardsInDeck>(() => deck.Draw(48));
    }
}