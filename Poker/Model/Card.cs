using Poker.Enum;

namespace Poker.Model;

public class Card(EColor color, ENumber number) {
    public readonly Color Color = new((int)color);
    public readonly Number Number = new((int)number);


    public override string ToString() {
        return $"{Color.Picture}{Number.Picture}";
    }
}