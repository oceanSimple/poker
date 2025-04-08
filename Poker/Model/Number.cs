namespace Poker.Model;

public class Number {
    public readonly int Code;
    public readonly int Value;
    public readonly string Description;
    public readonly string Picture;

    public Number(int code) {
        switch (code) {
            case 1:
                Code = 1;
                Value = 14;
                Description = "Ace";
                Picture = "A";
                break;
            case 2:
                Code = 2;
                Value = 2;
                Description = "Two";
                Picture = "2";
                break;
            case 3:
                Code = 3;
                Value = 3;
                Description = "Three";
                Picture = "3";
                break;
            case 4:
                Code = 4;
                Value = 4;
                Description = "Four";
                Picture = "4";
                break;
            case 5:
                Code = 5;
                Value = 5;
                Description = "Five";
                Picture = "5";
                break;
            case 6:
                Code = 6;
                Value = 6;
                Description = "Six";
                Picture = "6";
                break;
            case 7:
                Code = 7;
                Value = 7;
                Description = "Seven";
                Picture = "7";
                break;
            case 8:
                Code = 8;
                Value = 8;
                Description = "Eight";
                Picture = "8";
                break;
            case 9:
                Code = 9;
                Value = 9;
                Description = "Nine";
                Picture = "9";
                break;
            case 10:
                Code = 10;
                Value = 10;
                Description = "Ten";
                Picture = "10";
                break;
            case 11:
                Code = 11;
                Value = 11;
                Description = "Jack";
                Picture = "J";
                break;
            case 12:
                Code = 12;
                Value = 12;
                Description = "Queen";
                Picture = "Q";
                break;
            case 13:
                Code = 13;
                Value = 13;
                Description = "King";
                Picture = "K";
                break;
            case 14:
                Code = 14;
                Value = 15;
                Description = "Joker";
                Picture = "Joker";
                break;
            default:
                Code = -1;
                Value = -1;
                Description = "Unknown";
                Picture = "";
                break;
        }
    }

    public int CompareTo(Number other) {
        return Value.CompareTo(other.Value);
    }
}