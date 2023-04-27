namespace CopperStudios.Tools
{
    public struct Vector2Int
    {
        // Per Instance
        public int x;
        public int y;

        public int X { get => x; set => x = value;}
        public int Y { get => y; set => y = value;}

        public Vector2Int(int X, int Y)
        {
            x = X;
            y = Y;
        }

        public Vector2Int(int value)
        {
            x = value;
            y = value;
        }

        // Template Values

        public static Vector2Int One() 
        { 
            return new Vector2Int(1, 1); 
        }
        public static Vector2Int Zero() 
        { 
            return new Vector2Int(0, 0); 
        }
        
        // Math
        public static Vector2Int Add(Vector2Int left, Vector2Int right)
        {
            return new Vector2Int(left.x + right.x, left.y + right.y); 
        }

        public static Vector2Int Subtract(Vector2Int left, Vector2Int right)
        {
            return new Vector2Int(left.x - right.x, left.y - right.y); 
        }

        public static Vector2Int Multiply(Vector2Int left, Vector2Int right)
        {
            return new Vector2Int(left.x * right.x, left.y * right.y); 
        }

        public static Vector2Int Divide(Vector2Int left, Vector2Int right)
        {
            return new Vector2Int(left.x / right.x, left.y / right.y); 
        }


        public static Vector2Int Multiply(Vector2Int value, int amount)
        {
            return new Vector2Int(value.X * amount, value.Y * amount); 
        }

        public static Vector2Int Divide(Vector2Int value, int amount)
        {
            return new Vector2Int(value.X / amount, value.Y / amount); 
        }
    }
}