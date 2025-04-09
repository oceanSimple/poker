using Poker;

var handler = PokerHandler.Instance;

// 获得一副牌
var deck = handler.GetDeck();
// 洗牌
deck.Shuffle();

// 各抽七张牌
var card1 = deck.Draw(7);
var card2 = deck.Draw(7);

Console.WriteLine($"Card1: {string.Join(" ", card1)}");
Console.WriteLine($"Card2: {string.Join(" ", card2)}");

// 通过手上的七张牌, 获得最大的五张牌
var hand1 = handler.GetHand(card1);
var hand2 = handler.GetHand(card2);

Console.WriteLine($"Hand1: {hand1}");
Console.WriteLine($"Hand2: {hand2}");

// 比较大小
var result = handler.CompareTwoHands(hand1, hand2);
Console.WriteLine($"Compare result: {result}");