namespace Poker.Exception;

public class CardsCounterException(string message) : System.Exception($"The cards counter must be ${message}");