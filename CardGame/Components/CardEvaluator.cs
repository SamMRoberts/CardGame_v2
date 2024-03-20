namespace SamMRoberts.CardGame.Cards
{
    public readonly struct CardValue(string symbol, int value)
    {
        public string Symbol => symbol;
        public int Value => value;
    }

    public abstract class CardEvaluator<TFace>
        where TFace : Enum
    {
        protected abstract TFace Faces (TFace face);

        public void Interpret(Context context)
        {
            var symbol = GetSymbol((TFace)context.Face);
            var value = GetValue((TFace)context.Face);
            CardValue cardValue = new(symbol, value);
            context.Output = cardValue;
            /*
            if (context.Input.Length == 0)
                return;
            if (context.Input.StartsWith(Two()))
            {
                context.Output += 2;
                context.Input = context.Input.Substring(2);
            }
            else if (context.Input.StartsWith(Three()))
            {
                context.Output += 3;
                context.Input = context.Input.Substring(2);
            }
            while (context.Input.StartsWith(One()))
            {
                context.Output += (1 * Multiplier());
                context.Input = context.Input.Substring(1);
            }*/
        }

        public abstract string GetSymbol(TFace face);
        public abstract int GetValue(TFace face);
    }

    public class Context
    {
        Enum face;
        CardValue output;

        public Context(Enum face)
        {
            this.face = face;
        }
        public Enum Face
        {
            get { return face; }
            set { face = value; }
        }
        public CardValue Output
        {
            get { return output; }
            set { output = value; }
        }
    }
}