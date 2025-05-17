namespace Poker.Model;

public class Color {
    public int Code { get; set; }
    public string Description { get; set; }
    public string Picture { get; set; }

    public Color(int code) {
        switch (code) {
            case 0:
                Code = 0;
                Description = "Spade";
                Picture = "♠";
                break;
            case 1:
                Code = 1;
                Description = "Heart";
                Picture = "♥";
                break;
            case 2:
                Code = 2;
                Description = "Diamond";
                Picture = "♦";
                break;
            case 3:
                Code = 3;
                Description = "Club";
                Picture = "♣";
                break;
            case 4:
                Code = 4;
                Description = "Red";
                Picture = "Red";
                break;
            case 5:
                Code = 5;
                Description = "Black";
                Picture = "Black";
                break;
            default:
                Code = -1;
                Description = "Unknown";
                Picture = " ";
                break;
        }
    }

    public override bool Equals(object? obj) {
        return obj is Color color && Code == color.Code;
    }

    public override int GetHashCode() {
        return Code.GetHashCode();
    }

    public int CompareTo(Color other) {
        return Code.CompareTo(other.Code);
    }
}