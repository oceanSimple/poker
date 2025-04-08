using Poker.Enum;

namespace Poker.Model;

public class Card(EColor color, ENumber number) {
    public readonly Color Color = new((int)color);
    public readonly Number Number = new((int)number);

    public override bool Equals(object? obj) {
        return obj is Card card && Color.Equals(card.Color) && Number.Equals(card.Number);
    }

    public override int GetHashCode() {
        return HashCode.Combine(Color, Number);
    }

    public override string ToString() {
        return $"{Color.Picture}{Number.Picture}";
    }
}